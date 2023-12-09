namespace FileManager1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonCreateFile = new Button();
            buttonOpenFile = new Button();
            listViewFiles = new ListView();
            buttonUpdate = new Button();
            SuspendLayout();
            // 
            // buttonCreateFile
            // 
            buttonCreateFile.Location = new Point(31, 26);
            buttonCreateFile.Name = "buttonCreateFile";
            buttonCreateFile.Size = new Size(131, 71);
            buttonCreateFile.TabIndex = 0;
            buttonCreateFile.Text = "Создать";
            buttonCreateFile.UseVisualStyleBackColor = true;
            buttonCreateFile.Click += buttonCreateFile_Click;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Location = new Point(31, 116);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(131, 71);
            buttonOpenFile.TabIndex = 1;
            buttonOpenFile.Text = "Открыть";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // listViewFiles
            // 
            listViewFiles.Location = new Point(197, 26);
            listViewFiles.MultiSelect = false;
            listViewFiles.Name = "listViewFiles";
            listViewFiles.Size = new Size(591, 412);
            listViewFiles.TabIndex = 2;
            listViewFiles.UseCompatibleStateImageBehavior = false;
            listViewFiles.View = View.Details;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(31, 206);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(131, 34);
            buttonUpdate.TabIndex = 3;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonUpdate);
            Controls.Add(listViewFiles);
            Controls.Add(buttonOpenFile);
            Controls.Add(buttonCreateFile);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateFile;
        private Button buttonOpenFile;
        private ListView listViewFiles;
        private Button buttonUpdate;
    }
}