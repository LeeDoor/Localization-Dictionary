using Localization_Dictionary;

public static class Program
{
    public static void Main()
    {
        LocDictionary dictionary = new LocDictionary(new HashSet<string> { 
            "english",
            "russian", 
            "spanish", 
            "nazy" 
        });
        dictionary.AddKey(new List<string> { "apple", "яблоко", "appol", "apfel" });
        dictionary.AddKey(new List<string> { "tank", "танк", "tank", "panzerkampfagen"});
        dictionary.AddKey(new List<string> { "whater", "вода", "whetter", "wasser"});
        dictionary.AddKey(new List<string> { "fire", "огонь", "fiyor", "keinejuden" });
        dictionary.Show();
    }
}