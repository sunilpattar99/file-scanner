using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesScanner.Common.Helper
{
    public class FileScannerHelper
    {
        /// <summary>
        /// This Method will process the project directories and check each file recursivly with the provided extensions value,
        /// we will be populating filePathByFileName dictionary with key as file name, and its value will be hashset of common parents directories.
        /// Also we will be populating the subFolderPathsByFileName in this we will capture the relative subfolders nested path for extra information to be displayed.
        /// ExceptionList will handile the exceptions incase of in-accessible files and same will be shown in output.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePathsByFileName"></param>
        /// <param name="rootDirectory"></param>
        /// <param name="subFolderPathsByFileName"></param>
        /// <param name="allowedExtensions"></param>
        /// <param name="exceptionsList"></param>
        public void ProcessDirectory(string directory, Dictionary<string, HashSet<string>> filePathsByFileName,
        string rootDirectory, Dictionary<string, string> subFolderPathsByFileName, HashSet<string> allowedExtensions, List<string> exceptionsList)
        {
            try
            {
                // Get files in the current directory
                foreach (var file in Directory.GetFiles(directory))
                {
                    string fileName = Path.GetFileName(file);
                    string fileExtension = Path.GetExtension(file);

                    // Check if the file has an allowed extension
                    if (!allowedExtensions.Contains(fileExtension.ToLower()))
                    {
                        continue;
                    }

                    string relativePath = directory.Replace(rootDirectory, string.Empty).TrimStart(Path.DirectorySeparatorChar);//Get the relative path
                    string parentDirectory = relativePath.Split('\\').Length > 1 ? relativePath.Split('\\')[0] : relativePath;

                    // Add file to the dictionary
                    if (!filePathsByFileName.ContainsKey(fileName))
                    {
                        filePathsByFileName[fileName] = new HashSet<string>();
                    }

                    if (!string.IsNullOrEmpty(relativePath) && relativePath.Split('\\').Length > 1)
                    {
                        if (!subFolderPathsByFileName.ContainsKey(fileName))
                        {
                            subFolderPathsByFileName[fileName] = string.Empty;
                        }
                        subFolderPathsByFileName[fileName] += "," + relativePath;//add the relative subfolder path incase of nested files
                    }

                    filePathsByFileName[fileName].Add(parentDirectory);
                }

                // Recursively process subdirectories
                foreach (var subDir in Directory.GetDirectories(directory))
                {
                    ProcessDirectory(subDir, filePathsByFileName, rootDirectory, subFolderPathsByFileName, allowedExtensions, exceptionsList);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                exceptionsList.Add($"Access denied to directory: {directory}. Error: {ex.Message}");
                //Console.WriteLine($"Access denied to directory: {directory}. Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                exceptionsList.Add($"An error occurred while processing directory: {directory}. Error: {ex.Message}");
                //Console.WriteLine($"An error occurred while processing directory: {directory}. Error: {ex.Message}");
            }
        }

    }
}
