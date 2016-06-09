using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestModule.Base
{
    /// <summary>
    /// Only one instance of the classe to mantain the data consistently
    /// Could implement futurely a generic interface of basic list types and dictionary
    /// </summary>
    public sealed class TestData
    {
        private static List<int> _numbersList = new List<int>();
        private static readonly TestData _instance = new TestData();
        public readonly int sizeMaxExecutor = 10000000;

        public IList<int> GetListOfNumbers()
        {
            return _numbersList;
        }

        public void AddNumberToList(int number)
        {
            if (!_numbersList.Contains(number))
                _numbersList.Add(number);
        }

        public void RemoveNumberFromList(int number)
        {
            if (_numbersList.Contains(number))
                _numbersList.Remove(number);
        }

        public void ResetNumbersList()
        {
            LoadNumbers();
        }


        public void CleanNumbersList()
        {
            _numbersList.RemoveAll(n => true);
        }

        private TestData()
        {
            LoadNumbers();
        }

        private void LoadNumbers()
        {
            _numbersList.Add(1);
            _numbersList.Add(2);
            _numbersList.Add(3);
            _numbersList.Add(4);
            _numbersList.Add(6);
            _numbersList.Add(60);
            _numbersList.Add(97);
            _numbersList.Add(41);
            _numbersList.Add(100000);
        }
        
        public static TestData Instance
        {
            get { return _instance; }
        }


    }
}
