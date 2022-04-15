using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FormDemo.Models;
using Xamarin.Forms;

namespace FormDemo.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class LineItemViewModel : BaseViewModel
    {
        private string itemId;
        private string _name;
        private string description;
        private int heightRequest;

        public LineItemViewModel(LineItem lineItem)
        {
           
            Id = lineItem.Id;
            Name = lineItem.Name;
            Description = lineItem.Description;
        }
        
        public string Id { get; set; }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.CashierName;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
