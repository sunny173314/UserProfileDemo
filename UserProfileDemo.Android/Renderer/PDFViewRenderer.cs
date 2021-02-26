﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserProfileDemo.Controls;
using UserProfileDemo.Droid.Renderer;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PDFView), typeof(PDFViewRenderer))]
namespace UserProfileDemo.Droid.Renderer
{
    class PDFViewRenderer: WebViewRenderer
    {


        public PDFViewRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Element.Navigated += Element_Navigated;

                var pdfView = Element as PDFView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                if (pdfView.IsPDF)
                {
                    var url = "https://drive.google.com/viewerng/viewer?embedded=true&url=" + pdfView.Uri;
                    ///var url = "https://docs.google.com/gview?embedded=true&url=" + pdfView.Uri;

                    Control.LoadUrl(url);
                }
                else
                {
                    Control.LoadUrl(pdfView.Uri);
                }

            }
        }

        private void Element_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Control.Title))
            {
                Control.Reload();
            }
        }

    }
}