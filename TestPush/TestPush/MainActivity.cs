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
            //MobileCenter.SetLogUrl("https://in-staging-south-centralus.staging.avalanch.es");

            // This should come before MobileCenter.Start() is called
            Push.PushNotificationReceived += (sender, e) => {

                // Add the notification message and title to the message
                var summary = $"Push notification received:"+$"\n\tNotification title: {e.Title}" +
                            $"\n\tMessage: {e.Message}";

                // If there is custom data associated with the notification,
                // print the entries
                if (e.CustomData != null)
                {
                    summary += "\n\tCustom data:\n";
                    foreach (var key in e.CustomData.Keys)
                    {
                        summary += $"\t\t{key} : {e.CustomData[key]}\n";
                    }
                }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
            };

            string temp=MobileCenter.InstallId.ToString();

            Push.Enabled = true;

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Push.EnableFirebaseAnalytics();
            MobileCenter.Start("a6c3e682-15b7-4925-9386-1e39881a8fd3", 
                   typeof(Analytics), typeof(Crashes), typeof(Push));
            
        }
    }
}

