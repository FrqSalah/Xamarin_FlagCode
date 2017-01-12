using System.Collections.Generic;
using System.IO;

public class CountryData
{
    public static List<Country> Countries { get; private set; }

    static CountryData ()
    {
        var temp = new List<Country>();
        var text = File.ReadAllLines("Assets/countries.dat");
        foreach(var line in text)
        {
            Country temp_country = new Country(line);
            temp.Add(temp_country);
        }
    }
}