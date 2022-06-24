using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization_Dictionary
{
    /// <summary>
    /// the class describes the localization dictionary and its access functions
    /// </summary>
    public class LocDictionary
    {
        /// <summary>
        /// main dictionary
        /// KEY - randomly filled string with any characters like ADEH2
        /// VALUE - list of translations of the same word in different languages
        /// </summary>
        private Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();

        /// <summary>
        /// list of able languages
        /// i used hashset, because you cant add 2 same languages
        /// </summary>
        private HashSet<string> languages = new HashSet<string>();
        public HashSet<string> Languages
        {
            get
            {
                return languages;
            }
        }

        /// <summary>
        /// parametrical constructor
        /// you cant create dictionary without list of languages
        /// </summary>
        /// <param name="Languages">list of languages</param>
        public LocDictionary(HashSet<string> Languages)
        {
            languages = Languages;
        }

        /// <summary>
        /// function adds key and list of words
        /// 2 overloads
        /// </summary>
        /// <param name="key"> primary key</param>
        /// <param name="value">list of words</param>
        public void AddKey(int key, List<string> value)
        {
            // dublicate key check
            if (dictionary.ContainsKey(key))
            {
                ConsoleColor.WriteError("you already have this key");
                return;
            }
            // null value check
            if (value == null)
            {
                ConsoleColor.WriteError("value is null!");
                return;
            }
            // wrong value length
            if (value.Count != languages.Count)
            {
                if (value.Count > languages.Count)
                {
                    ConsoleColor.WriteError("not enough words in word list. exess words will be removed");
                    while (value.Count != languages.Count)
                    {
                        value.Remove(value.Last());
                    }
                }
                else if (value.Count < languages.Count)
                {
                    ConsoleColor.WriteError("too much words in word list. needed words will be added");
                    while (value.Count != languages.Count)
                    {
                        value.Add("empty");
                    }
                }
            }
            dictionary.Add(key, value);
        }

        /// <summary>
        /// prints whole dictionary in console
        /// </summary>
        public void Show()
        {
            ShowHead();
            foreach (var pair in dictionary)
            {
                ShowLine(pair.Key);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// prints line of dictionary with given key
        /// </summary>
        /// <param name="key">dictionary key</param>
        public void Show(int key)
        {
            ShowHead();
            ShowLine(key);
            Console.WriteLine();
        }

        /// <summary>
        /// prints lines with given subword
        /// </summary>
        /// <param name="subword">subword of dictionary</param>
        public void Show(string subword)
        {
            ShowHead();
            ShowLine(subword);
            Console.WriteLine();
        }

        /// <summary>
        /// shows languages of dictionary
        /// </summary>
        private void ShowHead()
        {
            ConsoleColor.SetHead();
            Console.Write("keys\t");
            string printingWord;
            foreach (string language in languages)
            {
                printingWord = language;
                Console.Write(printingWord);
                (int left, int top) = Console.GetCursorPosition();
                Console.SetCursorPosition(left + GetMaxWordSize(language) - printingWord.Length + 3, top);

            }
            Console.WriteLine();
            ConsoleColor.SetOddColoumn();
        }

        /// <summary>
        /// prints every line with given subword
        /// </summary>
        /// <param name="word"></param>
        private void ShowLine(string word)
        {
            var dic = dictionary.Where(n => n.Value.Contains(word)).ToList();
            if (dic.Count == 0)
            {
                ConsoleColor.WriteError("word not found");
            }

            foreach (var pair in dic)
            {
                ShowLine(pair.Key);
            }
        }

        /// <summary>
        /// prints info about one key in console
        /// </summary>
        /// <param name="pair">one line</param>
        private void ShowLine(int key)
        {
            // if you havent this key leave
            if (!dictionary.ContainsKey(key))
            {
                ConsoleColor.WriteError("dictionary does not contain this key");
                return;
            }

            Console.Write(key + "\t");
            List<string> words = dictionary[key];
            string printingWord;
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i] == "empty")
                {
                    ConsoleColor.SetNullString();
                }
                else
                {
                    if (i % 2 == 0)
                        ConsoleColor.SetEvenColoumn();
                    else
                        ConsoleColor.SetOddColoumn();
                }
                printingWord = words[i];
                Console.Write(printingWord);


                (int left, int top) = Console.GetCursorPosition();
                Console.SetCursorPosition(left + GetMaxWordSize(i) - printingWord.Length + 3, top);
            }
            ConsoleColor.SetOddColoumn();
            Console.WriteLine();
        }

        

        /// <summary>
        /// changes one translation word of key
        /// </summary>
        /// <param name="key">needed word</param>
        /// <param name="language">needed language</param>
        /// <param name="newWord"> new word</param>
        public void ChangeTranslation(int key, string language, string newWord)
        {
            if (language == null
                || newWord == null
                || !dictionary.ContainsKey(key)
                || !languages.Contains(language))
            {
                ConsoleColor.WriteError("Wrong enter");
                return;
            }

            dictionary[key][languages.ToList().FindLastIndex(n => n == language)] = newWord;
        }

        /// <summary>
        /// prints size in chars of the longest word in coloumn
        /// </summary>
        /// <param name="coloumn">id of given coloumn</param>
        /// <returns></returns>
        private int GetMaxWordSize(int coloumn)
        {
            int maxTranslationWord = dictionary.Max(n => n.Value[coloumn].Length);
            if (maxTranslationWord > languages.ElementAt(coloumn).Length)
            {
                return maxTranslationWord;
            }
            return languages.ElementAt(coloumn).Length;
        }

        /// <summary>
        /// prints size in chars of the longest word in coloumn
        /// </summary>
        /// <param name="language">id of given coloumn</param>
        /// <returns></returns>
        private int GetMaxWordSize(string language)
        {
            int languageId = languages.ToList().FindLastIndex(n => n == language);
            int maxTranslationWord = 0;
            if (dictionary.Count != 0) 
                maxTranslationWord = dictionary.Max(n => n.Value[languageId].Length);
            int languageLength = languages.ElementAt(languageId).Length;

            if (maxTranslationWord > languageLength)
            {
                return maxTranslationWord;
            }
            return languageLength;
        }

        /// <summary>
        /// function connects two lists of languages in one. needed bc languages are the hashsets
        /// </summary>
        /// <param name="h1">first list of languages</param>
        /// <param name="h2">second list of languages</param>
        /// <returns>returns connected languages</returns>
        private static HashSet<string> ConnectLanguages(HashSet<string> h1, HashSet<string> h2)
        {

            HashSet<string> newLangs = new HashSet<string>();
            foreach (var lan in h1)
            {
                newLangs.Add(lan);
            }
            foreach (var lan in h2)
            {
                newLangs.Add(lan);
            }
            return newLangs;
        }

        /// <summary>
        /// overrided operator to connect two dictionaries in one
        /// </summary>
        /// <param name="dic1">first dictionary</param>
        /// <param name="dic2">second dictionary</param>
        /// <returns>returns connected dictionary</returns>
        public static LocDictionary operator + (LocDictionary dic1, LocDictionary dic2)
        {
            HashSet<string> newLangs = ConnectLanguages(dic1.languages, dic2.languages);

            LocDictionary res = new LocDictionary(newLangs);

            foreach(var pair in dic1.dictionary)
            {
                if (dic2.dictionary.ContainsKey(pair.Key))
                {
                    var newWords = new List<string>();
                    foreach (var word in dic1.dictionary[pair.Key])
                    {
                        newWords.Add(word);
                    }
                    foreach (var word in dic2.dictionary[pair.Key])
                    {
                        newWords.Add(word);
                    }

                    res.AddKey(pair.Key, newWords);
                }
                else
                {
                    res.AddKey(pair.Key, pair.Value);
                }
            }
            foreach (var pair in dic2.dictionary)
            {
                if (!dic1.dictionary.ContainsKey(pair.Key))
                {
                    List<string> newWords = new();
                    for(int i = 0; i < dic1.languages.Count; i++)
                    {
                        newWords.Add("empty");
                    }
                    foreach(var word in dic2.dictionary[pair.Key])
                    {
                        newWords.Add(word);
                    }
                    res.AddKey(pair.Key, newWords);
                }
            }

            return res;
        }

        /// <summary>
        /// orders dictionary using language coloumn name
        /// </summary>
        /// <param name="language">name of language</param>
        public void OrderByLanguage(string language)
        {
            OrderByLanguage(languages.ToList().FindLastIndex(n => n == language));
        }

        /// <summary>
        /// orders dictionary using id coloumn name
        /// </summary>
        /// <param name="coloumn">id of coloumn</param>
        public void OrderByLanguage(int coloumn)
        {
            if (0 <= coloumn && coloumn < languages.Count)
                dictionary = dictionary.OrderBy(n => n.Value[coloumn]).ToDictionary(n=>n.Key, n=>n.Value);
            else 
                ConsoleColor.WriteError("no such language or coloumn to order by");
        }
    }
}

