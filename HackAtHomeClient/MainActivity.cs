using Android.App;
using Android.Widget;
using Android.OS;

namespace HackAtHomeClient
{
    [Activity(Label = "Hack@Home", MainLauncher = true, Icon = "@drawable/iconAndroid", Theme = "@android:style/Theme.Holo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            FindViewById<Button>(Resource.Id.buttonValidar).Click += (sender, e) =>
            {            
                var ActivityIntent = new Android.Content.Intent(this, typeof(Evidencias));
                StartActivity(ActivityIntent);
            };
        }
    }
}

