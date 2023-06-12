using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet
{
    internal class Utils
    {
        public static bool IsInitialWordValid(string? input, int min, int max)
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


        public static bool IsWordValid(string? allowedSymbols, string? input)
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

    }
}
