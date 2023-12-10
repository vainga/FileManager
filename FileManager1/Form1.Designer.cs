namespace FileManager1
{
    partial class Form1
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
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            buttonEnter = new Button();
            buttonRegistration = new Button();
            SuspendLayout();
            // 
            // textBoxLogin
            // 
            textBoxLogin.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLogin.Location = new Point(135, 141);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(142, 23);
            textBoxLogin.TabIndex = 0;
            textBoxLogin.Text = "Логин...";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPassword.Location = new Point(135, 181);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(142, 23);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.Text = "Пароль...";
            // 
            // buttonEnter
            // 
            buttonEnter.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEnter.Location = new Point(135, 247);
            buttonEnter.Name = "buttonEnter";
            buttonEnter.Size = new Size(142, 56);
            buttonEnter.TabIndex = 2;
            buttonEnter.Text = "Вход";
            buttonEnter.UseVisualStyleBackColor = true;
            buttonEnter.Click += buttonEnter_Click;
            // 
            // buttonRegistration
            // 
            buttonRegistration.Font = new Font("Segoe UI Light", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonRegistration.Location = new Point(135, 309);
            buttonRegistration.Name = "buttonRegistration";
            buttonRegistration.Size = new Size(142, 37);
            buttonRegistration.TabIndex = 3;
            buttonRegistration.Text = "Регистарция";
            buttonRegistration.UseVisualStyleBackColor = true;
            buttonRegistration.Click += buttonRegistration_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(163, 234, 254);
            ClientSize = new Size(424, 450);
            Controls.Add(buttonRegistration);
            Controls.Add(buttonEnter);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button buttonEnter;
        private Button buttonRegistration;
    }
}