using BusinessModule.Business;
using BusinessModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Support
{
    /// <summary>
    /// Encapsulates the concetre classes to be tested
    /// </summary>
    public static class BusinessConstructor
    {

        public static ISequenceCalculator TestCalculator()
        {
            return new SequenceCalculator();
        }

        private static ISequenceCalculator TestCalculator_V2()
        {
            throw new NotImplementedException("Create a new version of calculator or its extention");
        }
        


    }
}
