using Android.App;
using Android.Widget;
using Android.OS;

namespace CountryPhone_Xamarin
{
    [Activity(Label = "CountryPhone_Xamarin", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            var countriesListView = FindViewById<ListView>(Resource.Id.listView1);
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, CountryData.Countries);

            countriesListView.Adapter = adapter;

        }
    }
}

