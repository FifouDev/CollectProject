using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;

namespace CoPro.Converters
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var val = value as string;
                Uri uri = null;
                if (!string.IsNullOrEmpty(val) && Uri.TryCreate(val, UriKind.Absolute, out uri))
                {
                   // return new BitmapImage(uri);
                }
            }
            catch (Exception) { }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
