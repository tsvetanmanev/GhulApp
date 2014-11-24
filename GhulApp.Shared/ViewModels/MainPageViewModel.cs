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
                    .OrderBy(a => distance(a.GeoLocation.Latitude, a.GeoLocation.Longitude, userGeoPoint.Latitude, userGeoPoint.Longitude, 'K'))
                    .Select(AddressViewModel.FromModel);

            this.Initializing = false;
        }


        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;

            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }

            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
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
