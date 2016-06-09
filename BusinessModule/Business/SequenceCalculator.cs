using BusinessModule.Extensions;
using BusinessModule.Interfaces;
using BusinessModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Business
{
    public class SequenceCalculator : ISequenceCalculator
    {
        /// <summary>
        /// Calculate all sequences
        /// Could receive a parameter with which sequences should be calculated
        /// </summary>
        public CalculatedSequence CalculateSequences(int number)
        {
            try
            {
                if (number < 1 || number > 10000000)
                    throw new Exception("Please inform a number bettween 1 and 10000000");

                CalculatedSequence result = new CalculatedSequence();
                var allnumbers = GetAllNumbersUpTo(number);

                result.AllSequence = allnumbers;
                result.EvenSequence = GetEvenNumbers(allnumbers);
                result.OddSequence = GetOddNumbers(allnumbers);
                result.ReplacedSequence = ReplaceNumberByLetterWhenMultiple(number);
                result.FibonacciSequence = GetFibonacciNumbers(number);

                Array.Resize(ref result.FibonacciSequence, result.FibonacciSequence.Length + 1);
                result.FibonacciSequence[result.FibonacciSequence.Length - 1] = number;
            
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        ///  All numbers up to and including the number entered
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>list</returns>
        private int[] GetAllNumbersUpTo(int number)
        {
            int[] result = new int[number];

            for (int i=0; i < number; i++)
            {
                result[i] = i+1;
            }

            return result;
        }

        /// <summary>
        /// All odd numbers
        /// </summary>
        /// <param name="numbers">list of numbers</param>
        /// <returns>list of number</returns>
        private int[] GetOddNumbers(int[] numbers)
        {
            try
            {
                int total = numbers.Length;
                int newSize = (total % 2 == 0) ? (total / 2) : ((total + 1) / 2);
                int position = 0;
                if (total.IsEven())
                    newSize += 1;


                int[] result = new int[newSize];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i].IsOdd())
                    {
                        result[position] = numbers[i];
                        position++;
                    }
                }

                if (total.IsEven())
                    result[newSize - 1] = total;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// All even numbers
        /// </summary>
        /// <param name="numbers">list of numbers</param>
        /// <returns>list of numbers</returns>
        private int[] GetEvenNumbers(int[] numbers)
        {
            try
            {
                int total = numbers.Length;
                int newSize = (total % 2 == 0) ? (total / 2) : ((total + 1) / 2);
                int position = 0;

                int[] result = new int[newSize];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i].IsEven())
                    {
                        result[position] = numbers[i];
                        position++;
                    }
                }
                if (total.IsOdd())
                    result[newSize - 1] = total;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// All numbers up to and including the number entered, except  when:
        ///     A number is a multiple of 3 output C, and when,
        ///     A number is a multiple of 5 output E, and when,   
        ///     A number is a multiple of both 3 and 5 output Z
        /// </summary>
        /// <param name="numbers">list of numbers</param>
        /// <returns>list of string</returns>
        private Dictionary<int, string> ReplaceNumberByLetterWhenMultiple(int number)
        {
            try
            {
                BusinessData PreLoadedData = BusinessData.Instance;
                return PreLoadedData.GetAllReplacebleNumbers().Where(n => n.Key <= number).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// All fibonacci number up to and including the number entered
        /// </summary>
        /// <param name="number">number</param>
        /// <returns>fibonacci list</returns>
        private int[] GetFibonacciNumbers(int number)
        {
            try
            {
                int[] fibList;
                BusinessData PreLoadedData = BusinessData.Instance;

                if (number == 0)
                    fibList = new int[] { };
                else
                    fibList = PreLoadedData.GetAllFibonacci().Where(f => f < number && f <= int.MaxValue).Select(f => (int)f).ToArray();

                return fibList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
