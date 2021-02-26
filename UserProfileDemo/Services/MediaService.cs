using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using UserProfileDemo.Core.Services;

namespace UserProfileDemo.Services
{
    public class MediaService : IMediaService
    {
       

        //public async Task<byte[]> TakePhotoAsync()
        //{
        //    var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
        //    {
        //        DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
        //        Directory = "/Internal Storage/Download",
        //        SaveToAlbum = true
        //    });
        //    return photo != null ? GetBytesFromStream(photo.GetStream()): null;
        //}
        public async Task<byte[]> PickPhotoAsync()
        {
            var result = await CrossMedia.Current.PickPhotoAsync();
            return result != null ? GetBytesFromStream(result.GetStream()) : null;
        }

        public async Task<byte[]> TakePhotoAsync()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                Directory = "Xamarin",
                SaveToAlbum = true
            });

            return photo != null ? GetBytesFromStream(photo.GetStream()) : null;
        }

        //public async Task<byte[]> TakePhotoAsync()
        //{
        //    var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
        //    {
        //        DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
        //        //Directory = "Xamarin",
        //        SaveToAlbum = true
        //    });
        //    return photo != null ? GetBytesFromStream(photo.GetStream()) : null;
        //}

        byte[] GetBytesFromStream(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}