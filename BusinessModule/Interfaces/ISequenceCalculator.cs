using BusinessModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Interfaces
{
    public interface ISequenceCalculator
    {
        CalculatedSequence CalculateSequences(int number);
    }
}
