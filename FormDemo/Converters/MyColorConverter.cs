using System;
using System.Globalization;
using FormDemo.ViewModels;
using Xamarin.Forms;

namespace FormDemo.Converters
{
    public class PriorityToBackgroundColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (OrderTimingPriority) value;
            return priority == OrderTimingPriority.High ? Color.DarkRed : Color.DarkGreen;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}