using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using FormDemo.Droid;
using FormDemo.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDevice))]
namespace FormDemo.Droid
{
    [Activity(Label = "FormDemo", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
    
    public class AndroidDevice : IDevice
    {
        public string GetDeviceCode()
        {
            try
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                {
                    return Build.Serial ?? string.Empty;
                }
                else
                {
                    return Build.GetSerial() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return string.Empty;
        }
    }
}
