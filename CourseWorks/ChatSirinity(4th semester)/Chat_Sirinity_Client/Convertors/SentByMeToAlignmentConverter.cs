using System.Globalization;
using System.Windows;

namespace Chat_Sirinity_Client.Convertors;

public class SentByMeToAlignmentConverter: BaseValueConverter<SentByMeToAlignmentConverter>
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new Exception();
    }
}
