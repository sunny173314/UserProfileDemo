using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDF : ContentPage
    {
        public PDF()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CheckConectivity();
            Navigation.PushAsync(new PDFViewer());

        }

        private async void OnOpenViewerButtonClicked(object sender, EventArgs e)
        {
         
            await Navigation.PushAsync(new ViewerPage());
        }

        private void CheckConectivity()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Message", "Please Wait Pdf Is Loading", "Ok");
            }
            else
            {
                DisplayAlert("Message", " No Internet Available", "Ok");
            }
        }
    }
}