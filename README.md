# UWP/ WinUI 3.0 Page and View Model navigation with MVVM
This is my take on Page and ViewModel Navigation in UWP/Win UI 3.0 framework using MVVM. I am not using any 3rd party API just what you get out of the box in UWP.
Before I explain how this works, bear in mind that I did not care much about the whole SOLID thing and best practices here, so no IOC, no DI that stuff you can do it our self.
Also no validation what so ever. 

The idea here is to just give you the essence of the solution for switching between Pages whether is a menu item page or page within same menu item. I use basically the same logic everywhere.


I was looking for solution online myself but none of them seems to match my criteria.
For example this one https://nicksnettravels.builttoroam.com/viewmodel-navigation/ seems like an overkill for me, and also did not like the idea of passing a Frame around.
This one https://rachel53461.wordpress.com/2011/12/18/navigation-with-mvvm-2/ was more what I wanted but unfortunately in UWP there is no such thing as 'implicit datatemplating' where we can switch the context based on the datatype of the datatemplate and don’t even need template selector. 

I have also seen solution where ViewModel would have just hardcoded string pointing to the corresponding datatemplate and I don't like this idea, ViewModel should not know anything about View.
I don't mind if ViewModel navigates to another ViewModel that is fine to me.

I wanted something simple but something that does not blow up the TemplateSelector by adding templates to it, it has to be generic and also work nicely with MVVN.
In my solution we basically need just two things to make this work 
1. Custom DataTemplateSelector 
2. AttacheProperty (AP)

You may think but why we need AP if we can have x:DataType in the DataTemplate so in the custom selector we can match against ViewModel right ? Wrong, unfortunately there is
no way to get to that Mother####r from the code. 
However I have just found out that DataTemplate in UWP is not the same as DataTemplate in WPF and here is the difference

WPF DataTemplate Inheritance:

Object -> DispatcherObject -> FrameworkTemplate -> DataTemplate

UWP DataTempmlate Inheritance: 

Object -> **DependencyObject** -> FrameworkTemplate -> DataTemplate

And the key difference is the  DataTemplate in UWP inherits form DependecyObject up the tree which in turn means that we can apply AttachedProperty to that Bad Boy and get to Type of our ViewModel that set via our AP. (I called it ViewModelContext)


```
<DataTemplate x:Key="PageOne" viewModels:ViewModelContext.Type="viewModels:PageOneViewModel">
   <views:PageOne/>
</DataTemplate>
```

**BTW this will also work in WinUI3 however there is a bug and the Type is not comming throug to AP Setter so once it's fixed it will also wrok in WinUI3.0**

https://github.com/microsoft/microsoft-ui-xaml/issues/6171

now our AP is:

```
    public class ViewModelContext : DependencyObject
    {
        public static readonly DependencyProperty TypeProperty =
        DependencyProperty.RegisterAttached(
          "ViewModelContext",
          typeof(Type),
          typeof(ViewModelContext),
          new PropertyMetadata(null)
        );
        public static void SetType(DependencyObject element, Type value)
        {
            element.SetValue(TypeProperty, value);
        }
        public static Type GetType(DependencyObject element)
        {
            return (Type)element.GetValue(TypeProperty);
        }
    }
```
as you can see the Property itself is of type 'Type' this is the trick that will allow us to make complie time checking in our XAML so if we rename or our ViewModel it will work us.

And here is our custom template selector:

```
    public class CustomTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item != null)
            {
                var viewModeltype = item.GetType();

                foreach (var rd in Application.Current.Resources.MergedDictionaries)
                {
                    foreach (var value in rd.Values)
                    {
                        if (value is DataTemplate dataTempate)
                        {
                            Type contexType = dataTempate.GetValue(ViewModelContext.TypeProperty) as Type;

                            if (contexType != null && contexType == viewModeltype)
                            {
                                return dataTempate;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
    
```

As you can see we just need one Selector like this and we are done, we do not need to add any DataTemplates to it, it's all automatic we just search for our datatempalte in the resources and compare it's AP Type against our ViewModel that is passed to it in the SelectTemplateCore event handler.
   
Rest of the classes are just to make 3 Pages with their corresponding  ViewModels so that we can switch between NavigationView menu items and also within our app as well.

The code is on MIT license so take it, and do whatever you want.

Thanks,

Karol
