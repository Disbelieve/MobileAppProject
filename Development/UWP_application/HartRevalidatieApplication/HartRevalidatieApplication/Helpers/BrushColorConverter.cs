using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace HartRevalidatieApplication.Helpers
{
    public class BrushColorConverter : IValueConverter
    {
        //Fill="#E7F6EC"
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((string)value == "Uw bloeddruk is prima.")
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Color.FromArgb(255, 231, 246, 236));
                else
                    return new SolidColorBrush(Colors.Green);
            }
            else
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Color.FromArgb(255, 248, 226, 227));
                else
                    return new SolidColorBrush(Colors.Red);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
