using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.Res;
using System.IO;
using System;

namespace TrialTeacher
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button buttonOk;
        private TextView textView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            convert();
            buttonOk = FindViewById<Button>(Resource.Id.buttonOk);
            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = "Blah, blah ,blah";
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void convert()
        {
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("DBCOPY.txt")))
            {
                content = sr.ReadToEnd();
            }
            var sqliteFilename = "hottots.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            // This is where we copy in our pre-created database
            if (!File.Exists(path) || content.Equals("FORCE"))
            {
                try
                {
                    AssetManager asset = this.Assets;
                    using (var binaryReader = new BinaryReader(asset.Open(sqliteFilename)))
                    {
                        using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                        {
                            byte[] buffer = new byte[2048];
                            int length = 0;
                            while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                binaryWriter.Write(buffer, 0, length);
                            }
                        }
                        Toast.MakeText(Application.Context, "Converted DB", ToastLength.Short).Show();
                    }
                }
                catch (Exception e)
                {
                    Toast.MakeText(Application.Context, "Could not convert the db", ToastLength.Short).Show();
                    return;
                }
            }
            return;
        }
    }
}