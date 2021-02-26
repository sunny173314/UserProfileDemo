using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
    public partial class MobileGrid : ContentPage
    {
        private const int MaxColumns = 3;

        private double _rowHeight = 0;
        private int _currentRow = 0;
        private int _currentColumn = 0;
        public MobileGrid()
        {
            InitializeComponent();
            
            Device.BeginInvokeOnMainThread(async () => await InitialiseMediaPermissions());

            var addPhotoButton = new Button()
            {
                Text = "Add Photo",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BorderColor = Color.FromHex("#F0F0F0"),
                BorderWidth = 1,
                BackgroundColor = Color.FromHex("#F9F9F9"),
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold
            };

            addPhotoButton.Clicked += async (object sender, EventArgs e) => await AddPhoto();

            ImageGridContainer.Children.Add(addPhotoButton, 0, 0);

            Device.BeginInvokeOnMainThread(async () =>
            {
                // Wait for a small amount of time so the UI has a chance to update the relevant values
                // we need to complete the operation.
                await Task.Delay(10);

                // Set the row height to be the same as the column width so that the image 
                // is presented in a square grid.
                _rowHeight = addPhotoButton.Width;
                ImageGridContainer.RowDefinitions[0].Height = _rowHeight;

                await ImageGridContainer.FadeTo(1);
            });
        }

        async Task AddPhoto()
        {
            MediaFile file = null;

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "You need to fix the problem of camera availability", "OK");
                return;
            }

            var imageSource = await DisplayActionSheet("Image Source", "Cancel", null, new string[] { "Camera", "Photo Gallery" });
            var photoName = Guid.NewGuid().ToString() + ".jpg";

            switch (imageSource)
            {
                case "Camera":
                    file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = photoName,
                        SaveToAlbum = true
                    });

                    break;

                case "Photo Gallery":
                    file = await CrossMedia.Current.PickPhotoAsync();

                    break;

                default:
                    break;
            }

            if (file == null)
                return;

            // We have the photo, now add it to the grid.
            _currentColumn++;

            if (_currentColumn > MaxColumns - 1)
            {
                _currentColumn = 0;
                _currentRow++;

                // Add a new row definition by copying the first row.
                ImageGridContainer.RowDefinitions.Add(ImageGridContainer.RowDefinitions[0]);
            }

            var newImage = new Image()
            {
                Source = ImageSource.FromFile(file.Path),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Aspect = Aspect.AspectFill,
                Scale = 0
            };

            ImageGridContainer.Children.Add(newImage, _currentColumn, _currentRow);

            await Task.Delay(250);

            await newImage.ScaleTo(1, 250, Easing.SpringOut);
        }

        [Obsolete]
        async Task InitialiseMediaPermissions()
        {
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }
        }
    }
}