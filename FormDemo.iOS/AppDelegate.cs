using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FormDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        
        // Ref https://stackoverflow.com/questions/69630728/xamarin-forms-ios-navigation-bar/69639947#69639947
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new App());

            var checkSystem = UIDevice.CurrentDevice.CheckSystemVersion(15, 0);
            if (checkSystem)
            {
                var appearance = new UINavigationBarAppearance();
                appearance.ConfigureWithOpaqueBackground();
                
                appearance.BackgroundColor = UIColor.SystemBlueColor;
                appearance.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White};
                
                
                UINavigationBar.Appearance.StandardAppearance = appearance;
                UINavigationBar.Appearance.CompactAppearance = appearance;
                UINavigationBar.Appearance.ScrollEdgeAppearance = appearance;
            }

            return base.FinishedLaunching(app, options);
        }
    }
}
