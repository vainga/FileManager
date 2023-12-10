using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FileManager1
{
    public partial class Form1 : Form
    {

        public int UserId { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserId = user.Enter(textBoxLogin.Text, textBoxPassword.Text);
            User.UID = UserId;
            if (UserId != -1)
            {
                MainForm mainForm = new MainForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserId = user.Registration(textBoxLogin.Text, textBoxPassword.Text);
            User.UID = UserId;
            if (UserId != -1)
            {
                MainForm mainForm = new MainForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (UserId == -1)
            {
                MessageBox.Show("ѕользователь с таким логином уже существует!");
            }
        }
    }
}