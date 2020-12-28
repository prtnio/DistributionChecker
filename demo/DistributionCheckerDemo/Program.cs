using System;
using HCGStudio.DistributionChecker;

namespace DistributionCheckerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OperatingSystem.IsLinux()
                ? $"Your distribution info : {new DistributionChecker().GetDistribution()}"
                : "You are not running linux, try on Linux to get the information!");
        }
    }
}
