using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FormDemo.Models;
using FormDemo.ViewModels;

namespace FormDemo.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Order Order { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
