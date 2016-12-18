using Android.App;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using HockeyApp;
using System.Collections.Generic;

namespace HockeyAppXamarin
{
    [Activity(Label = "HockeyAppXamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btn;
        Application ap;
        TextView tv;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            ap = this.Application;
            HockeyApp.Android.CrashManager.Register(this, "App-Id-Here");
            FeedbackManager.Register(this, "App-Id-Here");
            SetContentView(Resource.Layout.Main);


            string asdsd = null;
            btn = FindViewById<Button>(Resource.Id.myButton);
            btn.Click += delegate
            {
                HockeyApp.MetricsManager.TrackEvent(
                    "Custom Event",
                    new Dictionary<string, string> { { "property", "value" } },
                    new Dictionary<string, double> { { "time", 1.0 } }
                    );
                FeedbackManager.ShowFeedbackActivity(this);
                HockeyApp.MetricsManager.TrackEvent("Cust");
                btn.Text = asdsd;
                tv.Text = asdsd;

            };
            CheckForUpdates();
        }

        void CheckForUpdates()
        {
            // Remove this for store builds!
            UpdateManager.Register(this, "App-Id-Here");
        }

        void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterManagers();
        }
    }
}

