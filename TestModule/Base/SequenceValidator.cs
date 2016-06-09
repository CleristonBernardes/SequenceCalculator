using BusinessModule.Interfaces;
using BusinessModule.Model;
using BusinessModule.Support;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule.Base
{
    public class SequenceValidator
    {
        public void Validate()
        {
            TestData data = TestData.Instance;
            IList<int> testSamples = data.GetListOfNumbers();
            ISequenceCalculator calculator = BusinessConstructor.TestCalculator();
            
            foreach (var item in testSamples)
            {
                var result = calculator.CalculateSequences(item);
                ValidateSequence(item, result);
            }

        }

        /// <summary>
        /// Validate the sequence returned
        /// </summary>
        /// <param name="item">number</param>
        /// <param name="sequence">objec sequence</param>
        protected void ValidateSequence(int item, CalculatedSequence sequence)
        {
            var total = sequence.AllSequence.Length;
            Random rdn = new Random();
            int maxLoop = item > 100 ? 50 : 10;
            int maxDictionary = 4000000;

            total.Should().Be(item);
            sequence.EvenSequence.Where(x => x % 2 != 0).Count().Should().BeLessOrEqualTo(1);
            sequence.OddSequence.Where(x => x % 2 == 0).Count().Should().BeLessOrEqualTo(1);

            if (item % 2 == 0)
                sequence.EvenSequence.Length.Should().Be(total / 2);
            else
                sequence.OddSequence.Length.Should().Be((total + 1) / 2);

            for (var i=1; i < maxLoop; i++)
            {
                int key = rdn.Next(1, maxDictionary);
                if (sequence.ReplacedSequence.ContainsKey(key))
                {
                    if ((key % 3 == 0) && (key % 5 == 0))
                        sequence.ReplacedSequence[key].Should().Be("Z");
                    else if (key % 3 == 0)
                        sequence.ReplacedSequence[key].Should().Be("C");
                    else
                        sequence.ReplacedSequence[key].Should().Be("E");
                }
            }

            if (sequence.FibonacciSequence.Length - 3 > 0)
            {
                for (var i = 1; i < maxLoop; i++)
                {
                    int value = rdn.Next(0, sequence.FibonacciSequence.Length - 3);
                    (sequence.FibonacciSequence[value + 2] - sequence.FibonacciSequence[value + 1]).Should().Be(sequence.FibonacciSequence[value]);
                }
            }
            
        }
    }
}
