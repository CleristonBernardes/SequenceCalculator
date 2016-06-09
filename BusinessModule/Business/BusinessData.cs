using BusinessModule.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Business
{
    /// <summary>
    /// Singleton
    /// One instance to guarantee the array will be loaded only once.
    /// </summary>
    public sealed class BusinessData
    {
        IDictionary<int, string> _replacedDivisorsList = new Dictionary<int, string>() { };
        private static long[] _tempArray = new long[93];
        private static readonly BusinessData instance = new BusinessData();
        public readonly int sizeDivisorList = 5999471;

        static BusinessData()
        {
        }

        private BusinessData()
        {
            FibonacciNumberConstructor();
            DivisorReplaceConstructor();
        }

        public static BusinessData Instance
        {
            get
            {
                return instance;
            }
        }

        public long[] GetAllFibonacci()
        {
            return _tempArray;
        }


        public IDictionary<int, string> GetAllReplacebleNumbers()
        {
            return _replacedDivisorsList;
        }

        /// <summary>
        /// Build a temporary list with all possible fibonacci numbers
        /// </summary>
        private void FibonacciNumberConstructor()
        {
            try
            {
                long n = 93;
                long a = 0, b = 1, c = 0;
                long i = 0;

                for (; i < n; i++)
                {
                    c = a;
                    _tempArray[i] = a;
                    a = b;
                    b = c + b;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DivisorReplaceConstructor()
        {
            try
            {
                int number = sizeDivisorList;

                for (int i = 1; i <= number; i++)
                {
                    if (i.IsMultipleOfFive() || i.IsMultipleOfThree())
                    {
                        if (i.IsMultipleOfFive() && i.IsMultipleOfThree())
                            _replacedDivisorsList.Add(i, "Z");

                        else if (i.IsMultipleOfThree())
                            _replacedDivisorsList.Add(i, "C");
                        else
                            _replacedDivisorsList.Add(i, "E");
                    }
                    /*else
                    {
                        _replacedDivisorsList.Add(i, i.ToString());
                    }*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
