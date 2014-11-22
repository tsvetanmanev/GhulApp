using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using Parse;
using GhulApp.Common;
using System.Threading.Tasks;

namespace GhulApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public UserViewModel User { get; set; }

        public event EventHandler LoginSuccessfull;

        public LoginPageViewModel()
        {
            this.User = new UserViewModel()
            {
                Username = "Cecko",
                Password = "123456q"
            };
        }
        public async Task<bool> Login()
        {
            try
            {
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);
                //navigate to another page
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
