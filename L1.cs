using Android.App;
using Android.OS;
using Android.Widget;

namespace TrialTeacher
{
    [Activity(Label = "L1")]
    public class L1 : Activity
    {
        private TextView tv1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.L1);
            tv1 = FindViewById<TextView>(Resource.Id.textView1);
            tv1.Text = "Reached here";
            // Create your application here
        }
    }
}