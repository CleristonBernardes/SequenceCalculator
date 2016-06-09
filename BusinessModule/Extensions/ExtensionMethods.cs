using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Extensions
{
    internal static class ExtensionMethods
    {

        public static bool IsEven(this int number)
        {
            return (number % 2 == 0);
        }

        public static bool IsOdd(this int number)
        {
            return (number % 2 != 0);
        }
        
        public static bool IsMultipleOfThree(this int number)
        {
            return (number % 3 == 0);
        }

        public static bool IsMultipleOfFive(this int number)
        {
            return (number % 5 == 0);
        }
    }
}
