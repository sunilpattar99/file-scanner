namespace FilesScanner.GUI
{
    partial class FilesScannerGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            baseDirectoryPathInputBox = new TextBox();
            submitButton = new Button();
            textLabel = new Label();
            outpuyViewLabel = new Label();
            errorsBox = new ListBox();
            errorsLabel = new Label();
            browseButton = new Button();
            outputList = new ListBox();
            SuspendLayout();
            // 
            // baseDirectoryPathInputBox
            // 
            baseDirectoryPathInputBox.Location = new Point(12, 63);
            baseDirectoryPathInputBox.Name = "baseDirectoryPathInputBox";
            baseDirectoryPathInputBox.Size = new Size(738, 27);
            baseDirectoryPathInputBox.TabIndex = 0;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(12, 112);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 1;
            submitButton.Text = "Scan";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new Point(12, 30);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(159, 20);
            textLabel.TabIndex = 3;
            textLabel.Text = "Enter Base Folder Path:";
            // 
            // outpuyViewLabel
            // 
            outpuyViewLabel.AutoSize = true;
            outpuyViewLabel.Location = new Point(16, 162);
            outpuyViewLabel.Name = "outpuyViewLabel";
            outpuyViewLabel.Size = new Size(101, 20);
            outpuyViewLabel.TabIndex = 4;
            outpuyViewLabel.Text = "Files Scanned:";
            // 
            // errorsBox
            // 
            errorsBox.FormattingEnabled = true;
            errorsBox.Location = new Point(12, 600);
            errorsBox.Name = "errorsBox";
            errorsBox.Size = new Size(981, 104);
            errorsBox.TabIndex = 5;
            // 
            // errorsLabel
            // 
            errorsLabel.AutoSize = true;
            errorsLabel.Location = new Point(16, 568);
            errorsLabel.Name = "errorsLabel";
            errorsLabel.Size = new Size(50, 20);
            errorsLabel.TabIndex = 6;
            errorsLabel.Text = "Errors:";
            // 
            // browseButton
            // 
            browseButton.Location = new Point(756, 61);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(94, 29);
            browseButton.TabIndex = 7;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // listBox1
            // 
            outputList.FormattingEnabled = true;
            outputList.Location = new Point(12, 191);
            outputList.Name = "outputList";
            outputList.Size = new Size(981, 364);
            outputList.TabIndex = 8;
            // 
            // FilesScannerGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 731);
            Controls.Add(outputList);
            Controls.Add(browseButton);
            Controls.Add(errorsLabel);
            Controls.Add(errorsBox);
            Controls.Add(outpuyViewLabel);
            Controls.Add(textLabel);
            Controls.Add(submitButton);
            Controls.Add(baseDirectoryPathInputBox);
            Name = "FilesScannerGUI";
            Text = "Files Scanner - Find Files Effectively";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox baseDirectoryPathInputBox;
        private Button submitButton;
        private Label textLabel;
        private Label outpuyViewLabel;
        private ListBox errorsBox;
        private Label errorsLabel;
        private Button browseButton;
        private ListBox outputList;
    }
}
