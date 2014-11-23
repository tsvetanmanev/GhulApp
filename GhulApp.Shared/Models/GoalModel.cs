using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhulApp.Models
{
    [ParseClassName("Goals")]
    public class GoalModel : ParseObject
    {
        [ParseFieldName("Name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("Cost")]
        public double Cost
        {
            get { return GetProperty<double>(); }
            set { SetProperty<double>(value); }
        }

        [ParseFieldName("Address")]
        public AddressModel Address
        {
            get { return GetProperty<AddressModel>(); }
            set { SetProperty<AddressModel>(value); }
        }
    }
}
