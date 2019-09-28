using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Helpers.Windows.Convertors
{

    public class DataGridRowToIndexConvertor : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow row = value as DataGridRow;
            return row.GetIndex() + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
