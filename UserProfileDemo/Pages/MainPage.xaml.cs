using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UserProfileDemo.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            AnimateCarousal();
          
        }


        
        Timer timer;

       

        private void AnimateCarousal()
        {
            timer = new Timer(7000) { AutoReset = true, Enabled = true };
            timer.Elapsed += (s, e) =>
            {
                if (BgVideo.CurrentState != MediaElementState.Playing)

                    BgVideo.Play();
                Device.BeginInvokeOnMainThread(() => {
                    if (cvOnboarding.Position == 2)
                    {
                        cvOnboarding.Position = 0;
                        return;
                    }
                    cvOnboarding.Position += 1;
                });

            };


        }

        private void Login_Click(object sender, EventArgs e)
        {
                Navigation.PushAsync(new LoginPage(OnSignInSuccessful));
            void OnSignInSuccessful()=> Navigation.PushAsync(new Dashboard(OnLogoutSuccesful));
            //void OnSignInSuccessful() => MainPage = new NavigationPage(new UserProfilePage(OnLogoutSuccesful));

            void OnLogoutSuccesful() => Navigation.PushAsync(new  LoginPage(OnSignInSuccessful));
        }

      

        //public MainPage(Action signInSuccessful)
        //{
        //    Navigation.PushAsync(new LoginPage(signInSuccessful));
        //}

        //public void Login_click(object sender, EventArgs e, Action OnSignInSuccessful)
        //{
        //    Navigation.PushAsync(new LoginPage(OnSignInSuccessful));

        //}

        //private async void Login_Click(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ());
        //}

        //private void Login_click(object sender, EventArgs e, Action signInSuccessful)
        //{
        //    Navigation.PushModalAsync(new LoginPage(signInSuccessful));
        //}
    }
}