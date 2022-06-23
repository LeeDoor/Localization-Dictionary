using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization_Dictionary
{
    public static class ConsoleColor
    {
        /// <summary>
        /// colors console in black-white colors
        /// </summary>
        public static void SetEvenColoumn()
        {
            Console.BackgroundColor = System.ConsoleColor.White;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }

        /// <summary>
        /// colors console in white-black colors
        /// </summary>
        public static void SetOddColoumn()
        {
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.ForegroundColor = System.ConsoleColor.White;
        }
        public static void SetErrorString()
        {
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.ForegroundColor = System.ConsoleColor.Red;
        }
        public static void SetNullString()
        {
            Console.BackgroundColor = System.ConsoleColor.Yellow;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }
        public static void SetHead()
        {
            Console.BackgroundColor = System.ConsoleColor.Gray;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }

        public static void WriteError(string str)
        {
            SetErrorString();
            Console.WriteLine(str);
            SetOddColoumn();
        }
    }
}
