File Scanner - README

#Functionality
This application is designed to scan a directory and its subdirectories, identify files with specific extensions, and display their paths grouped by directories (means files having common directories will be grouped together). It supports multiple file extensions like '.c, .h, .cpp, and .rc'. The output is displayed in a formatted structure, showing the directories and corresponding files.

#Key Features
1. File Scanning: The program scans the directory and subdirectories to find files with the specified extensions.
2. Directory Grouping: Files are grouped based on their directories for a structured output.
3. Relative Path Calculation: The application calculates relative paths from the root directory and displays them for better readability.
4. Exceptions Handling: The program captures and displays exceptions, such as unauthorized access or errors during directory processing.

#How It Works
- User provides a root folder path, which can be either passed as a command-line argument or input manually. (Screen Shots of the testing is attached to the folder).
- The application then recursively scans the directory and subdirectories for files with extensions defined in the configuration (.c, .h, .cpp, .rc).
- Files are grouped by their directory paths, and results are displayed in a hierarchical structure in the UI.

#Requirements
- .NET 8 runtime and SDK.
- Visual Studio or a similar IDE with support for C# development.
- Git for cloning the repository (if applicable).

#Installations
-Clone the Repository First, clone the repository to your local machine:
	- git clone https://github.com/sunilpattar99/file-scanner.git
- Open the solution file available inside file-scanner/FileScanner using VS2022 or any other IDE for Dotnet, make sure to install the Dotnet 8 runtime and SDK before itself.

#Multithreading
- Currently the application is not multi threaded, but can be made mutithreaded using Parallel.ForEach loops, this way we can optimize the applications even further.

#Performance Constraints
- The time complexity for scanning all directories and files is O(n),
- Time Complexity for Grouping Files: O(m), where m is the number of files
- Time Complexity for Recursive Directory Processing: O(d), where d is the number of directories in the file system
- When scanning a large number of files and directories, the performance could degrade due to the following factors:
	- Disk I/O.
	- Memory Usage.

#Performance Optimization Recommendations:
- Multithreading
- Asynchronous File Access
- Batch Processing

