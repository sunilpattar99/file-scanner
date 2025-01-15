using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FilesScanner.GUI
{
    internal class CreateOutput
    {
        public void DisplayResults(
    Dictionary<string, HashSet<string>> filePathsByFileName,
    Dictionary<string, string> subFolderPathsByFileName, List<string> exceptionList, ListBox lstResults, ListBox exceptionsList)
        {
            lstResults.Items.Clear();
            exceptionsList.Items.Clear();
            // Group files by their directories
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

            // Display grouped results
            foreach (var group in groupedFiles)
            {
                foreach (var directory in group.Key.Split('/'))
                {
                    if (!string.IsNullOrEmpty(directory))
                    {
                        lstResults.Items.Add($"/{directory}");
                    }
                }

                foreach (var file in group.Value.Split(','))
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (subFolderPathsByFileName.ContainsKey(file))
                        {
                            lstResults.Items.Add($"\t{file} - {subFolderPathsByFileName[file].Trim(',')}");
                        }
                        else
                        {
                            lstResults.Items.Add($"\t{file}");
                        }
                    }
                }
            }

            // Display exceptions
            if (groupedFiles.Count == 0)
            {
                lstResults.Items.Add("No files found matching the allowed extensions.");
            }

            if (exceptionList != null && exceptionList.Count > 0) 
            {
                foreach (var ex in exceptionList) 
                {
                    exceptionsList.Items.Add(ex);
                }
            }
        }
    }
}
