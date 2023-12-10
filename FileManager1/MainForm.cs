using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System.Reflection.Metadata;

namespace FileManager1
{
    public partial class MainForm : Form
    {
        public int userId { get; set; }
        private string selectedFileName;

        public MainForm()
        {
            InitializeComponent();
            LoadFileNamesToListView();
            userId = User.UID;
            listViewFiles.SelectedIndexChanged += listViewFiles_SelectedIndexChanged;
        }

        private string GetLogin(int UserId)
        {
            string login = null;

            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            using (SqliteConnection connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();
                string query = $"SELECT Login FROM Users WHERE Id = @Id";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userId);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            login = reader.GetString(0);
                            connection.Close();
                            return login;
                        }
                    }
                }
                connection.Close();
            }
            return login;
        }

        public string GetAccessLevel(string login)
        {
            string accessLevel = null;

            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", selectedFileName + ".db");
            string connectionString = $"Data Source={dbFilePath}";
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string query = $"SELECT AccessLevel FROM Users WHERE Login = @Login";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            accessLevel = reader.GetString(0);
                            connection.Close();
                            return accessLevel;
                        }
                    }
                }
                connection.Close();
            }
            return accessLevel;
        }

        private void LoadFileNamesToListView()
        {
            listViewFiles.Items.Clear();

            listViewFiles.Columns.Add("Файлы:", 500);

            string filesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

            if (Directory.Exists(filesFolderPath))
            {
                string[] txtFiles = Directory.GetFiles(filesFolderPath, "*.txt");

                foreach (string txtFile in txtFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(txtFile);

                    ListViewItem item = new ListViewItem(fileName);

                    listViewFiles.Items.Add(item);
                }
            }
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count > 0)
            {
                selectedFileName = listViewFiles.SelectedItems[0].Text;
            }
            else
            {
                selectedFileName = null;
            }
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            FileForm fileForm = new FileForm();
            fileForm.HiddenForCreateFile();
            fileForm.Show();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFileName))
            {
                MessageBox.Show("Выберите файл для открытия.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (GetAccessLevel(GetLogin(userId)) == "Read Only" || GetAccessLevel(GetLogin(userId)) == "Read and Write")
            {
                FileForm fileForm = new FileForm();
                fileForm.FileName = selectedFileName;
                fileForm.UserId = userId;
                fileForm.accessLevel = GetAccessLevel(GetLogin(userId));
                fileForm.HiddenForOpenFile();
                fileForm.OpenFile();
                fileForm.Show();
            }
            else
            {
                MessageBox.Show("В доступе отказано!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            listViewFiles.Items.Clear();
            string filesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");

            if (Directory.Exists(filesFolderPath))
            {
                string[] txtFiles = Directory.GetFiles(filesFolderPath, "*.txt");

                foreach (string txtFile in txtFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(txtFile);

                    ListViewItem item = new ListViewItem(fileName);

                    listViewFiles.Items.Add(item);
                }
            }
        }
    }
}
