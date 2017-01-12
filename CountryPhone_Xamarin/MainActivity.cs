using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CountryPhone_Xamarin
{
    [Activity(Label = "Countries Phone code", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            CountryData cdate = new CountryData();
            // Récupération des identifiants
            var countriesListView = FindViewById<ListView>(Resource.Id.listView1);

            // Cr"éation de l'adapter pour la listeView
            var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, cdate.Countries);

            countriesListView.Adapter = adapter;

        }
    }
}

