using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ScannerMot.Droid
{
    [Activity(Label = "ScannerMot", Icon = "@drawable/ic_launcher", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            ActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));
        }
    }
}

