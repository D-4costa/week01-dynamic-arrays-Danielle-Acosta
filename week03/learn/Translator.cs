public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));
        Console.WriteLine(englishToGerman.Translate("Plane"));
        Console.WriteLine(englishToGerman.Translate("Train"));
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Add the translation from 'from_word' to 'to_word'
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Translates the from word into the stored translation
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.ContainsKey(fromWord))
        {
            return _words[fromWord];
        }

        return "???";
    }
}
