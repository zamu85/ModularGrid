using System;
using System.Globalization;
using System.Windows.Data;

namespace View.ValueConverters
{
    public class LayoutToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int layout)
            {
                if (layout > 1)
                {
                    return true;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
