using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hotel.Convertors
{
    class RoomConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {

                RoomType rt = new RoomType();
                if (values[2].ToString() == "Liber")
                    rt.Room.Availability = true;
                else
                    rt.Room.Availability= false;
                rt.CameraType = values[0].ToString();

                float price;
                if (float.TryParse(values[1].ToString(), out price))
                    rt.Room.Price = price;
                else
                    return null;
                return rt;
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
