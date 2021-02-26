using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UserProfileDemo.Core.Respositories;
using UserProfileDemo.Core.Services;
using UserProfileDemo.Models;
using Xamarin.Forms;
namespace UserProfileDemo.Core.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        Action LogoutSuccessful { get; set; }

        IUserProfileRepository UserProfileRepository { get; set; }
        IAlertService AlertService { get; set; }
        IMediaService MediaService { get; set; }

        // tag::userProfileDocId[]
        string UserProfileDocId => $"user::{AppInstance.User.Username}";
        // end::userProfileDocId[]

        string _name;
        public string FirstName
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value);
        }

        string _age;
        public string Age
        {

            get => _age;
            set => SetPropertyChanged(ref _age, value);
        }



        string _lastname;
        public string LastName
        {
            get => _lastname;
            set => SetPropertyChanged(ref _lastname, value);
        }

        string _email;
        public string Email
        {
            get => _email;
            set => SetPropertyChanged(ref _email, value);
        }

        string _address;
        public string Address
        {
            get => _address;
            set => SetPropertyChanged(ref _address, value);
        }
        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetPropertyChanged(ref _phoneNumber, value);
        }



        string _gender;
        public string Gender
        {
            get => _gender;
            set => SetPropertyChanged(ref _gender, value);
        }


        string _birhDate;
        public string BirhDate
        {
            get => _birhDate;
            set => SetPropertyChanged(ref _birhDate, value);
        }

        




        byte[] _imageData;
        public byte[] ImageData
        {
            get => _imageData;
            set => SetPropertyChanged(ref _imageData, value);
        }

        ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(async() => await Save());
                }

                return _saveCommand;
            }
        }

        ICommand _selectImageCommand;
        public ICommand SelectImageCommand
        {
            get
            {
                if (_selectImageCommand == null)
                {
                    _selectImageCommand = new Command(async () => await SelectImage());
                }

                return _selectImageCommand;
            }
        }

        ICommand _selectImgCommand;
        public ICommand SelectImgCommand
        {
            get
            {
                if (_selectImgCommand == null)
                {
                    _selectImgCommand = new Command(async () => await SelectImg());
                }

                return _selectImgCommand;
            }
        }

        ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new Command(Logout);
                }

                return _logoutCommand;
            }
        }
        
        public UserProfileViewModel(IUserProfileRepository userProfileRepository, IAlertService alertService, 
                                    IMediaService mediaService, Action logoutSuccessful)
        {
            UserProfileRepository = userProfileRepository;
            AlertService = alertService;
            MediaService = mediaService;
            LogoutSuccessful = logoutSuccessful;

            LoadUserProfile();
        }

        
        async void LoadUserProfile()
        {
            IsBusy = true;

            var userProfile = await Task.Run(() =>
            {
                // tag::getUserProfileUsingRepo[]
                var up = UserProfileRepository?.Get(UserProfileDocId);
                // end::getUserProfileUsingRepo[]

                if (up == null)
                {
                    up = new UserProfile
                    {
                        Id = UserProfileDocId,
                        Email = AppInstance.User.Username
                    };
                }
                //if (BirhDate != null)
                //{

                //    Age = DateTime.Now.Year - BirhDate.Year;
                //}
                return up;
            });
             
           
            if (userProfile != null)
            {
                

                FirstName = userProfile.FirstName;
                LastName = userProfile.LastName;
                Email = userProfile.Email;
                Address = userProfile.Address;
                PhoneNumber = userProfile.PhoneNumber;
                Gender = userProfile.Gender;
                BirhDate = userProfile. BirhDate;
                ImageData = userProfile.ImageData;


                
                //Age = userProfile.Age;


            }

            
             

            IsBusy = false;
        }

        
        Task Save()
        {




            var userProfile = new UserProfile
            {



                Id = UserProfileDocId,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Address = Address,
                PhoneNumber = PhoneNumber,
                Gender = Gender,
                BirhDate = BirhDate,
                ImageData = ImageData,
               
            };
            userProfile.Age = userProfile.Age;
            

            // tag::saveUserProfileUsingRepo[]
            bool? success = UserProfileRepository?.Save(userProfile);
            // end::saveUserProfileUsingRepo[]

            if (success.HasValue && success.Value)
            {
                return AlertService.ShowMessage(null, "Successfully updated profile!", "OK");
            }

            return AlertService.ShowMessage(null, "Error updating profile!", "OK");
        }

        async Task SelectImage()
        {
            UserProfileDemo.Models.UserProfile userProfile = new UserProfile();
            var imageData = await MediaService.PickPhotoAsync();

            if (imageData != null)
            {
                ImageData = imageData;
            }


           

        }

        async Task SelectImg()
        {
            //var photo = await MediaService.TakePhotoAsync();
            //if (photo != null)
            //{
            //    photo = ImageData;
            //}

            var imageData = await MediaService.TakePhotoAsync();

            if (imageData != null)
            {
                ImageData = imageData;
            }


            //if (photo != null)
            //    // imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            //    ImageData=photo;

        }


        void Logout()
        {
            UserProfileRepository.Dispose();
           
            AppInstance.User = null;

            LogoutSuccessful?.Invoke();
            LogoutSuccessful = null;
        }


    }
}
