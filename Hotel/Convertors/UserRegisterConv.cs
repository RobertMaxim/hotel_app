using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Hotel.Convertors
{
    class UserRegisterConv : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null)
            {
                return new UserRegistration()
                {
                    FirstName = values[0].ToString(),
                    LastName = values[1].ToString(),
                    user = new User()
                    {
                        Username = values[2].ToString(),
                        Password = (values[3] as System.Windows.Controls.PasswordBox).Password.ToString(),
                        Email = values[4].ToString()
                    }
                };
            }
            return null;
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
