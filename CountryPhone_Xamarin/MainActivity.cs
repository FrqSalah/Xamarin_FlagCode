using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using Android.Runtime;

namespace CountryPhone_Xamarin
{
    [Activity(Label = "Phone code", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : AppCompatActivity
    {
        public CountryData cCoutnries = new CountryData();
        private Android.Support.V7.Widget.SearchView _serachView;
        //private CountryAdapter adapter;
        private ArrayAdapter adapter;
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

            var products = new[]
            {
                "Dell Inspiron", "HTC One X", "HTC Wildfire S", "HTC Sense", "HTC Sensation XE",
                "iPhone 4S", "Samsung Galaxy Note 800",
                "Samsung Galaxy S3", "MacBook Air", "Mac Mini", "MacBook Pro", "Dell Inspiron", "HTC One X", "HTC Wildfire S", "HTC Sense", "HTC Sensation XE",
                "Samsung Galaxy S3", "MacBook Air", "Mac Mini", "MacBook Pro", "Dell Inspiron"
            };

            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, products);
            //adapter = new CountryAdapter(this, cCoutnries.Countries);
            countriesListView.Adapter = adapter;

            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.top_menu, menu);

            var item = menu.FindItem(Resource.Id.Search);

            var searchView = (Android.Support.V7.Widget.SearchView)MenuItemCompat.GetActionView(item);

            //_serachView = searchView.JavaCast<SearchView>();

            searchView.QueryTextChange += (s, e) => adapter.Filter.InvokeFilter(e.NewText);
            searchView.QueryTextSubmit += (s, e) =>
            {
                //TODO: Do something fancy when search button on keyboard is pressed
                Toast.MakeText(this, "Searched for: " + e.Query, ToastLength.Short).Show();
                e.Handled = true;
            };

            return true;
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

