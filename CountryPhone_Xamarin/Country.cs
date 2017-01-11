
using System;

public class Country
{

    public string cName { get; set; }
    public string cIso { get; set; }
    public int cCode { get; set; }
    public string cCodeStr { get; set; }
    public int cPriority { get; set; }
    public int cResId { get; set; }
    public int cNum { get; set; }

    public Country(string str, int num)
    {
        string[] data = str.Split(',');
        cNum = num;
        cName = data[0];
        cIso = data[1];
        cCode = Convert.ToInt32(data[2]);
        cCodeStr = "+" + data[2];
    }

    public override string ToString()
    {
        return cName + " " + cCodeStr;
    }
}