using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //RegExDemo oRecipe = new RegExDemo();
            //oRecipe.ValidDate("1912-12-31");
            //oRecipe.ValidDate("2018-01-01");
            //oRecipe.ValidDate("1800-01-21");
            //oRecipe.ValidDate($"{DateTime.Now.Year}.{DateTime.Now.Month  }.{DateTime.Now.Day}");
            //oRecipe.ValidDate("2016-21-12");
            //Read();

            //string textToSanitize = "This is a string that contains a  badword1, another Badword2 and a third badWord3";
            //RegExDemo oRecipe = new RegExDemo();
            //textToSanitize = oRecipe.SanitizeInput(textToSanitize);
            //WriteLine(textToSanitize);
            //Read();

            DemoExtensionMethod();
            Read();
        }

        public static void DemoExtensionMethod()
        {
            Console.WriteLine($"Today's date is: {DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
            Console.WriteLine($"The file must match:  acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.txt including leading month and day zeros");
            Console.WriteLine($"The file must match:  acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.docx including leading month and day zeros");
            Console.WriteLine($"The file must match:  acm_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}.xlsx including leading month and day zeros");

            string filename = "acm_2016_04_10.txt";
            if (filename.ValidAcmeCompanyFilename())
                Console.WriteLine($"{filename} is a valid file name");
            else
                Console.WriteLine($"{filename} is not a valid file name");

            filename = "acm-2016_04_10.txt";
            if (filename.ValidAcmeCompanyFilename())
                Console.WriteLine($"{filename} is a valid file name");
            else
                Console.WriteLine($"{filename} is not a valid file name");
        }
    }

    public class RegExDemo
    {
        public void ValidDate(string stringToMatch)
        {
            //string pattern = $@"^(19|20)\d\d[-./](0[1-9]|1[0-2])[-./](0[1-9]|[12][0-9]|3[01])$";
            string pattern = $@"^(19|20)\d\d[-./](0[1-9]|1[0-2]|[1-9])[-./](0[1-9]|[12][0-9]|3[01])$";

            if (Regex.IsMatch(stringToMatch, pattern))
                Console.WriteLine($"The string {stringToMatch} contains a valid date.");
            else
                Console.WriteLine($"The string {stringToMatch} DOES NOT contain a valid date.");
        }

        public string SanitizeInput(string input)
        {
            List<string> lstBad = new List<string>(new string[] { "BadWord1", "BadWord2", "BadWord3" });
            string pattern = "";
            foreach (string badWord in lstBad)
                pattern += pattern.Length == 0 ? $"{badWord}" : $"|{badWord}";

            pattern = $@"\b({pattern})\b";

            return Regex.Replace(input, pattern, "*****", RegexOptions.IgnoreCase);
        }
    }

    public static class CustomRegexHelper
    {
        public static bool ValidAcmeCompanyFilename(this string value)
        {
            return Regex.IsMatch(value, $@"^acm[_]{DateTime.Now.Year}[_]({DateTime.Now.Month}|0[{DateTime.Now.Month}])[_]({DateTime.Now.Day}|0[{DateTime.Now.Day}])(.txt|.docx|.xlsx)$");
        }
    }
}
