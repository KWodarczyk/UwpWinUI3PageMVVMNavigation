using System;
using TestAppUWP;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TestAppUWP.Views
{
    class CustomTemplateSelector : DataTemplateSelector
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
}
