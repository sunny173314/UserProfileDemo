using Android.App;
using Android.Content.PM;
using Android.OS;
using pdftron;
using Plugin.Connectivity;
using System;

namespace UserProfileDemo.Droid
{
    [Activity(Label = "UserProfileDemo", Icon = "@drawable/hacker", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            // tag::activate[]
            Couchbase.Lite.Support.Droid.Activate(this);
            // end::activate[]
            try
            {
                pdftron.PDF.Tools.Utils.AppUtils.InitializePDFNetApplication(this);
                Console.WriteLine(PDFNet.GetVersion());
            }
            catch (pdftron.Common.PDFNetException e)
            {
                Console.WriteLine(e.GetMessage());
                return;
            }
            LoadApplication(new App());
        }
    }
}
