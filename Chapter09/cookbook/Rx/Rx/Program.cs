using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace Rx
{
    class Program
    {
        // Static action event 
        //static event Action<string> types;

        static Subject<string> obsTypes = new Subject<string>();

        static void Main(string[] args)
        {
            List<DotNet> lstTypes = new List<DotNet>();
            DotNet blnTypes = new DotNet();
            blnTypes.AvailableDatatype = "bool";
            lstTypes.Add(blnTypes);

            DotNet strTypes = new DotNet();
            strTypes.AvailableDatatype = "string";
            lstTypes.Add(strTypes);

            DotNet intTypes = new DotNet();
            intTypes.AvailableDatatype = "int";
            lstTypes.Add(intTypes);

            DotNet decTypes = new DotNet();
            decTypes.AvailableDatatype = "decimal";
            lstTypes.Add(decTypes);

            //types += x =>
            //{
            //    Console.WriteLine(x);
            //};

            //for (int i = 0; i <= lstTypes.Count - 1; i++)
            //{
            //    types(lstTypes[i].AvailableDatatype);
            //}

            // IObservable 
            obsTypes.Subscribe(x =>
            {
                Console.WriteLine(x);
            });

            // IObserver 
            for (int i = 0; i <= lstTypes.Count - 1; i++)
            {
                obsTypes.OnNext(lstTypes[i].AvailableDatatype);
            }


            




            Console.WindowHeight = 18;
            Console.WindowWidth = 62;
            Console.ReadLine();
        }
    }

    public class DotNet
    {
        public string AvailableDatatype { get; set; }
    }
}
