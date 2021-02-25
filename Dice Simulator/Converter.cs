using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using static Dice_Simulator.VM;

namespace Dice_Simulator
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((DieImageCodes)value)
            {
                case DieImageCodes.ONE:
                    return Path.Combine("Images", "Die1.bmp");
                case DieImageCodes.TWO:
                    return Path.Combine("Images", "Die2.bmp");
                case DieImageCodes.THREE:
                    return Path.Combine("Images", "Die3.bmp");
                case DieImageCodes.FOUR:
                    return Path.Combine("Images", "Die4.bmp");
                case DieImageCodes.FIVE:
                    return Path.Combine("Images", "Die5.bmp");
                case DieImageCodes.SIX:
                    return Path.Combine("Images", "Die6.bmp");
                case DieImageCodes.TWENTY_SIDE:
                    return Path.Combine("Images", "20Dice.png");
                default:
                    return String.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
