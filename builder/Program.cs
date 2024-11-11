var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

foreach (var file in dir.Parent?.GetFiles("*.html", new EnumerationOptions() { RecurseSubdirectories = true }) ?? [])
{
    Console.WriteLine(file.FullName);
    using var fileStrem = file.OpenText();
    Console.WriteLine(fileStrem.ReadToEnd());
}
