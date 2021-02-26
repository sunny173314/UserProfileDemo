using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using UserProfileDemo.Core;
using UserProfileDemo.Core.Respositories;
using UserProfileDemo.Core.Services;
using UserProfileDemo.Core.ViewModels;
using UserProfileDemo.Models;
using Xamarin.Forms;

namespace UserProfileDemo.Pages
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "Xamcam";

        }
        public UserProfilePage(Action logoutSuccesful)
        {
            var userProfileRepository = ServiceContainer.Resolve<IUserProfileRepository>();
            var alertService = ServiceContainer.Resolve<IAlertService>();
            var mediaService = ServiceContainer.Resolve<IMediaService>();

            BindingContext = new UserProfileViewModel(userProfileRepository, alertService, mediaService, logoutSuccesful);

            // Set up in place of having a dependency on a DI solution
            
        }
        UserProfile userProfile = new UserProfile();

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            
        }



        //private async void BtnCam_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
        //        {
        //            DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
        //            Directory = "Xamarin",
        //            SaveToAlbum = true
        //        });

        //        if (photo != null)
        //            imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        //    }
        //}





    }
}
