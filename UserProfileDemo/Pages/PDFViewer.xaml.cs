using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PDFViewer : ContentPage
    {
        string url = "https://www.tutorialspoint.com/xamarin/xamarin_tutorial.pdf";
        public PDFViewer()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                pdfView.Uri = url;
                pdfView.On<Android>().EnableZoomControls(true);
                pdfView.On<Android>().DisplayZoomControls(false);
            }

            else
                pdfView.Source = url;
        }

    }
}