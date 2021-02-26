using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace UserProfileDemo.Core.ViewModels
{
    class MainViewModel
    {
        Action SignInSuccessful { get; set; }



        public MainViewModel(Action signInSuccessful)
        {
            SignInSuccessful = signInSuccessful;
        }
    }
}
