using Hotel.Models.BusinessLogicLayer;
using Hotel.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hotel.ViewModels.Command;

namespace Hotel.ViewModels
{
    class LoginVM:BasePropertyChanged
    {
        UserBLL userBLL = new UserBLL();



        private ICommand loginCommand;
        public ICommand LoginCommand {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand<UserLogin>(userBLL.LogIntoAccount);
                }
                return loginCommand;
            }
        }

    }
}
