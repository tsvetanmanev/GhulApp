using GalaSoft.MvvmLight;
using GhulApp.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace GhulApp.ViewModels
{
    public class AddressDetailsPageViewModel : ViewModelBase
    {
        private AddressViewModel addressVM;
        private ObservableCollection<FamilyModel> families;

        public AddressDetailsPageViewModel()
        {
            //this.LoadFamilies();
        }

        public async Task LoadFamilies()
        {

            var currentAddress = this.Address;
            var families = await new ParseQuery<FamilyModel>()
                .FindAsync();
            this.Families = families.AsQueryable();

            var b = 5;
        }

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

        public IEnumerable<FamilyModel> Families
        {
            get
            {
                if (this.families == null )
                {
                    this.families = new ObservableCollection<FamilyModel>();
                }
                var b = 5;
                return this.families;
            }
            set
            {
                if (this.families == null)
                {
                    this.families = new ObservableCollection<FamilyModel>();
                }
                this.families.Clear();
                foreach (var item in value)
                {
                    this.families.Add(item);
                }
            }
        }
    }
}
