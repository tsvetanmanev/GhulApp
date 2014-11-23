using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace GhulApp.Models
{
    [ParseClassName("Family")]
    public class FamilyModel : ParseObject
    {

        [ParseFieldName("Name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Address")]
        public AddressModel Address
        {
            get { return GetProperty<AddressModel>(); }
            set { SetProperty<AddressModel>(value); }
        }

        [ParseFieldName("AppartmentNumber")]
        public string AppartmentNumber
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("CollectedAmount")]
        public double Money
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("LastCollectedDate")]
        public DateTime LastCollectedDate
        {
            get { return GetProperty<DateTime>(); }
            set { SetProperty<DateTime>(value); }
        }

    }
}
