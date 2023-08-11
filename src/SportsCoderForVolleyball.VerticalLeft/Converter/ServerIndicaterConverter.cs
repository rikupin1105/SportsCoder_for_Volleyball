﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace SportsCoderForVolleyball.VerticalLeft.Converter
{
    internal class ServerIndicaterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
