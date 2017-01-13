using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace CountryPhone_Xamarin
{
    [Activity(Label = "Countries Phone code", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public CountryData cCoutnries = new CountryData();
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Récupération des identifiants
            var countriesListView = FindViewById<ListView>(Resource.Id.cListe);

            //Evenement click sur élément de la liste
            countriesListView.ItemClick += OnItemClick;

            // Création de l'adapter pour la listeView
            var adapter = new CountryAdapter(this, cCoutnries.Countries);
            countriesListView.Adapter = adapter;

        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var country = cCoutnries.Countries[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetMessage(country.cName+"/"+country.cIso+"/"+country.cCodeStr);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}

