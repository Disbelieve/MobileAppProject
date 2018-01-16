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
            if ((Int32)value == 0)
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Color.FromArgb(255, 231, 246, 236));
                else
                    return new SolidColorBrush(Colors.Green);
            }
            else if ((Int32)value == 1)
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Color.FromArgb(255, 255, 228, 178));
                else
                    return new SolidColorBrush(Color.FromArgb(255, 178, 115, 0));
            }

            else if ((Int32)value == 2)
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Color.FromArgb(255, 248, 226, 227));
                else
                    return new SolidColorBrush(Colors.Red);
            }

            else
            {
                if ((string)parameter == "background")
                    return new SolidColorBrush(Colors.LightGray);
                else
                    return new SolidColorBrush(Colors.DarkGray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
