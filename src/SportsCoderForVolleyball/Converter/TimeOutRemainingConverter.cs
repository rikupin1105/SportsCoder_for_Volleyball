using SportsCoderForVolleyball.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SportsCoderForVolleyball.Converter
{
    internal class TimeOutRemainingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = "";
            var CanUseCount = Control.Instance.TIMEOUT.Value - System.Convert.ToInt32(value);
            for (int i = 0; i < CanUseCount; i++)
            {
                s+="⚫";
            }
            for (int i = 0; i < System.Convert.ToInt32(value); i++)
            {
                s+="⚪";
            }
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
