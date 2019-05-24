using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SelectingImage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TackPhotoFromCam : ContentPage
    {
        public TackPhotoFromCam()
        {
            InitializeComponent();
            //CameraButton.Clicked += CameraButton_Clicked;
        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = "test.jpg"
            //});
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                SaveToAlbum=true
            });
            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");

            PhotoImage.Source = ImageSource.FromStream(() =>
            {
                return file.GetStream();
            });
            //var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            //if (photo != null)
            //    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            // take picture 
            // !Creoss.Current.ISCameraAvailable 
            // select picture
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Not Supported", "Your device does not currently support this functionality.", "Ok");
                return;
            }
            var MediaOption = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Custom,
                CustomPhotoSize = 92,
            };
            var SelectImageFile = await CrossMedia.Current.PickPhotoAsync(MediaOption);
            if (PhotoImage == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again ", "Ok");
            }
            PhotoImage.Source = ImageSource.FromStream(() => SelectImageFile.GetStream());
        }
    }
}