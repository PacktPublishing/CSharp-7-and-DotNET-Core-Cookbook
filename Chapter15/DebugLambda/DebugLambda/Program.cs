using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LambdaExample> MyFavoriteThings = new List<LambdaExample>();
            LambdaExample thing1 = new LambdaExample();
            thing1.FavThings = "Ice-cream";
            MyFavoriteThings.Add(thing1);

            LambdaExample thing2 = new LambdaExample();
            thing2.FavThings = "Summer Rain";
            MyFavoriteThings.Add(thing2);

            LambdaExample thing3 = new LambdaExample();
            thing3.FavThings = "Sunday morning snooze";
            MyFavoriteThings.Add(thing3);

            var filteredStuff = MyFavoriteThings.Where(feature => feature.FavThings.StartsWith("Sum"));
        }
    }

    public class LambdaExample
    {
        public string FavThings { get; set; }
    }
}
