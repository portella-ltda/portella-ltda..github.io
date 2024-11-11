using System;
using System.IO;
var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
Console.WriteLine(string.Join('\n', dir.Parent?.GetFiles("*.html", new EnumerationOptions() { RecurseSubdirectories = true })?.Select(d => d.FullName) ?? []));
