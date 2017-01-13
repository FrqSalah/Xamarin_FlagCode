using System.Collections.Generic;

namespace CountryPhone_Xamarin
{
    public static class SectionIndex
    {
        // Liste des caractères
        public static Java.Lang.Object[] BuildSectionHeaders(List<Country> data)
        {
            var results = new List<string>();
            var used = new SortedSet<string>();

            foreach(var item in data)
            {
                var letter = item.cName[0].ToString();

                if (!used.Contains(letter))
                {
                    results.Add(letter);
                }

                used.Add(letter);
            }

            var jObjetcs = new Java.Lang.Object[results.Count];

            for(int i =0; i<results.Count; i++)
            {
                jObjetcs[i] = results[i];
            }

            return jObjetcs;
        }

        // Liste des sections
        public static Dictionary<int, int> BuildSectionForPositionMap(List<Country> data)
        {
            var results = new Dictionary<int, int>();
            var used = new SortedSet<string>();
            var section = -1;

            for (int i=0; i< data.Count; i++)
            {
                var letter = data[i].cName[0].ToString();

                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                }
                results.Add(i, section);
            }

            return results;
        }

        public static Dictionary<int, int> BuildPositionForSectionMap(List<Country> data)
        {
            var results = new Dictionary<int, int>();
            var used = new SortedSet<string>();
            int section = -1;

            for (int i=0; i< data.Count; i++)
            {
                var letter = data[i].cName[0].ToString();

                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                    results.Add(section, i);
                }
            }
            return results;
        }
    }

}