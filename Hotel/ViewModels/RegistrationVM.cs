using Hotel.Models.BusinessLogicLayer;
using Hotel.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Hotel.ViewModels.Command;

namespace Hotel.ViewModels
{
    class RegistrationVM : BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();

        public RegistrationVM()
        {
            userList = userBLL.GetAllPersons();

        }
        public ObservableCollection<UserRegistration> userList
        {
            get => userBLL.userList;
            set => userBLL.userList = value;
        }

        private ICommand register;
        public ICommand Register
        {
            get
            {
                if (register == null)
                {
                    register = new RelayCommand<UserRegistration>(userBLL.AddPerson);
                }
                return register;
            }
        }

        private ICommand cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand<object>(CancelFunction);
                }
                return cancelCommand;
            }
        }

        public void CancelFunction(object parameter)
        {
            Window win = parameter as Window;
            win.Close();
        }

    }
}
