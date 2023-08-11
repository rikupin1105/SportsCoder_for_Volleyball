using Reactive.Bindings;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SportsCoderForVolleyball.HorizonalBottom.Converter
{
    internal class CollectionCountToHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var a = value as int?;
            return 60 + ((a-1) * 44);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
