using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AlaskaXC.Droid.Views
{
    [Activity(Label = "AlaskaXC", MainLauncher = true, Icon = "@mipmap/icon")]
    public class FirstActivity : Activity
    {
        private Button goButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_first);

            goButton = FindViewById<Button>(Resource.Id.goButton);

            goButton.Click += GoButton_Click; ;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            Intent secondActivityIntent = new Intent(this, typeof(SecondActivity));
            StartActivity(secondActivityIntent);
        }
    }
}