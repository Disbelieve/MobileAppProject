using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace HartRevalidatieApplication.Helpers
{
   public class DateFormatConverter : IValueConverter
    {   
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            CultureInfo dutch = new CultureInfo("nl-NL");

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("ddd, dd MMM yyyy", dutch);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
