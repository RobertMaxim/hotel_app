using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.EntityLayer
{
    class User:BasePropertyChanged
    {
        private Int64 userID;
        public Int64 UserID {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                NotifyPropertyChanged("PersonID");
            }
        }
        private string username;
        public string Username {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private int typeID;
        public int TypeID
        {
            get
            {
                return typeID;
            }
            set
            {
                typeID = value;
                NotifyPropertyChanged("TypeID");
            }
        }
    }
}
