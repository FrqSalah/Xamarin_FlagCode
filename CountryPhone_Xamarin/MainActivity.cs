using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Runtime;

namespace CountryPhone_Xamarin
{
    [Activity(Label = "Phone code", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : AppCompatActivity
    {
        public CountryData cCoutnries = new CountryData();
        private SearchView _serachView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Récupération des identifiants
            var countriesListView = FindViewById<ListView>(Resource.Id.cListe);

            //Evenement click sur élément de la liste
            countriesListView.ItemClick += OnItemClick;
            countriesListView.FastScrollEnabled = true;
            // Création de l'adapter pour la listeView
            var adapter = new CountryAdapter(this, cCoutnries.Countries);
            countriesListView.Adapter = adapter;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.top_menu, menu);
            var item = menu.FindItem(Resource.Id.Search24);

            var searchView = MenuItemCompat.GetActionView(item);
            _serachView = searchView.JavaCast<SearchView> ();

            //_serachView.QueryTextChange += (s,e) => 
            return base.OnCreateOptionsMenu(menu);
        }

        private void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var country = cCoutnries.Countries[e.Position];

            var dialog = new Android.Support.V7.App.AlertDialog.Builder(this);
            dialog.SetMessage(country.cName+"/"+country.cIso+"/"+country.cCodeStr);
            dialog.SetNeutralButton("OK", delegate { });
            dialog.Show();
        }
    }
}

