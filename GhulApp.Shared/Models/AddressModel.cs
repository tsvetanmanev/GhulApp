using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhulApp.Models
{
    [ParseClassName("Addresses")]
    public class AddressModel : ParseObject
    {
        [ParseFieldName("Name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Address")]
        public string AddressText
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Geolocation")]
        public ParseGeoPoint GeoLocation
        {
            get { return GetProperty<ParseGeoPoint>(); }
            set { SetProperty<ParseGeoPoint>(value); }
        }

        [ParseFieldName("TreasuryAmount")]
        public double TreasuryAmount
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("Families")]
        public IEnumerable<FamilyModel> Families
        {
            get { return GetProperty<IEnumerable<FamilyModel>>(); }
            set { SetProperty<IEnumerable<FamilyModel>>(value); }
        }

        [ParseFieldName("Goals")]
        public IEnumerable<GoalModel> Goals
        {
            get { return GetProperty<IEnumerable<GoalModel>>(); }
            set { SetProperty<IEnumerable<GoalModel>>(value); }
        }
    }
}
