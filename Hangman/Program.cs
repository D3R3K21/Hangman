using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        private static List<string> letters = new List<string>
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
            "k","l","m","n","o","p","q","r","s","t","u","v",
            "w","x","y","z"
        };

        private static List<string> guessedLetters = new List<string> {  };

        private static List<string> phrases = new List<string>
        {
            "Hello World",
            "Mary Had A Little Lamb",
            "See Plus Plus",
            "Foo Bar"
        };

        private static string word;
        private static string wordBlank;
        private static int wrongGuesses = 0;

        static void Main(string[] args)
        {
            GetWord();
            Console.Out.WriteLine("Guess A Letter");
            while (wordBlank.Contains("_") && wrongGuesses <= 8)
            {
                GuessLetter(Console.ReadLine());
                PrintGame();
            }

            if (wrongGuesses < 8)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Out.WriteLine("You Win!");
                Console.ReadLine();
            }
        }

        private static void GuessLetter(string letter)
        {
            if (string.IsNullOrEmpty(letter) || letter.Length > 1 || !letters.Contains(letter.ToLower()))
            {
                Console.Out.WriteLine("Guess Must Be A Single Letter You Have Not Guess Yet");
                return;
            }

            if (guessedLetters.Contains(letter.ToLower()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine("You Guessed That Already Dummy! ;-P");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (!word.ToLower().Contains(letter.ToLower()))
            {
                wrongGuesses++;
            }

            guessedLetters.Add(letter.ToLower());
            FormatWordBlank();
        }
        private static void GetWord()
        {
            word = phrases.ElementAt(new Random().Next(0, phrases.Count));
            FormatWordBlank();
        }

        private static void FormatWordBlank()
        {
            wordBlank = string.Empty;
            foreach (var letter in word)
            {
                if (guessedLetters.Contains(letter.ToString().ToLower()))
                {
                    wordBlank += $"{letter} ";
                }
                else if (letter == ' ')
                {
                    wordBlank += new string(' ', 4);
                }
                else
                {
                    wordBlank += "_ ";
                }
            }

            wordBlank = wordBlank.Trim();
        }

        private static void PrintGame()
        {
            Console.Out.WriteLine($"Number Of Guesses Remaining: {8 - wrongGuesses}");
            Console.Out.WriteLine(wordBlank);
        }

    }
}
