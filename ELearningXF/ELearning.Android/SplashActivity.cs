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

namespace ELearning.Droid
{
    //[Activity(Label = "SplashActivity")]
    [Activity(Theme = "@style/Them.Splash",
        MainLauncher = true,
        NoHistory = true,
        Icon = "@drawable/splash_screen")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(2000);
            StartActivity(typeof(MainActivity));
        }
    }
}