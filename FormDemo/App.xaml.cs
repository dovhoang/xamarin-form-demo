using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormDemo.Services;
using FormDemo.Views;

namespace FormDemo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //
            // var stack = new StackLayout()
            // {
            //     Orientation = StackOrientation.Horizontal
            // };
            // grid.ColumnDefinitions.Add (new ColumnDefinition { Height = GridLength.Auto });
            // grid.ColumnDefinitions.Add (new ColumnDefinition { Height = new GridLength (1, GridUnitType.Star) });

            // var column = 4;
            // var itemWidth = (int) Current.MainPage.Width / column;
            

            // var stacklayout1 = new AbsoluteLayout() { WidthRequest = 100, HeightRequest = 100, BackgroundColor = Color.Red };
            // var stacklayout2 = new AbsoluteLayout {  WidthRequest = 200, HeightRequest = 200, BackgroundColor = Color.Blue };
            //
            // var boxView1 = new BoxView() {HeightRequest = 100, WidthRequest = 100};
            // var boxView2 = new BoxView() {HeightRequest = 200, WidthRequest = 200};
            //
            // // stack.Children.Add (stacklayout1);
            // // stack.Children.Add (stacklayout2);
            //
            // stack.Children.Add(boxView1);
            // stack.Children.Add(boxView2);
            //
            // MainPage = new ContentPage { Content = stack };  
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
