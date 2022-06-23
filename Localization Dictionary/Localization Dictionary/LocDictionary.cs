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
                if(value.Count > languages.Count)
                {
                    ConsoleColor.WriteError("not enough words in word list. exess words will be removed");
                    while (value.Count != languages.Count)
                    {
                        value.Remove(value.Last());
                    }
                }
                else if (value.Count < languages.Count)
                {
                    ConsoleColor.WriteError("not enough words in word list. needed words will be added");
                    while (value.Count != languages.Count)
                    {
                        value.Add("empty");
                    }
                }
            }
            dictionary.Add(key, value);
        }

        /// <summary>
        /// function adds key and list of words
        /// second overload without key
        /// key creates randomly
        /// </summary>
        /// <param name="value">list of words</param>
        public void AddKey(List<string> value)
        {
            int key = GenerateKey();
            AddKey(key, value);
        }

        /// <summary>
        /// generates key which equals last key of dictionary plus one
        /// </summary>
        /// <returns>returns int key</returns>
        private int GenerateKey()
        {
            int last = dictionary.LastOrDefault().Key;
            return last + 1;
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
            foreach (string language in languages)
            {
                Console.Write(language + "\t");
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
            if(dic.Count == 0)
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
        /// prints size in chars of the longest word in coloumn
        /// </summary>
        /// <param name="language">language of given coloumn</param>
        /// <returns></returns>
        private int GetMaxWordSize(int coloumn)
        {
            return dictionary.Max(n => n.Value[coloumn].Length);
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
                return;

            dictionary[key][languages.ToList().FindLastIndex(n => n == language)] = newWord;
        }
    }
}

