using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FormDemo.Models;
using FormDemo.Views;
using FormDemo.ViewModels;

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
        }

        private void HorizontalListView_OnScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            
        }

        async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            var button = (ToolbarItem)sender;
            await DisplayAlert("Clicked!",
                "The button labeled '" + button.Text + "' has been clicked",
                "OK");
        }
    }
}
