using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ClassesAndGenerics
{
    public enum MyEnum { Value1, Value2, Value3 }
    class Program
    {
        static void Main(string[] args)
        {
            //Lion lion = new Lion(Lion.ColorSpectrum.White);
            //lion.Hunt();
            //lion.Eat();
            //lion.Sleep();

            //Tiger tiger = new Tiger(Tiger.ColorSpectrum.Blue);
            //tiger.Hunt();
            //tiger.Eat();
            //tiger.Sleep();

            //Cheetah cheetah = new Cheetah();
            //cheetah.Hunt();
            //cheetah.Eat();
            //cheetah.Sleep();
            //cheetah.SoftPurr(60);

            //PerformAction<int> iAction = new PerformAction<int>(21);
            //iAction.IdentifyDataType();

            //PerformAction<decimal> dAction = new PerformAction<decimal>(21.55m);
            //dAction.IdentifyDataType();

            //PerformAction<string> sAction = new PerformAction<string>("Hello Generics");
            //sAction.IdentifyDataType();

            //DataSet dsData = new DataSet();
            //PerformAction<DataSet> oAction = new PerformAction<DataSet>(dsData);
            //oAction.IdentifyDataType();

            //MyHelperClass oHelper = new MyHelperClass();
            //var intExample = oHelper.InspectType(25);
            //WriteLine($"An example of this type is {intExample}");

            //var decExample = oHelper.InspectType(11.78m);
            //WriteLine($"An example of this type is {decExample}");

            //var strExample = oHelper.InspectType("Hello Generics");
            //WriteLine($"An example of this type is {strExample}");

            //var enmExample = oHelper.InspectType(MyEnum.Value2);
            //WriteLine($"An example of this type is {enmExample}");

            //Invoice oInvoice = new Invoice();
            //InspectClass<Invoice> oClassInspector = new InspectClass<Invoice>(oInvoice);
            //List<string> lstProps = oClassInspector.GetPropertyList();

            //foreach (string property in lstProps)
            //{
            //    WriteLine(property);
            //}


            //InspectClass<int> oClassInspector = new InspectClass<int>(10);
            //List<string> lstProps = oClassInspector.GetPropertyList();
            //foreach (string property in lstProps)
            //{
            //    WriteLine(property);
            //}

            //Invoice oInvoice = new Invoice();
            //InspectClass<Invoice> oInvClassInspector = new InspectClass<Invoice>(oInvoice);
            //List<string> invProps = oInvClassInspector.GetPropertyList();

            //foreach (string property in invProps)
            //{
            //    WriteLine(property);
            //}
            //ReadLine();
            //SalesOrder oSalesOrder = new SalesOrder();
            //InspectClass<SalesOrder> oSoClassInspector = new InspectClass<SalesOrder>(oSalesOrder);
            //List<string> soProps = oSoClassInspector.GetPropertyList();

            //foreach (string property in soProps)
            //{
            //    WriteLine(property);
            //}
            //ReadLine();



            //CreditNote oCreditNote = new CreditNote();
            //InspectClass<CreditNote> oCredClassInspector = new InspectClass<CreditNote>(oCreditNote);
            //List<string> credProps = oCredClassInspector.GetPropertyList();

            //foreach (string property in credProps)
            //{
            //    WriteLine(property);
            //}
            //ReadLine();

            
            WindowHeight = 18;
            WindowWidth = 62;
            ReadLine();
        }
    }

    public class Lion : Cat
    {
        public enum ColorSpectrum { Brown, White }
        public string LionColor { get; set; }

        public Lion(ColorSpectrum color)
        {
            LionColor = color.ToString();
        }

        public override void Eat()
        {
            WriteLine($"The {LionColor} lion eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The {LionColor} lion hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The {LionColor} lion sleeps.");
        }
    }

    public class Tiger : Cat
    {
        public enum ColorSpectrum { Orange, White, Gold, Blue, Black }
        public string TigerColor { get; set; }

        public Tiger(ColorSpectrum color)
        {
            TigerColor = color.ToString();
        }

        public override void Eat()
        {
            WriteLine($"The {TigerColor} tiger eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The {TigerColor} tiger hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The {TigerColor} tiger sleeps.");
        }
    }
    
    public class Cheetah : Cat, IPurrable
    {        
        public override void Eat()
        {
            WriteLine($"The cheetah eats.");
        }

        public override void Hunt()
        {
            WriteLine($"The cheetah hunts.");
        }

        public override void Sleep()
        {
            WriteLine($"The cheetah sleeps.");
        }

        public void SoftPurr(int decibel)
        {
            WriteLine($"The {nameof(Cheetah)} purrs at {decibel} decibels.");
        }
    }
        
    public abstract class Cat
    {
        public abstract void Eat();
        public abstract void Hunt();
        public abstract void Sleep();
    }

    interface IPurrable
    {
        void SoftPurr(int decibel);
    }

    public class PerformAction<T> where T : IDisposable
    {
        private T _value;
        public PerformAction(T value)
        {
            _value = value;
        }

        public void IdentifyDataType()
        {
            WriteLine($"The data type of the supplied variable is {_value.GetType()}");
        }
    }

    public class MyHelperClass
    {
        public T InspectType<T>(T value)
        {
            WriteLine($"The data type of the supplied parameter is {value.GetType()}");

            return (T)value;
        }
    }

    public class InspectClass<T> : IListClassProperties<T> where T : AcmeObject
    {
        T _classToInspect;
        public InspectClass(T classToInspect)
        {
            _classToInspect = classToInspect;
        }
        public List<string> GetPropertyList()
        {
            return _classToInspect.GetType().GetProperties().Select(p => p.Name).ToList();
        }
    }

    interface IListClassProperties<T>
    {
        List<string> GetPropertyList();
    }

    //public class Invoice
    //{
    //    public int ID { get; set; }
    //    public decimal TotalValue { get; set; }
    //    public int LineNumber { get; set; }
    //    public string StockItem { get; set; }
    //    public decimal ItemPrice { get; set; }
    //    public int Qty { get; set; }
    //}

    public class Invoice : AcmeObject
    {
        public override int ID { get; set; }
        public decimal TotalValue { get; set; }
        public int LineNumber { get; set; }
        public string StockItem { get; set; }
        public decimal ItemPrice { get; set; }
        public int Qty { get; set; }
    }

    public abstract class AcmeObject
    {
        public abstract int ID { get; set; }
    }

    public class SalesOrder : AcmeObject
    {
        public override int ID { get; set; }
        public decimal TotalValue { get; set; }
        public int LineNumber { get; set; }
        public string StockItem { get; set; }
        public decimal ItemPrice { get; set; }
        public int Qty { get; set; }
    }

    public class CreditNote
    {
        public int ID { get; set; }
        public decimal TotalValue { get; set; }
        public int LineNumber { get; set; }
        public string StockItem { get; set; }
        public decimal ItemPrice { get; set; }
        public int Qty { get; set; }
    }
}
