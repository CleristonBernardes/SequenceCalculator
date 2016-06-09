using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Model
{
    /// <summary>
    /// Structure of calculates sequences
    /// </summary>
    public class CalculatedSequence
    {
        public int[] AllSequence;
        public int[] EvenSequence;
        public int[] OddSequence;
        public Dictionary<int, string> ReplacedSequence;
        public int[] FibonacciSequence;
    }
}
