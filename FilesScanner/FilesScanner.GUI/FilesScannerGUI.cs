using FilesScanner.Common.Helper;

namespace FilesScanner.GUI
{
    public partial class FilesScannerGUI : Form
    {
        private readonly HashSet<string> _allowedFileExtensions = new() { ".c", ".h", ".cpp", ".rc" };
        private readonly string _basePath = string.Empty;
        public FilesScannerGUI(string basePath)
        {
            _basePath = basePath;
            
            InitializeComponent();
            if (!string.IsNullOrEmpty(basePath))
            {
                baseDirectoryPathInputBox.Text = basePath;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string baseFolderPath = baseDirectoryPathInputBox.Text;

            if (string.IsNullOrWhiteSpace(baseFolderPath) || !Directory.Exists(baseFolderPath))
            {
                MessageBox.Show("Please provide a valid folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fileScanner = new FileScannerHelper();
            var displayOutput = new CreateOutput();

            // Initialize dictionaries
            var filePathsByFileName = new Dictionary<string, HashSet<string>>();
            var subFolderPathsByFileName = new Dictionary<string, string>();
            var exceptionList = new List<string>();

            // Process the directory
            fileScanner.ProcessDirectory(baseFolderPath, filePathsByFileName, baseFolderPath, subFolderPathsByFileName, _allowedFileExtensions, exceptionList);

            // Display results
            displayOutput.DisplayResults(filePathsByFileName, subFolderPathsByFileName, exceptionList, outputList, errorsBox);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void errorsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                baseDirectoryPathInputBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
