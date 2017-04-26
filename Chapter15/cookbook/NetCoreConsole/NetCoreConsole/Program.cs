using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("I can run on Windows, Linux and macOS");
        GetSystemInfo();
        
        Console.ReadLine();
    }

    private static void GetSystemInfo()
    {
        var osInfo = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        Console.WriteLine($"Current OS is: {osInfo}");
    }
}