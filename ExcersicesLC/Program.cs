using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcersicesLC
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of exercise to check...");
            string inputValue;
            inputValue = Console.ReadLine();

            Program program = new Program();
            switch (inputValue)
            {
                case "1":
                    program.ExcerciseOne(true);
                    break;

                case "2":
                    program.ExcerciseTwo();
                    break;

                case "3":
                    program.ExcerciseThree();
                    break;

                case "4":
                    program.ExcerciseFour();
                    break;

                case "5":
                    program.ExcerciseFive();
                    break;

                default:
                    Console.WriteLine("Please enter a valid number");
                    Main(null);
                    break;

            }
        }

        /// <summary>
        /// Write a function that receives a string, if possible transform it to a date and return whether the year of the date
        /// is a leap year.If the string can't be transformed to a date throw an exception.
        /// </summary>
        private void ExcerciseOne(bool clearConsole)
        {
            if (clearConsole)
                Console.Clear();

            Console.WriteLine("Please enter a Date (yyyy/MM/dd)");
            string input = Console.ReadLine();
            DateTime date = DateTime.Now;
            int year;

            if (input.Length <= 0)
            {
                Console.WriteLine("Please enter a value");
                ExcerciseOne(false);
            }
            else
            {
                try
                {
                    date = DateTime.ParseExact(input, "yyyy/MM/dd", null);
                }
                catch
                {
                    Console.WriteLine("Exception. Please enter a valid date (yyyy/MM/dd)");
                    ExcerciseOne(false);
                }
            }

            year = date.Year;

            if ((year % 400) == 0)
                Console.WriteLine("{0} is a leap year \n", year);
            else if ((year % 100) == 0)
                Console.WriteLine("{0} is not a leap year \n", year);
            else if ((year % 4) == 0)
                Console.WriteLine("{0} is a leap year \n", year);
            else
                Console.WriteLine("{0} is not a leap year \n", year);

            Main(null);
        }

        /// <summary>
        /// Given 2 strings of unknown characters (but it cannot be repeated) create a function that returns an array of the
        /// characters that are repeated in both strings in the most efficient way.
        /// </summary>
        private void ExcerciseTwo()
        {
            Console.WriteLine("Please enter the first word...");
            string stringOne = Console.ReadLine();
            Console.WriteLine("Please enter the second word...");
            string stringTwo = Console.ReadLine();

            if (stringOne.Trim().ToLower() == stringTwo.Trim().ToLower())
            {
                Console.WriteLine("The values cann´t be the same");
                ExcerciseTwo();
            }
            var matchingString = new string(stringTwo.ToLower().Where(r => stringOne.ToLower().Contains(r)).ToArray());

            if (matchingString.Length == 0)
                Console.WriteLine("there's not identical characters");
            else
                Console.WriteLine("The repeated characthers are: {0} ", matchingString);

            Console.ReadKey(true);
            Console.Clear();
            Main(null);

        }

        /// <summary>
        /// Write a function to perform basic string compression using the counts of repeated characters
        /// </summary>
        private void ExcerciseThree()
        {
            Console.WriteLine("Please enter a word");
            string inputString = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(inputString))
            {
                var queue = new Queue<char>(inputString);
                int count = 0;

                while (queue.Count > 0)
                {
                    char character = queue.Dequeue();
                    count++;

                    if (queue.Count == 0 || character != queue.Peek())
                    {
                        sb.Append(character);
                        if (count > 1) sb.Append(count);
                        count = 0;
                    }
                }

                Console.WriteLine(sb.ToString());
                Console.ReadKey(true);
                Main(null);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid word");
                ExcerciseThree();
            }

        }

        /// <summary>
        /// Write a function that receives a string and validates if all the next brackets '[', '(' are properly closed '), ']'
        /// </summary>
        private void ExcerciseFour()
        {
            Console.WriteLine("Please enter the word with brakets");
            string inputString = Console.ReadLine();
            bool isValid = false;

            Stack<char> brackets = new Stack<char>();
            Dictionary<char, char> bracketP = new Dictionary<char, char>() {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' }};

            try
            {
                foreach (char c in inputString)
                {
                    if (bracketP.Keys.Contains(c))
                        brackets.Push(c);
                    else if (bracketP.Values.Contains(c))
                    {
                        if (c == bracketP[brackets.First()])
                            brackets.Pop();
                        else
                            isValid = false;
                    }
                    else
                        continue;
                }
            }
            catch
            {
                isValid = false;
            }

            isValid = brackets.Count() == 0 ? true : false;

            if (isValid)
                Console.WriteLine("TRUE The brackets are fine");
            else
                Console.WriteLine("FALSE The brackets aren´t fine");

            Console.ReadKey(true);
            Console.Clear();
            Main(null);

        }

        /// <summary>
        /// Given a finite number of discrete points in a cartesian plane
        /// </summary>
        private void ExcerciseFive()
        {
            Point point = new Point();
            point.X = 5;




            Console.ReadKey(true);
            Console.Clear();
            Main(null);
        }

        public sealed class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
