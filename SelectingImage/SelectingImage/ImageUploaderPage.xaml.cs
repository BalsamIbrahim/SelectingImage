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
    public partial class ImageUploaderPage : ContentPage
    {
        public ImageUploaderPage()
        {
            InitializeComponent();
        }

        public async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // establish communication between native project and media plugn
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
            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image, please try again ", "Ok");
            }
            selectedImage.Source = ImageSource.FromStream(() => SelectImageFile.GetStream());
        }
    }
}