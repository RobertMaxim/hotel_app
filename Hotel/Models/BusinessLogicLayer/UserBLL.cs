using Hotel.Models.DataAccessLayer;
using Hotel.Models.EntityLayer;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVMAgendaCommands.Exceptions;

namespace Hotel.Models.BusinessLogicLayer
{
    class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        public ObservableCollection<UserRegistration> userList { get; set; }
        public void AddPerson(UserRegistration user)
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.user.Username) || string.IsNullOrEmpty(user.user.Email) || string.IsNullOrEmpty(user.user.Password))
            {
                MessageBox.Show("Complete every textfield please!");
                //throw new ListException("Complete every textfield please!");
            }
            else
            {
                userDAL.AddPerson(user);
                userList.Add(user);
                MessageBox.Show("User added successfully");
            }
        }

        public ObservableCollection<UserRegistration> GetAllPersons()
        {
            return userDAL.GetAllPersons();
        }
        public void LogIntoAccount(UserLogin user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserType))
            {
                MessageBox.Show("Complete every textfield please!");
            }
            else
            {
                if (userDAL.LogIntoAccount(user))
                {
                    if (user.UserType == "Administrator")
                    {
                        SearchWindowAdmin swa = new SearchWindowAdmin();
                        swa.Show();
                    }
                    else if (user.UserType == "Utilizator Conectat")
                    {
                        SearchWindow sw = new SearchWindow();
                        sw.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Credentials are wrong.");
                }
            }
        }
    }
}
