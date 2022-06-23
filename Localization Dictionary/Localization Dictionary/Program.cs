using Localization_Dictionary;

public static class Program
{
    public static void Main()
    {
        LocDictionary dictionary = new LocDictionary(new HashSet<string> { 
            "english"
        });
        dictionary.AddKey(0, new List<string> { "apple" });
        dictionary.AddKey(1, new List<string> { "tank"});
        dictionary.AddKey(2, new List<string> { "whater" });
        dictionary.AddKey(3, new List<string> { "grass" });
        dictionary.AddKey(4, new List<string> { "fire" });
        dictionary.AddKey(5, new List<string> { "eaculation" });

        LocDictionary dictionary2 = new LocDictionary(new HashSet<string> {
            "russian"
        });
        dictionary2.AddKey(0, new List<string> { "яблоко" });
        dictionary2.AddKey(1, new List<string> { "танк" });
        dictionary2.AddKey(2, new List<string> { "вода" });
        dictionary2.AddKey(3, new List<string> { "земля" });
        dictionary2.AddKey(4, new List<string> { "огонь" });
        dictionary2.AddKey(6, new List<string> { "инициализация" });

        var a = dictionary + dictionary2;
        a.Show();

    }
}