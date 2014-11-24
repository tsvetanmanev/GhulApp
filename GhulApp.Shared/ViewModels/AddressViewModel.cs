using GalaSoft.MvvmLight;
using GhulApp.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GhulApp.ViewModels
{
    public class AddressViewModel : ViewModelBase
    {
        private string name;

        public static Expression<Func<AddressModel, AddressViewModel>> FromModel
        {
            get
            {
                return model => new AddressViewModel()
                {
                    Name = model.Name,
                    AddressText = model.AddressText,
                    TreasuryAmount = model.TreasuryAmount,
                    Families = model.Families,
                    Goals = model.Goals,
                    GeoLocation = model.GeoLocation
                };
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged(() => this.Name);
            }
        }


        public string AddressText { get; set; }

        public double TreasuryAmount { get; set; }

        public IEnumerable<FamilyModel> Families { get; set; }

        public IEnumerable<GoalModel> Goals { get; set; }

        public ParseGeoPoint GeoLocation { get; set; }
    }
}
