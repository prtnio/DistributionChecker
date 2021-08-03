using System;
using HCGStudio.DistributionChecker;

namespace DistributionCheckerDemo
{
    class Program
    {
        static string sampleOsRelease = 
@"NAME=""DistributionChecker Linux""
ID=DistributionChecker
ID_LIKE=arch
BUILD_ID=rolling
PRETTY_NAME=""DistributionChecker Linux""
ANSI_COLOR=""1;2;3;4;5""
HOME_URL=""https://DistributionChecker.org/""
DOCUMENTATION_URL=""https://wiki.DistributionChecker.org/""
SUPPORT_URL=""https://DistributionChecker.org/""
BUG_REPORT_URL=""https://bugs.DistributionChecker.org/""
LOGO=DistributionCheckerLinux
";

        static void Main(string[] args)
        {
            Console.WriteLine(OperatingSystem.IsLinux()
                ? $"Your distribution info : {new DistributionChecker().GetDistribution()}"
                : "You are not running linux, try on Linux to get the information!");
            Console.WriteLine($"Your sample distribution info : {new DistributionChecker(sampleOsRelease).GetDistribution()}");
        }
    }
}
