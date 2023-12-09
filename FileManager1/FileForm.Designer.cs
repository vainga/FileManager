namespace FileManager1
{
    partial class FileForm
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
            richTextBoxFileContent = new RichTextBox();
            textBoxFileName = new TextBox();
            label1 = new Label();
            buttonSave = new Button();
            radioButtonFullBan = new RadioButton();
            radioButtonOnlyRead = new RadioButton();
            radioButtonReadAndWrite = new RadioButton();
            labelAccessLevel = new Label();
            comboBoxUserLogin = new ComboBox();
            buttonPlus = new Button();
            panel1 = new Panel();
            labelFileName = new Label();
            buttonSave2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBoxFileContent
            // 
            richTextBoxFileContent.Location = new Point(272, 83);
            richTextBoxFileContent.Name = "richTextBoxFileContent";
            richTextBoxFileContent.Size = new Size(699, 414);
            richTextBoxFileContent.TabIndex = 0;
            richTextBoxFileContent.Text = "";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(357, 39);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(614, 23);
            textBoxFileName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 42);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 2;
            label1.Text = "Имя файла:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(862, 503);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(109, 66);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // radioButtonFullBan
            // 
            radioButtonFullBan.AutoSize = true;
            radioButtonFullBan.Location = new Point(23, 87);
            radioButtonFullBan.Name = "radioButtonFullBan";
            radioButtonFullBan.Size = new Size(110, 19);
            radioButtonFullBan.TabIndex = 4;
            radioButtonFullBan.TabStop = true;
            radioButtonFullBan.Text = "Полный запрет";
            radioButtonFullBan.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlyRead
            // 
            radioButtonOnlyRead.AutoSize = true;
            radioButtonOnlyRead.Location = new Point(23, 112);
            radioButtonOnlyRead.Name = "radioButtonOnlyRead";
            radioButtonOnlyRead.Size = new Size(105, 19);
            radioButtonOnlyRead.TabIndex = 5;
            radioButtonOnlyRead.TabStop = true;
            radioButtonOnlyRead.Text = "Только чтение";
            radioButtonOnlyRead.UseVisualStyleBackColor = true;
            // 
            // radioButtonReadAndWrite
            // 
            radioButtonReadAndWrite.AutoSize = true;
            radioButtonReadAndWrite.Location = new Point(23, 137);
            radioButtonReadAndWrite.Name = "radioButtonReadAndWrite";
            radioButtonReadAndWrite.Size = new Size(114, 19);
            radioButtonReadAndWrite.TabIndex = 6;
            radioButtonReadAndWrite.TabStop = true;
            radioButtonReadAndWrite.Text = "Чтение и запись";
            radioButtonReadAndWrite.UseVisualStyleBackColor = true;
            // 
            // labelAccessLevel
            // 
            labelAccessLevel.AutoSize = true;
            labelAccessLevel.Location = new Point(23, 40);
            labelAccessLevel.Name = "labelAccessLevel";
            labelAccessLevel.Size = new Size(124, 15);
            labelAccessLevel.TabIndex = 7;
            labelAccessLevel.Text = "Уровень доступа для:";
            // 
            // comboBoxUserLogin
            // 
            comboBoxUserLogin.FormattingEnabled = true;
            comboBoxUserLogin.Location = new Point(23, 58);
            comboBoxUserLogin.Name = "comboBoxUserLogin";
            comboBoxUserLogin.Size = new Size(121, 23);
            comboBoxUserLogin.TabIndex = 8;
            // 
            // buttonPlus
            // 
            buttonPlus.Font = new Font("Segoe UI Light", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonPlus.Location = new Point(153, 48);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(50, 33);
            buttonPlus.TabIndex = 9;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += buttonPlus_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(radioButtonReadAndWrite);
            panel1.Controls.Add(buttonPlus);
            panel1.Controls.Add(radioButtonOnlyRead);
            panel1.Controls.Add(labelAccessLevel);
            panel1.Controls.Add(comboBoxUserLogin);
            panel1.Controls.Add(radioButtonFullBan);
            panel1.Location = new Point(12, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(236, 414);
            panel1.TabIndex = 10;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Location = new Point(359, 43);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(0, 15);
            labelFileName.TabIndex = 11;
            labelFileName.Visible = false;
            // 
            // buttonSave2
            // 
            buttonSave2.Location = new Point(862, 503);
            buttonSave2.Name = "buttonSave2";
            buttonSave2.Size = new Size(109, 66);
            buttonSave2.TabIndex = 12;
            buttonSave2.Text = "Сохранить";
            buttonSave2.UseVisualStyleBackColor = true;
            buttonSave2.Click += buttonSave2_Click;
            // 
            // FileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 584);
            Controls.Add(buttonSave2);
            Controls.Add(labelFileName);
            Controls.Add(panel1);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Controls.Add(textBoxFileName);
            Controls.Add(richTextBoxFileContent);
            Name = "FileForm";
            Text = "FileForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBoxFileContent;
        private TextBox textBoxFileName;
        private Label label1;
        private Button buttonSave;
        private RadioButton radioButtonFullBan;
        private RadioButton radioButtonOnlyRead;
        private RadioButton radioButtonReadAndWrite;
        private Label labelAccessLevel;
        private ComboBox comboBoxUserLogin;
        private Button buttonPlus;
        private Panel panel1;
        private Label labelFileName;
        private Button buttonSave2;
    }
}