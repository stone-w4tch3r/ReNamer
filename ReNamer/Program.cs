Console.WriteLine("Welcome to ReNamer!");

var currDirectory = Directory.GetCurrentDirectory();

Console.WriteLine("Current directory is:");
Console.WriteLine(currDirectory);
Console.WriteLine();

Console.WriteLine("List of all files:");
var files = GetAllFiles(currDirectory);
foreach (var file in files) 
    Console.WriteLine(file);

Console.WriteLine();
Console.WriteLine("Specify substring to replace:");
var oldSubstring = Console.ReadLine()!;
Console.WriteLine("Specify new substring:");
var newSubstring = Console.ReadLine()!;

RenameFiles(files, oldSubstring, newSubstring);

Console.WriteLine();
Console.WriteLine("List of all files:");
foreach (var file in GetAllFiles(currDirectory))
    Console.WriteLine(file);
Console.ReadKey();

IEnumerable<string> GetAllFiles(string currDirectory)
{
    var files = (IEnumerable<string>)Directory.GetFiles(currDirectory);
    var directories = (IEnumerable<string>)Directory.GetDirectories(currDirectory);
    foreach (var directory in directories)
    {
        files = files.Concat(GetAllFiles(directory));
    }
    return files;
}

void RenameFiles(IEnumerable<string> files, string oldSubstring, string newSubstring)
{
    foreach (var file in files.Where(f => f.Contains(oldSubstring)))
        File.Move(file, file.Replace(oldSubstring, newSubstring));
}