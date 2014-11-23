using GalaSoft.MvvmLight;
using GhulApp.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GhulApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool initializing;
        private ObservableCollection<AddressViewModel> addresses;

        public MainPageViewModel()
        {
            this.LoadAddresses();
        }

        private async Task LoadAddresses()
        {
            this.Initializing = true;
            var addresses = await new ParseQuery<AddressModel>()
                    .FindAsync();

            this.Addresses = addresses.AsQueryable()
                    .Select(AddressViewModel.FromModel);

            int ca = 5;

            this.Initializing = false;
        }

        public bool Initializing
        {
            get
            {
                return this.initializing;
            }
            set
            {
                this.initializing = value;
                this.RaisePropertyChanged(() => this.Initializing);
            }
        }

        public IEnumerable<AddressViewModel> Addresses
        {
            get
            {
                if (this.addresses == null)
                {
                    this.addresses = new ObservableCollection<AddressViewModel>();
                }
                 return this.addresses;
            }
            set
            {
                if (this.addresses == null)
                {
                    this.addresses = new ObservableCollection<AddressViewModel>();
                }
                this.addresses.Clear();
                foreach (var item in value)
                {
                    this.addresses.Add(item);
                }
            }
        }
    }
}
