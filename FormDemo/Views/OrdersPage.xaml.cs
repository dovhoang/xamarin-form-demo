using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FormDemo.Models;
using FormDemo.Services;
using FormDemo.Views;
using FormDemo.ViewModels;
using Xamarin.Essentials;

namespace FormDemo.Views
{
    public partial class OrdersPage
    {
        OrdersViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new OrdersViewModel();
            var itemWidth = (Application.Current.MainPage.Width / 5) - 20;
            
            Resources.Add("ItemWidth",itemWidth);

           
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            Connectivity.ConnectivityChanged += (sender, args) =>
            {
                DisplayAlert("Clicked!",
                    "The internet is" + (args.NetworkAccess == NetworkAccess.Internet ? "connected" : "disconnected"),
                    "OK");
            };
        }


        private void HorizontalListView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            
        }

        async void RequestPermission_OnClicked(object sender = null, EventArgs e = null)
        {
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                RequestPermission_OnClicked();
            }
            await DisplayAlert("Information",
                "Permission is accepted",
                "OK");
        }

        async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var button = (ToolbarItem)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }
        async void CheckInternet_OnClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Clicked!",
                "The internet is" + (Connectivity.NetworkAccess == NetworkAccess.Internet ? "connected" : "disconnected"),
                "OK");
        }
        
        async void DeviceInfo_OnClicked(object sender, EventArgs e)
        {
            IDevice device = DependencyService.Get<IDevice>();
            string deviceCode = device.GetDeviceCode();
            await DisplayAlert("Clicked!",
                "Device code: " + deviceCode ,
                "OK");
        }
        
    }
}
