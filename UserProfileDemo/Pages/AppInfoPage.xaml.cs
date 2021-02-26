using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppInfoPage : ContentPage
    {
        public AppInfoPage()
        {            
                InitializeComponent();
                PackageInfo.Text = $"PackageName: " + $"{AppInfo.PackageName}";
                AppVersion.Text = $"Version: " + $"{AppInfo.Version}";
                AppBuidInfo.Text = $"BuildString: " + $"{AppInfo.BuildString}";                
                ModelInfo.Text = $"BuildString: " + $"{DeviceInfo.Model}";
                Manufacturer.Text = $"BuildString: " + $"{DeviceInfo.Manufacturer}";
                DeviceType.Text = $"BuildString: " + $"{DeviceInfo.DeviceType}";
                Platform.Text = $"BuildString: " + $"{DeviceInfo.Platform}";
                AppInfoName.Text = $"Name: " + $"{AppInfo.Name}";            
        }
    }
}