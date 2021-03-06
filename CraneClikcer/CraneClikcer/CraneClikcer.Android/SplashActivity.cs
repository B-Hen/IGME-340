using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraneClikcer.Droid
{
    [Activity(Label = "Crane Clicker", MainLauncher =true, Theme ="@style/Theme.Splash", NoHistory =true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startUpWork = new Task(() => { SimulateStartUp(); });
            startUpWork.Start();
        }

        async void SimulateStartUp()
        {
            await Task.Delay(4000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public override void OnBackPressed() {}
    }
}