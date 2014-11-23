using GalaSoft.MvvmLight;
using GhulApp.Models;
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
                    Name = model.Name
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

    }
}
