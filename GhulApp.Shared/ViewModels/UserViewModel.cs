using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhulApp.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
