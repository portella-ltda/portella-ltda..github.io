using System;
using System.IO;
var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
Console.WriteLine(dir.Parent?.FullName);
