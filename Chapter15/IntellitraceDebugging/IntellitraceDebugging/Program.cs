using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntellitraceDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass cls = new MyClass();
            cls.SetupList(165);
            ReadLine();
        }
    }

    internal class MyClass
    {
        List<int> integerList;
        private int _valueToFind;

        public void SetupList(int valueToFind)
        {
            _valueToFind = valueToFind;
            if (ExistsInList())
                WriteLine($"{_valueToFind} exists in the list");
            else
                WriteLine($"{_valueToFind} does not exist in the list");

            integerList = new List<int>();
        }


        private bool ExistsInList()
        {
            if (integerList.Contains(_valueToFind))
                return true;
            else
                return false;
        }

    }
}
