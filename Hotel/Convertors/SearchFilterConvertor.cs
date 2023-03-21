using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hotel.Convertors
{
    class SearchFilterConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == null && values[1] == null && values[2] == null && values[3] == null &&
                values[4] == null && values[5] == null && values[6] == null &&
                values[7] == null && values[8] == null && values[9] == null && values[10] == null &&
                values[11] == null && values[12] == null)
            {
                return null;
            }
            else
            {
                RoomFeatures rf = new RoomFeatures();
                if (values[0] != null)
                {
                    rf.room.CameraType = values[0].ToString();
                }
                if (values[1] != null)
                {
                    rf.room.Room.Availability = (bool)values[1];
                }
                if (values[2] != null)
                {
                    rf.Denumire.Add("Wi-Fi");
                }
                if (values[3] != null)
                {
                    rf.Denumire.Add("Bar");
                }
                if (values[4] != null)
                {
                    rf.Denumire.Add("Mini-frigider");
                }
                if (values[5] != null)
                {
                    rf.Denumire.Add("Panorama");
                }
                if (values[6] != null)
                {
                    rf.Denumire.Add("TV");
                }
                if (values[7] != null)
                {
                    rf.Denumire.Add("Curatenie");
                }
                if (values[8] != null)
                {
                    rf.Denumire.Add("Mic dejun");
                }
                if (values[9] != null)
                {
                    rf.Denumire.Add("Room service");
                }
                if (values[10] != null)
                {
                    rf.Denumire.Add("Bucatarie");
                }
                if (values[11] != null)
                {
                    rf.Denumire.Add("Pat dublu");
                }
                if (!string.IsNullOrEmpty(values[12].ToString()))
                    rf.room.Room.Price = float.Parse(values[12].ToString());
                else
                    rf.room.Room.Price = float.MaxValue;


                return rf;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}
