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
        /// colors console in white-black colors. standart color
        /// </summary>
        public static void SetOddColoumn()
        {
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.ForegroundColor = System.ConsoleColor.White;
        }

        /// <summary>
        /// colors console in error set
        /// </summary>
        public static void SetErrorString()
        {
            Console.BackgroundColor = System.ConsoleColor.Black;
            Console.ForegroundColor = System.ConsoleColor.Red;
        }

        /// <summary>
        /// colors console in yellow color to show null elements
        /// </summary>
        public static void SetNullString()
        {
            Console.BackgroundColor = System.ConsoleColor.Yellow;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }

        /// <summary>
        /// colors console in gray to show table head
        /// </summary>
        public static void SetHead()
        {
            Console.BackgroundColor = System.ConsoleColor.Gray;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }

        /// <summary>
        /// prints error message in console
        /// </summary>
        /// <param name="str">printing message</param>
        public static void WriteError(string str)
        {
            SetErrorString();
            Console.WriteLine(str);
            SetOddColoumn();
        }
    }
}
