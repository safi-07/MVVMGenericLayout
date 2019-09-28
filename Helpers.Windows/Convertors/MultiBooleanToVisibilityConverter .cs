using System;
using System.Windows.Data;

namespace Helpers.Windows.Convertors
{
    public class MultiBooleanToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values,
                                Type targetType,
                                object parameter,
                                System.Globalization.CultureInfo culture)
        {
            bool visible = true;
            if (parameter != null && parameter.ToString() == "OR")
                visible = false;
            foreach (object value in values)
                if (value is bool)
                {
                    if (parameter != null && parameter.ToString() == "OR")
                        visible = visible || (bool)value;
                    else
                        visible = visible && (bool)value;
                }

            if (visible)
                return System.Windows.Visibility.Visible;
            else
                return System.Windows.Visibility.Hidden;
        }

        public object[] ConvertBack(object value,
                                    Type[] targetTypes,
                                    object parameter,
                                    System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
