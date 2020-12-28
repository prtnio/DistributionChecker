# DistributionChecker
A small library that helps you check your running distribution. [Demo](https://github.com/HCGStudio/DistributionChecker/blob/main/demo/DistributionCheckerDemo/Program.cs)

![Nuget](https://img.shields.io/nuget/dt/HCGStudio.DistributionChecker)

Install :
``` shell
dotnet add package HCGStudio.DistributionChecker
```

Usage :
``` CSharp
var distribution = new DistributionChecker().GetDistribution();
```
And you will get all the information you need.

We also have some Extenstion methods such as:
``` CSharp
distribution.IsUbuntu();
distribution.IsLikeRedHat();
distribution.IsOrLikeArchLinux();
//...
//Of course there are some more!
```
These methods work just like their names. 

## How it works

It reads your /etc/os-release and parase with DFA.
Information about os-release was found at https://www.freedesktop.org/software/systemd/man/os-release.html and many XML documents are from it.
