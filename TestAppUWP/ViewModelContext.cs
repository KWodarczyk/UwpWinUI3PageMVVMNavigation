﻿using System;
using Windows.UI.Xaml;

namespace TestAppUWP
{
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
}
