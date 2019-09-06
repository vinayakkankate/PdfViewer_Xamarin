using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XamarinSample.Droid
{
    [Activity(Label = "XamarinSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int PERMISSION_REQUEST_CODE = 4500;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var listPermissions = new System.Collections.Generic.List<string>();


            if (CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                listPermissions.Add(Android.Manifest.Permission.WriteExternalStorage);
            }

            if (CheckSelfPermission(Android.Manifest.Permission.ReadExternalStorage) != Permission.Granted)
            {
                listPermissions.Add(Android.Manifest.Permission.ReadExternalStorage);
            }

            // Make the request with the permissions needed...and then check OnRequestPermissionsResult() for the results
            
            if(listPermissions!=null && listPermissions.Count!=0)
                RequestPermissions(listPermissions.ToArray(), PERMISSION_REQUEST_CODE);
           

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}