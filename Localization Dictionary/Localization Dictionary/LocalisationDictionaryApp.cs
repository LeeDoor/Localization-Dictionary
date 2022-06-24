using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization_Dictionary
{
	public class LocalisationDictionaryApp
	{
		List<LocDictionary> dictionaries = new List<LocDictionary>();

		private LocDictionary CreateDictionary()
        {
			HashSet<string> Lanaguagelist = new HashSet<string>();
			string? choice = null;
			Console.WriteLine("firstly you should fill languages");
			while (true)
			{
				Console.Write("enter language: (enter nothing to stop) >");
				choice = Console.ReadLine();
				if (string.IsNullOrEmpty(choice))
				{
					if (Lanaguagelist.Count == 0)
					{
						ConsoleColor.WriteError("you should have at least one language");
						continue;
					}
					else
					{
						break;
					}
				}
				Lanaguagelist.Add(choice);
			}
			return new LocDictionary(Lanaguagelist);
		}

		private void ManyDicsMenu()
		{
            while (true) 
			{ 
				string? choice = null;
				Console.WriteLine(
					"\nS: show all dictionaries" +
					"\nA: add new dictionary" +
					"\nC: change concrete dictionary" +
					"\nD: delete dictionary" +
					"\nO: connect two dictionaries");
				choice = Console.ReadLine();
				if (String.IsNullOrEmpty(choice)) continue;
                switch (choice)
                {
					case "S":
					case "s":
						if(dictionaries.Count == 0)
                        {
							ConsoleColor.WriteError("you have no dictionaries. firstly you need to add it");
                        }
						for(int i = 0; i < dictionaries.Count; i ++)
                        {
							Console.WriteLine($"{i} => \n");
                            dictionaries[i].Show();
                        }
						break;
					case "a":
					case "A":
						dictionaries.Add(CreateDictionary());
						break;

					case "C":
					case "c":
						Console.Write("enter id of dictionary: >");
						choice = Console.ReadLine();
						
						if(string.IsNullOrEmpty(choice))
                        {
							ConsoleColor.WriteError("string is empty");
							break;
                        }
						if (Int32.TryParse(choice, out int dictId))
						{
							if (0 <= dictId && dictId < dictionaries.Count)
								ChangeDictionary(dictId);
                            else
                            {
								ConsoleColor.WriteError("you dont have dictionary with this id");
								break;
							}
						}
						else
						{
							ConsoleColor.WriteError("it is not int");
							break;
						}
						break;

					case "O":
					case "o":
						Console.WriteLine("enter id of first dictionary: ");
						choice = Console.ReadLine();

						if (string.IsNullOrEmpty(choice))
						{
							ConsoleColor.WriteError("string is empty");
							break;
						}
						if (Int32.TryParse(choice, out int id1))
						{
							if (!(0 <= id1 && id1 < dictionaries.Count))
							{
								ConsoleColor.WriteError("you dont have dictionary with this id");
								break;
							}
						}
						else
						{
							ConsoleColor.WriteError("it is not int");
							break;
						}

						Console.WriteLine("enter id of second dictionary: ");
						choice = Console.ReadLine();

						if (string.IsNullOrEmpty(choice))
						{
							ConsoleColor.WriteError("string is empty");
							break;
						}
						if (Int32.TryParse(choice, out int id2))
						{
							if (!(0 <= id2 && id2 < dictionaries.Count))
							{
								ConsoleColor.WriteError("you dont have dictionary with this id");
								break;
							}
						}
						else
						{
							ConsoleColor.WriteError("it is not int");
							break;
						}
                        dictionaries.Add(dictionaries[id1] + dictionaries[id2]);
						break;

					case "D":
					case "d":
						Console.WriteLine("enter id of dictionary you want to remove: ");
						choice = Console.ReadLine();

						if (string.IsNullOrEmpty(choice))
						{
							ConsoleColor.WriteError("string is empty");
							break;
						}
						if (Int32.TryParse(choice, out int id))
						{
							if (!(0 <= id && id < dictionaries.Count))
							{
								ConsoleColor.WriteError("you dont have dictionary with this id");
								break;
							}
						}
						else
						{
							ConsoleColor.WriteError("it is not int");
							break;
						}

                        dictionaries.Remove(dictionaries[id]);
						break;
				}
				Console.WriteLine("press any key to continue...");
				Console.Read();
				Console.Clear();
			}
		}

		private void ChangeDictionary (int dictId)
        {
			string? choice = null;
			LocDictionary locDictionary = dictionaries[dictId];
			int newKey;
			bool flag = true;
			while (flag)
			{
				locDictionary.Show();
				Console.WriteLine(
					"\nA: add new key" +
					"\nC: change translation word" +
					"\nQ: quit");
				choice = Console.ReadLine();
				if (String.IsNullOrEmpty(choice)) continue;
				if (Char.TryParse(choice, out _))
				{
					switch (choice)
					{
						case "A":
						case "a":
							Console.Write("enter new key (int):> ");
							choice = Console.ReadLine();
							if (string.IsNullOrEmpty(choice))
							{
								ConsoleColor.WriteError("enter integer");
								break;
							}
							if (!Int32.TryParse(choice, out newKey))
							{
								ConsoleColor.WriteError("key is intenger");
								break;
							}
							Console.WriteLine("now enter translation for every language");
							List<string> words = new List<string>();
							foreach (var leng in locDictionary.Languages)
							{
								Console.Write(leng + ": >");
								choice = Console.ReadLine();
								if (string.IsNullOrEmpty(choice))
								{
									words.Add("empty");
								}
								else
								{
									words.Add(choice);
								}
							}
							locDictionary.AddKey(newKey, words);
							break;
						case "C":
						case "c":
							Console.Write("enter needed key:>");
							choice = Console.ReadLine();

							if (string.IsNullOrEmpty(choice))
							{
								ConsoleColor.WriteError("enter integer");
								break;
							}
							if (!Int32.TryParse(choice, out newKey))
							{
								ConsoleColor.WriteError("key is intenger");
								break;
							}
							Console.Write("enter language of word you want to change:> ");
							choice = Console.ReadLine();
							if (string.IsNullOrEmpty(choice))
							{
								ConsoleColor.WriteError("string is empty");
								break;
							}
							string curLang = choice;
							Console.Write("enter new word:> ");
							choice = Console.ReadLine();
							if (string.IsNullOrEmpty(choice))
							{
								ConsoleColor.WriteError("string is empty");
								break;
							}
							string curWord = choice;

							locDictionary.ChangeTranslation(newKey, curLang, curWord);
							break;

						case "q":
						case "Q":
							flag = false;
							break;
					}
				}
				Console.WriteLine("press any key to continue...");
				Console.Read();
				Console.Clear();
			}
		}

		public void Start()
		{
			ConsoleColor.SetOddColoumn();
			Console.Clear();

			LocDictionary dictionary1 = new LocDictionary(new HashSet<string> { "russian" });
			dictionary1.AddKey(0, new List<string> { "вода" });
			dictionary1.AddKey(1, new List<string> { "огонь" });
			dictionary1.AddKey(2, new List<string> { "земля" });
			dictionary1.AddKey(3, new List<string> { "воздух" });
			dictionary1.AddKey(4, new List<string> { "яблоко" });
			dictionary1.AddKey(5, new List<string> { "аппельсин" });
			dictionary1.AddKey(6, new List<string> { "желтый" });
			dictionary1.AddKey(7, new List<string> { "синий" });
			dictionary1.AddKey(8, new List<string> { "зеленый" });
			dictionary1.AddKey(9, new List<string> { "красный" });
			dictionaries.Add(dictionary1);

			LocDictionary dictionary2 = new LocDictionary(new HashSet<string> { "english" });
			dictionary2.AddKey(0, new List<string> { "whater" });
			dictionary2.AddKey(1, new List<string> { "fire" });
			dictionary2.AddKey(2, new List<string> { "ground" });
			dictionary2.AddKey(3, new List<string> { "air" });
			dictionary2.AddKey(4, new List<string> { "apple" });
			dictionary2.AddKey(5, new List<string> { "orange" });
			dictionary2.AddKey(6, new List<string> { "yellow" });
			dictionary2.AddKey(7, new List<string> { "blue" });
			dictionary2.AddKey(8, new List<string> { "green" });
			dictionary2.AddKey(10, new List<string> { "purple" });
			dictionaries.Add(dictionary2);

			ManyDicsMenu();
		}
	}
}
