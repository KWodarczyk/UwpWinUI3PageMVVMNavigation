using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppWinUI3
{
    public class ViewModelContext : DependencyObject
    {
        public static readonly DependencyProperty TypeProperty =
        DependencyProperty.RegisterAttached(
          "ViewModelContext",
          typeof(string),
          typeof(ViewModelContext),
          new PropertyMetadata(null)
        );

        public static void SetType(DependencyObject element, string value)
        {
            element.SetValue(TypeProperty, value);
        }
        public static string GetType(DependencyObject element)
        {
            return (string)element.GetValue(TypeProperty);
        }
    }
}
