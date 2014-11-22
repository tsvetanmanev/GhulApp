using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GhulApp.Models
{
    public enum Initiative
    {
        Software,
        SchoolAcademy,
        AlgoAcademy,
        KidsAcademy,
        Any
    }

    public enum Season
    {
        Season2010,
        Season2011,
        Season2012,
        Season2013,
        Season2014,
        Any
    }


    public class CategoryModel : ParseObject
    {
        [ParseFieldName("initiative")]
        public Initiative Initiative
        {
            get { return GetProperty<Initiative>(); }
            set { SetProperty<Initiative>(value); }
        }

        [ParseFieldName("season")]
        public Season Season
        {
            get { return GetProperty<Season>(); }
            set { SetProperty<Season>(value); }
        }
    }
}
