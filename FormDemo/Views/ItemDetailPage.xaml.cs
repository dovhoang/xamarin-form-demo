using System.ComponentModel;
using Xamarin.Forms;
using FormDemo.ViewModels;

namespace FormDemo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new OrderDetailViewModel();
        }
    }
}
