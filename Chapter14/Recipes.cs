using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter12
{
    public static class Recipes
    {
        public static string saltValue { get; set; }
        public static string hashValue { get; set; }

        #region Recipe 1 - Encrypting and storing passwords correctly
        /// <summary>
        /// Description:    This is the code for the Encrypting and storing passwords correctly Recipe found in Chapter 12
        /// Recipe:         Recipe 1 - Encrypting and storing passwords correctly
        /// Chapter:        12
        /// </summary>
        public static void RegisterUser(string password, string username)
        {
            // Register user
            // Create a truly random salt using RNGCryptoServiceProvider.
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            csprng.GetBytes(salt);

            // Get the salt value
            saltValue = Convert.ToBase64String(salt);
            // Salt the password
            byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValue + password);

            // Hash the salted password using SHA256
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(saltedPassword);

            // Save both the salt and the hash in the user's database record.
            saltValue = Convert.ToBase64String(salt);
            hashValue = Convert.ToBase64String(hash);
        }

        public static void ValidateLogin(string password, string username)
        {
            // Read the user's salt value from the database
            string saltValueFromDB = saltValue;

            // Read the user's hash value from the database
            string hashValueFromDB = hashValue;

            byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValueFromDB + password);

            // Hash the salted password using SHA256
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(saltedPassword);

            string hashToCompare = Convert.ToBase64String(hash);

            if (hashValueFromDB.Equals(hashToCompare))
                Console.WriteLine("User Validated.");
            else
                Console.WriteLine("Login credentials incorrect. User not validated.");
        }
        #endregion

        #region Recipe 5 - Using Diagnostic tools and historical debugging
        public static void ErrorInception()
        {
            string basepath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var full = Path.Combine(basepath, "log");

            try
            {
                for (int i = 0; i <= 3; i++)
                {
                    // do work
                    File.Open($"{full}\\log.txt", FileMode.Append);
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                ex.Data.Add("Date", DateTime.Now);
                LogException(ex.Message);
            }
        }

        private static void LogException(string message)
        {

        } 
        #endregion
        
        #region Recipe 7 - Using PerfTips to identify bottlenecks in code
        public static void RunFastTask()
        {
            RunLongerTask();
        }

        private static void RunLongerTask()
        {
            Thread.Sleep(3000);
            BottleNeck();
        }

        private static void BottleNeck()
        {
            Thread.Sleep(8000);
        } 
        #endregion





        public static void ValidateLoginSecureStringExample(SecureString passwordChar, string username)
        {
            SecureString secure = new SecureString();
        }

    }

    
}
