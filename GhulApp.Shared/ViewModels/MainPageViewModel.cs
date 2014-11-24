using GalaSoft.MvvmLight;
using GhulApp.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.UI.Core;

namespace GhulApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool initializing;
        private ObservableCollection<AddressViewModel> addresses;
        private ParseGeoPoint userGeoPoint;

        public MainPageViewModel()
        {
            this.LoadLocation();
        }

        private async void LoadLocation()
        {
            Geolocator locator = new Geolocator();

            locator.DesiredAccuracy = PositionAccuracy.High;
            locator.MovementThreshold = 100;
            Geoposition position = await locator.GetGeopositionAsync();

            userGeoPoint = new ParseGeoPoint(position.Coordinate.Latitude, position.Coordinate.Longitude);

            this.LoadAddresses();
        }

        private async Task LoadAddresses()
        {
            this.Initializing = true;
            //TODO: Implement mazna loading animation

            var addresses = await new ParseQuery<AddressModel>()
                    .FindAsync();
            var c = 7;

            this.Addresses = addresses.AsQueryable()
                    .Select(AddressViewModel.FromModel);
            //var tempItems = Addresses;
            //Addresses = null;
            //Addresses = tempItems.OrderBy(a => a.GeoLocation.DistanceTo(userGeoPoint));

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
