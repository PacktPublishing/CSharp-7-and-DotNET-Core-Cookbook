using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResponsiveApps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Button Clicked");
            //AsyncDemo oAsync = new AsyncDemo();
            //await oAsync.LongTask();
            //Console.WriteLine("Button Click Ended");

            //Console.WriteLine("Start file read");
            //AsyncDemo oAsync = new AsyncDemo();
            //int readResult = await oAsync.ReadBigFile();
            //Console.WriteLine("Bytes read = " + readResult);

            Console.WriteLine("Read backup file");
            AsyncDemo oAsync = new AsyncDemo();
            int readResult = await oAsync.ReadLogFile();
            Console.WriteLine("Bytes read = " + readResult);
        }
    }

    public class AsyncDemo
    {
        //public async Task LongTask()
        //{
        //    bool isLeapYear = await TaskOfTResultReturning_AsyncMethod();
        //    Console.WriteLine($"{DateTime.Now.Year} {(isLeapYear ? " is " : "  is not  ")} a leap year");
        //    await TaskReturning_AsyncMethod();
        //}

        public async Task LongTask()
        {
            Task<bool> blnIsLeapYear = TaskOfTResultReturning_AsyncMethod();

            for (int i = 0; i <= 10000; i++)
            {
                // Do other work that does not rely on blnIsLeapYear before awaiting 
            }

            bool isLeapYear = await TaskOfTResultReturning_AsyncMethod();
            Console.WriteLine($"{DateTime.Now.Year} {(isLeapYear ? " is " : "  is not  ")} a leap year");

            Task taskReturnMethhod = TaskReturning_AsyncMethod();

            for (int i = 0; i <= 10000; i++)
            {
                // Do other work that does not rely on taskReturnMethhod before awaiting 
            }

            await taskReturnMethhod;
        }

        async Task<bool> TaskOfTResultReturning_AsyncMethod()
        {
            return await Task.FromResult<bool>(DateTime.IsLeapYear(DateTime.Now.Year));
        }

        async Task TaskReturning_AsyncMethod()
        {
            await Task.Delay(5000);
            Console.WriteLine("5 second delay");
        }


        public Task<int> ReadBigFile()
        {
            var bigFile = File.OpenRead(@"C:\temp\taskFile\taskFile.txt");
            var bigFileBuffer = new byte[bigFile.Length];
            var readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            readBytes.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.Running)
                    Console.WriteLine("Running");
                else if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("RanToCompletion");
                else if (task.Status == TaskStatus.Faulted)
                    Console.WriteLine("Faulted");

                bigFile.Dispose();
            });
            return readBytes;
        }


        public enum LogType { Main = 0, Backup = 1 }

        public async Task<int> ReadLogFile()
        {
            int returnBytes = -1;
            try
            {
                returnBytes = await ReadLog(LogType.Main);
            }
            catch (Exception ex)
            {
                try
                {
                    returnBytes = await ReadLog(LogType.Backup);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return returnBytes;
        }

        private async Task<int> ReadLog(LogType logType)
        {
            string logFilePath = String.Empty;
            if (logType == LogType.Main)
                logFilePath = @"C:\temp\Log\MainLog\taskFile.txt";
            else if (logType == LogType.Backup)
                logFilePath = @"C:\temp\Log\BackupLog\taskFile.txt";

            string enumName = Enum.GetName(typeof(LogType), (int)logType);

            var bigFile = File.OpenRead(logFilePath);
            var bigFileBuffer = new byte[bigFile.Length];
            var readBytes = bigFile.ReadAsync(bigFileBuffer, 0, (int)bigFile.Length);
            await readBytes.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine($"{enumName} Log RanToCompletion");
                else if (task.Status == TaskStatus.Faulted)
                    Console.WriteLine($"{enumName} Log Faulted");

                bigFile.Dispose();
            });
            return await readBytes;
        }
    }
}
