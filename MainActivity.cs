using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.Res;
using System.IO;
using System;
using Android.Webkit;
using Android.Database.Sqlite;

namespace TrialTeacher
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        DBHelper db;
        SQLiteDatabase sqliteDB;
        private Button buttonOk;
        private WebView webView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            convert();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            buttonOk = FindViewById<Button>(Resource.Id.buttonOk);
            webView1 = FindViewById<WebView>(Resource.Id.webView1);
            var htmlText = "<body><h1>Hindi Games/हिंदी भाषा खेलखेलमे!</h1><p>" +
            "We have noticed that the current way of teaching in schools leave many children struggling in mastering basic skills of हिंदी भाषा.<p>" +
            "This application is intended for Jr Kg, Sr Kg and the first standard students to understand the basics of हिंदी भाषा.<p>" +
            "Turning a learning task into gaming fun is very effective in teaching the young minds.<p>" +
            "<b> This is no substitute for the schools and textbooks</b>It is just an attempt to make the learning fun for the young minds.</body>";
            webView1.LoadDataWithBaseURL("blarg://ignored", htmlText, "text/html", "utf-8", null);
            buttonOk.Click += delegate
            {
                StartActivity(typeof(L1));
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void convert()
        {
        }
    }
}