using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using Java.IO;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using File = System.IO.File;

namespace TrialTeacher 
{
    [Activity(Label = "L1")]
    public class L1 : Activity
    { 
        private IList <string> words { get; set; }
        private ListView lv1;
        private byte[] snd_arr1;
        private ImageView iv1;
        private Button buttonPlay;
        private MediaPlayer mediaPlayer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L1);
            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            iv1 = FindViewById<ImageView>(Resource.Id.imageView1); //iv and lv are confusing to be changed later.
            buttonPlay = FindViewById<Button>(Resource.Id.buttonPlay);
            words = new List<string>();
            words.Add("कमल");
            words.Add("विमल");
            words.Add("धवल");
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, words);
          
            lv1.Adapter = adapter;
            lv1.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                //Hardcoded for now for demo. Whatever be the selection it will always show kamal
                string temp = ((TextView)args.View).Text;
                if (lv1.SelectedItem != null) lv1.GetChildAt(args.Position).SetBackgroundColor(Android.Graphics.Color.White);
                getImage();
                getSound();
            };
            buttonPlay.Click += delegate
            {
                playSound();
            };

        }
        private void getImage()
        {
            SQLiteDatabaseOperations sdb = new SQLiteDatabaseOperations();
            byte[] img_arr1 = sdb.getImage("कमल");
            Android.Graphics.Bitmap bitmap = BitmapFactory.DecodeByteArray(img_arr1, 0, img_arr1.Length);
            iv1.SetImageBitmap(bitmap);
        }
        private void getSound()
        {
            SQLiteDatabaseOperations sdb = new SQLiteDatabaseOperations();
            snd_arr1 = sdb.getSound("कमल");
            int i = 10;
             string cd = Application.CacheDir.Path + "/" + "temp.mp3";
            try
            {
                BinaryWriter w = new BinaryWriter(File.OpenWrite(@cd));
                w.Write(snd_arr1);
                return;
            }

            catch (Exception e)
            {
                return;
            }

        }
        private void playSound()
        {
            try
            {
                if (mediaPlayer == null)
                {
                    mediaPlayer = new MediaPlayer();
                }
                FileOutputStream fos = new FileOutputStream(Application.CacheDir.Path + "/" + "temp.mp3");
                fos.Write(snd_arr1);
                fos.Close();

                mediaPlayer.Reset();

                mediaPlayer.SetDataSource(Application.CacheDir.Path + "/" + "temp.mp3");

                mediaPlayer.Prepare();
                mediaPlayer.Start();
            }
            catch (Exception ex)
            {
                String s = ex.ToString();
            }
        }

    }
}