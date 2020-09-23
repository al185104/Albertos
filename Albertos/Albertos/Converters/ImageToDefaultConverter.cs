using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Albertos.Converters
{
    class ImageToDefaultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                throw new InvalidOperationException("The target must be a Date");
            }

            string val = value as string;

            if (string.IsNullOrWhiteSpace(val) || val.Equals("image_placeholder.png") || val.Equals("string") || val.ToString().Contains(".png") == false)
                return "settings_productimage_placeholder.png";
            else
                return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
