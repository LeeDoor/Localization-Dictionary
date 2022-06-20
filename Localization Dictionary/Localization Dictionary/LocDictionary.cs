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
            if (dictionary.ContainsKey(key))
            {
                SetErrorString();
                Console.WriteLine("you already have this key");
                SetOddColoumn();
                return;
            }
            if (value == null)
            {
                SetErrorString();
                Console.WriteLine("value is null!");
                SetOddColoumn();
                return;
            }
            if (value.Count != languages.Count)
            {
                if(value.Count > languages.Count)
                {
                    SetErrorString();
                    Console.WriteLine("not enough words in word list. exess words will be removed");
                    SetOddColoumn();

                    while (value.Count != languages.Count)
                    {
                        value.Remove(value.Last());
                    }
                }
                else if (value.Count < languages.Count)
                {
                    SetErrorString();
                    Console.WriteLine("not enough words in word list. needed words will be added");
                    SetOddColoumn();

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

        public void Show(int key)
        {
            ShowHead();
            ShowLine(key);
            Console.WriteLine();
        }
        public void Show(string subword)
        {
            ShowHead();
            ShowLine(subword);
            Console.WriteLine();
        }

        private void ShowHead()
        {
            SetHead();
            Console.Write("keys\t");
            foreach (string language in languages)
            {
                Console.Write(language + "\t");
            }
            Console.WriteLine();
            SetOddColoumn();
        }

        private void ShowLine(string word)
        {
            foreach(var pair in dictionary)
            {
                if (pair.Value.Contains(word))
                {
                    ShowLine(pair.Key);
                    return;
                }
            }
            SetErrorString();
            Console.WriteLine("word not found");
            SetOddColoumn();
        }

        /// <summary>
        /// prints info about one key in console
        /// </summary>
        /// <param name="pair">one line</param>
        private void ShowLine(int key)
        {
            if (!dictionary.ContainsKey(key))
            {
                SetErrorString();
                Console.WriteLine("dictionary does not contain this key");
                SetOddColoumn();
                return;
            }
            Console.Write(key + "\t");
            List<string> words = dictionary[key];
            
            for(int i = 0; i < words.Count; i++)
            {
                if (words[i] == "empty")
                {
                    SetNullString();
                }
                else
                {
                    if (i % 2 == 0)
                        SetEvenColoumn();
                    else
                        SetOddColoumn();
                }

                Console.Write(words[i] + "\t");
            }
            SetOddColoumn();
            Console.WriteLine();
        }

        /// <summary>
        /// colors console in black-white colors
        /// </summary>
        private void SetEvenColoumn()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// colors console in white-black colors
        /// </summary>
        private void SetOddColoumn()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void SetErrorString()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private void SetNullString()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private void SetHead()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}

