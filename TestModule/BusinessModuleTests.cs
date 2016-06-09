using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;
using TestModule.Base;

namespace TestModule
{
    [TestClass]
    public class BusinessModuleTests: SequenceValidator
    {

        [TestMethod]
        public void ValidateSequenceCalculation()
        {
            Validate();
        }


        [TestMethod]
        public void ValidateSequenceCalculationHighNumber()
        {
            TestData data = TestData.Instance;
            data.CleanNumbersList();
            data.AddNumberToList(data.sizeMaxExecutor);
            data.AddNumberToList(999999);

            Validate();

            data.ResetNumbersList();
        }


        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateSequenceCalculateZero()
        {
            TestData data = TestData.Instance;
            data.CleanNumbersList();
            data.AddNumberToList(0);

            Validate();

            data.ResetNumbersList();
        }
        

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateSequenceCalculateNegative()
        {
            TestData data = TestData.Instance;
            data.CleanNumbersList();
            data.AddNumberToList(-1);

            Validate();

            data.ResetNumbersList();
        }
        
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ValidateSequenceCalculateTooHigh()
        {
            TestData data = TestData.Instance;
            data.CleanNumbersList();
            data.AddNumberToList(int.MaxValue);

            Validate();

            data.ResetNumbersList();
        }
        

    }
}
