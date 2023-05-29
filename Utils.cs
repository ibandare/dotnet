using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsGame
{
    internal class Utils
    {
        public static bool isInitialWordValid(string? input, int min, int max)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.Any(c => !Char.IsLetter(c)))
            {
                return false;
            }

            if (input.Length < min || input.Length > max)
            {
                return false;
            }
            return true;

        }


        public static bool IsWordValid(string allowedSymbols, string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            if (input.Any(c => !allowedSymbols.Contains(c)))
            {
                return false;
            }
            return true;
        }



        public static bool PlayRound(string? allowedSymbols)
        {
            Func<string, bool> MakeTurn = user =>
            {
                Console.WriteLine($"\n{user}'s word:");
                string? input = Console.ReadLine();
                if (IsWordValid(allowedSymbols, input))
                {
                    return true;
                }
                Console.WriteLine($"{user} has lost the game!");
                return false;
                
            };

            return MakeTurn("User 1") && MakeTurn("User 2");

        }

    }
}
