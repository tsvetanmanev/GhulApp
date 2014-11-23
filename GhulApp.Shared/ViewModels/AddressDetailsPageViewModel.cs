using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhulApp.ViewModels
{
    public class AddressDetailsPageViewModel : ViewModelBase
    {
        private AddressViewModel addressVM;

        public AddressViewModel Address
        {
            get
            {
                return this.addressVM;
            }
            set
            {
                this.addressVM = value;
                this.RaisePropertyChanged(() => this.Address);
            }
        }
    }
}
