using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Permissions;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using System.IO;

namespace SelectingImage.Droid
{
    [Activity(Label = "SelectingImage", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        //static int REQUEST_IMAGE_CAPTURE = 1;

        //private void dispatchTakePictureIntent()
        //{
        //    Intent takePictureIntent = new Intent(MediaStore.ActionImageCapture);
        //    if (takePictureIntent.ResolveActivity(PackageManager) != null)
        //    {
        //        StartActivityForResult(takePictureIntent, REQUEST_IMAGE_CAPTURE);
        //    }
        //}
    }
}