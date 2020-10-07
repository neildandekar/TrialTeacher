using Android.App;
using Android.OS;
using Android.Widget;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;

namespace TrialTeacher
{
    [Activity(Label = "L1")]
    public class L1 : Activity
    { 
        public IList <string> words { get; private set; }
        private ListView lv1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L1);
            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            words = new List<string>();
            words.Add("कमल");
            words.Add("विमल");
            words.Add("धवल");
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, words);
            lv1.Adapter = adapter;
        }
    }
}