using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FormDemo.Models;
using FormDemo.Views;

namespace FormDemo.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private Order _selectedOrder;

        public ObservableCollection<OrderItemViewModel> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Order> ItemTapped { get; }
        
        public double ItemWidth { get; set; }

        public OrdersViewModel()
        {
            Title = "Order";
            Items = new ObservableCollection<OrderItemViewModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<Order>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
            
            LoadItemsCommand.Execute(this);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    var totalPage = item.TotalItems / AppConstants.MaxLineItemInOrder + 
                                    (item.TotalItems % AppConstants.MaxLineItemInOrder == 0 ? 0 : 1);
                    for (var i = 0; i < totalPage; i++)
                    {

                        Items.Add(new OrderItemViewModel(item, totalPage, i));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedOrder = null;
        }
        
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Order order)
        {
            if (order == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(OrderItemViewModel.ItemId)}={order.Id}");
        }
    }
}
