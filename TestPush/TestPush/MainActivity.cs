using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Microsoft.Azure.Mobile.Push;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile;

namespace TestPush
{
    [Activity(Label = "TestPush", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            MobileCenter.Start("a23996ab-2d7c-4f76-a847-06b3e580648b",
                   typeof(Analytics), typeof(Crashes), typeof(Push));
            Push.Enabled = true;
        }
    }
}

