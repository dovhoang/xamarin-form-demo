using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using FormDemo.iOS;
using FormDemo.Services;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(IOSDevice))]

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
                appearance.TitleTextAttributes = new UIStringAttributes() {ForegroundColor = UIColor.White};


                UINavigationBar.Appearance.StandardAppearance = appearance;
                UINavigationBar.Appearance.CompactAppearance = appearance;
                UINavigationBar.Appearance.ScrollEdgeAppearance = appearance;
            }

            return base.FinishedLaunching(app, options);
        }
    }

    public class IOSDevice : IDevice
    {
        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        private static extern uint IOServiceGetMatchingService(uint masterPort, IntPtr matching);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        private static extern IntPtr IOServiceMatching(string s);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        private static extern IntPtr IORegistryEntryCreateCFProperty(uint entry, IntPtr key, IntPtr allocator,
            uint options);

        [DllImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
        private static extern int IOObjectRelease(uint o);

        public string GetDeviceCode()
        {
            string serial = string.Empty;
            uint platformExpert = IOServiceGetMatchingService(0, IOServiceMatching("IOPlatformExpertDevice"));
            if (platformExpert != 0)
            {
                NSString key = (NSString) "IOPlatformSerialNumber";
                IntPtr serialNumber = IORegistryEntryCreateCFProperty(platformExpert, key.Handle, IntPtr.Zero, 0);
                if (serialNumber != IntPtr.Zero)
                {
                    serial = NSString.FromHandle(serialNumber);
                }

                IOObjectRelease(platformExpert);
            }

            return serial;
        }
    }
}
