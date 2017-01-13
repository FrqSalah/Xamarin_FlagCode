using Android.Content.Res;
using System.Collections.Generic;
using System.IO;

namespace CountryPhone_Xamarin
{
    public class CountryData
    {
        public List<Country> Countries { get; private set; }

        public CountryData()
        {
            var temp = new List<Country>();
            // Charger le fichier dans le stream
            var stream = Android.App.Application.Context.Assets.Open("countries.dat");

            // OUvrir le fichier pour le lire ligne par ligne
            using (StreamReader r = new StreamReader(stream))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    // Créer un objet Country
                    Country temp_country = new Country(line);
                    // Ajouter l'objet à la liste
                    temp.Add(temp_country);
                }
            }

            Countries = temp;
        }
        public void setCountries(Country temp)
        {
            Countries.Add(temp);
        }
    }
}