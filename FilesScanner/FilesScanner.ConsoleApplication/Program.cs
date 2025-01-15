using System.Text.Json;
using FilesScanner.Common.Helper;
using Microsoft.Extensions.Configuration;

// Get allowed file extensions from configuration
var allowedFileExtensions = new HashSet<string> { ".c", ".h", ".cpp", ".rc" };

// Get base folder path from command-line arguments or prompt the user
string baseFolderPath = args.Length > 0 ? args[0] : GetBaseFolderPathFromUser();

try
{
    if (string.IsNullOrWhiteSpace(baseFolderPath) || !Directory.Exists(baseFolderPath))
    {
        Console.WriteLine("Invalid or non-existent folder path provided. Exiting.");
        return;
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

var fileScanner = new FileScannerHelper();


// Initialize dictionaries
var filePathsByFileName = new Dictionary<string, HashSet<string>>();
var subFolderPathsByFileName = new Dictionary<string, string>();
var exceptionList = new List<string>();

// Process the directory
fileScanner.ProcessDirectory(baseFolderPath, filePathsByFileName, baseFolderPath, subFolderPathsByFileName, allowedFileExtensions, exceptionList);

// Group and display the output
var groupedFiles = new Dictionary<string, string>();
foreach (var entry in filePathsByFileName)
{
    var directoryKey = string.Empty;
    foreach (var directory in entry.Value)
    {
        directoryKey += $"/{directory}";
    }
    if (!groupedFiles.ContainsKey(directoryKey))
    {
        groupedFiles[directoryKey] = string.Empty;
    }
    groupedFiles[directoryKey] += $",{entry.Key}";
}

Console.WriteLine("Files Scanned:\n");

foreach (var group in groupedFiles)
{
    foreach (var directory in group.Key.Split('/'))
    {
        if (!string.IsNullOrEmpty(directory))
            Console.WriteLine($"/{directory}");
    }
    foreach (var file in group.Value.Split(','))
    {
        if (!string.IsNullOrEmpty(file))
        {
            if (subFolderPathsByFileName.ContainsKey(file))
            {
                Console.WriteLine($"\t{file} - {subFolderPathsByFileName[file].Trim(',')}");
            }
            else
            {
                Console.WriteLine($"\t{file}");
            }
        }
    }
}

Console.WriteLine("\nExceptions:");
Console.ReadLine();

foreach(var ex in exceptionList)
{
    Console.WriteLine(ex);
}

string GetBaseFolderPathFromUser()
{
    Console.WriteLine("Please provide the root folder path:");
    return Console.ReadLine() ?? string.Empty;
}


