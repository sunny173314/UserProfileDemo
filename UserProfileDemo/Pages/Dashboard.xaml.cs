using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileDemo.Core;
using UserProfileDemo.Core.Respositories;
using UserProfileDemo.Core.Services;
using UserProfileDemo.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : MasterDetailPage
    {
        public Dashboard(Action logoutSuccesful)
        {
            InitializeComponent();
            var userProfileRepository = ServiceContainer.Resolve<IUserProfileRepository>();
            var alertService = ServiceContainer.Resolve<IAlertService>();
            var mediaService = ServiceContainer.Resolve<IMediaService>();

            BindingContext = new UserProfileViewModel(userProfileRepository, alertService, mediaService, logoutSuccesful);

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;

        }

        

        public Action OnLogoutSuccesful { get; }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as DashboardMasterMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}