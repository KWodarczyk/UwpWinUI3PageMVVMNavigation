using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppWinUI3.Views
{
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
                            string contexType = dataTempate.GetValue(ViewModelContext.TypeProperty) as string;

                            if (contexType != null && contexType == viewModeltype.FullName)
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
