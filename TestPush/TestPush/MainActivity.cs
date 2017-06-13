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
            MobileCenter.SetLogUrl("https://in-staging-south-centralus.staging.avalanch.es");

            Push.Enabled = true;

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            MobileCenter.Start("f7c0c80d-2b7c-4e18-b57b-348733360240", 
                   typeof(Analytics), typeof(Crashes), typeof(Push));
            
        }
    }
}

