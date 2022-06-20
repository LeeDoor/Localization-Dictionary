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

        private HashSet<string> languages = new HashSet<string>();

        public LocDictionary(HashSet<string> Languages)
        {
            languages = Languages;
        }
        public void AddKey(int key, List<string> value)
        {
            if (value == null) {
                Console.WriteLine("value is null!");
                return;
            }
            if (value.Count == languages.Count)
            {
                dictionary.Add(key, value);
            }
        }

        public void AddKey(List<string> value)
        {
            int key = GenerateKey();
            AddKey(key, value);
        }

        private int GenerateKey()
        {
            int last = dictionary.LastOrDefault().Key;
            return last + 1;
        }
        public void Show()
        {
            Console.Write("keys\t");
            int counter = 0;
            foreach (string language in languages)
            {
                if (counter++ % 2 == 0)
                {
                    setEvenColoumn();
                }
                else
                {
                    setOddColoumn();
                }
                Console.Write(language + "\t");
            }

            Console.WriteLine();
            foreach (var pair in dictionary)
            {
                ShowLine(pair);
            }
        }
        public void ShowLine(KeyValuePair<int, List<string>> pair)
        {
            Console.WriteLine();
            Console.Write(pair.Key + "\t");
            
            for(int i = 0; i < pair.Value.Count; i++)
            {
                if (i % 2 == 0)
                {
                    setEvenColoumn();
                }
                else
                {
                    setOddColoumn();
                }

                Console.Write(pair.Value[i] + "\t");
            }
            setOddColoumn();
        }

        private void setEvenColoumn()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private void setOddColoumn()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
