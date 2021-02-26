﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserProfileDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardMaster : ContentPage
    {
        public ListView ListView;

        public DashboardMaster()
        {
            InitializeComponent();

            BindingContext = new DashboardMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DashboardMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DashboardMasterMenuItem> MenuItems { get; set; }

            public DashboardMasterViewModel()
            {
                MenuItems = new ObservableCollection<DashboardMasterMenuItem>(new[]
                {
                     new DashboardMasterMenuItem { Id = 0,  Title = "User" , Icon= "user" ,TargetType=typeof(UserProfilePage) },                    
                     new DashboardMasterMenuItem { Id = 1, Title = "PDF" , Icon= "pdf" , TargetType=typeof(PDF) },
                     new DashboardMasterMenuItem { Id = 2, Title = "Photo Grid" , Icon= "pixels" , TargetType=typeof(MobileGrid) },
                     new DashboardMasterMenuItem { Id = 3, Title = "AppInfo" , Icon= "device" , TargetType=typeof(AppInfoPage) },
                   // new DashboardMasterMenuItem { Id = 0, Title = "Page 1" },
                    //new DashboardMasterMenuItem { Id = 1, Title = "Page 2" },
                    //new DashboardMasterMenuItem { Id = 2, Title = "Page 3" },
                    //new DashboardMasterMenuItem { Id = 3, Title = "Page 4" },
                    //new DashboardMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}