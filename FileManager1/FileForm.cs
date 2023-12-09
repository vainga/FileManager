using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileManager1
{
    public partial class FileForm : Form
    {
        public string FileName { get; set; }
        public int UserId { get; set; }
        public string accessLevel {  get; set; }

        public FileForm()
        {
            InitializeComponent();
            LoadUserList();
        }

        private int elementCounter = 0;
        private List<ComboBox> userLoginComboBoxes = new List<ComboBox>();
        private List<bool> radioButtonStatuses = new List<bool>();

        private List<RadioButton> radioButtonFullBanDynamicRBs = new List<RadioButton>();
        private List<RadioButton> radioButtonOnlyReadDynamicRBs = new List<RadioButton>();
        private List<RadioButton> radioButtonReadAndWriteDynamicRBs = new List<RadioButton>();

        public void HiddenForCreateFile()
        {
            buttonSave2.Visible = false;
        }

        public void HiddenForOpenFile()
        {
            textBoxFileName.Visible = false;
            panel1.Visible = false;
            buttonSave.Visible = false;
            buttonSave2.Visible = true;
            labelFileName.Visible = true;
        }

        public void OpenFile()
        {
            labelFileName.Visible = true;
            labelFileName.Text = FileName;

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", FileName + ".txt");
            string fileContent = File.ReadAllText(filePath);

            richTextBoxFileContent.Text = fileContent;
        }

        public string[] GetUsers()
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            using (SqliteConnection connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();
                string query = "SELECT Login FROM Users";
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        var users = new System.Collections.Generic.List<string>();
                        while (reader.Read())
                        {
                            users.Add(reader["Login"].ToString());
                        }
                        return users.ToArray();
                    }
                }
            }
        }

        private void AddDynamicElements()
        {
            elementCounter++;
            int x = labelAccessLevel.Location.X;

            Panel panelDynamic = new Panel();
            panelDynamic.Location = new System.Drawing.Point(x, 180 + (elementCounter - 1) * 150);
            panelDynamic.Size = new System.Drawing.Size(x + 100, 170);

            System.Windows.Forms.Label labelAccessLevelDynamic = new System.Windows.Forms.Label();
            labelAccessLevelDynamic.Text = labelAccessLevel.Text;
            labelAccessLevelDynamic.Size = labelAccessLevel.Size;
            labelAccessLevelDynamic.Location = new System.Drawing.Point(0, 0);
            panelDynamic.Controls.Add(labelAccessLevelDynamic);

            ComboBox comboBoxUserLoginDynamic = new ComboBox();
            comboBoxUserLoginDynamic.Size = comboBoxUserLogin.Size;
            string[] usersDynamic = GetUsers();
            comboBoxUserLoginDynamic.Items.AddRange(usersDynamic);
            comboBoxUserLoginDynamic.Location = new System.Drawing.Point(0, 20);
            panelDynamic.Controls.Add(comboBoxUserLoginDynamic);
            userLoginComboBoxes.Add(comboBoxUserLoginDynamic);

            RadioButton radioButtonFullBanDynamic = new RadioButton();
            radioButtonFullBanDynamic.Text = radioButtonFullBan.Text;
            radioButtonFullBanDynamic.Size = radioButtonFullBan.Size;
            radioButtonFullBanDynamic.Location = new System.Drawing.Point(0, 50);
            panelDynamic.Controls.Add(radioButtonFullBanDynamic);
            radioButtonFullBanDynamicRBs.Add(radioButtonFullBanDynamic);

            RadioButton radioButtonOnlyReadDynamic = new RadioButton();
            radioButtonOnlyReadDynamic.Text = radioButtonOnlyRead.Text;
            radioButtonOnlyReadDynamic.Size = radioButtonOnlyRead.Size;
            radioButtonOnlyReadDynamic.Location = new System.Drawing.Point(0, 80);
            panelDynamic.Controls.Add(radioButtonOnlyReadDynamic);
            radioButtonOnlyReadDynamicRBs.Add(radioButtonOnlyReadDynamic);

            RadioButton radioButtonReadAndWriteDynamic = new RadioButton();
            radioButtonReadAndWriteDynamic.Text = radioButtonReadAndWrite.Text;
            radioButtonReadAndWriteDynamic.Size = radioButtonReadAndWrite.Size;
            radioButtonReadAndWriteDynamic.Location = new System.Drawing.Point(0, 110);
            panelDynamic.Controls.Add(radioButtonReadAndWriteDynamic);
            radioButtonReadAndWriteDynamicRBs.Add(radioButtonReadAndWriteDynamic);

            radioButtonFullBanDynamic.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonOnlyReadDynamic.CheckedChanged += RadioButton_CheckedChanged;
            radioButtonReadAndWriteDynamic.CheckedChanged += RadioButton_CheckedChanged;

            panel1.Controls.Add(panelDynamic);

        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton currentRadioButton = (RadioButton)sender;
            int index = userLoginComboBoxes.FindIndex(c => c == currentRadioButton.Parent.Controls.OfType<ComboBox>().FirstOrDefault());

            if (index >= 0 && index < radioButtonStatuses.Count)
            {
                radioButtonStatuses[index] = currentRadioButton.Checked;
            }
        }

        private void LoadUserList()
        {
            string[] users = GetUsers();
            comboBoxUserLogin.Items.AddRange(users);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string fileName = textBoxFileName.Text;
            string content = richTextBoxFileContent.Text;

            if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(content))
            {
                string filesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
                Directory.CreateDirectory(filesFolderPath);

                string filePath = Path.Combine(filesFolderPath, fileName + ".txt");
                File.WriteAllText(filePath, content);

                string selectedUser = comboBoxUserLogin.SelectedItem?.ToString();

                string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", fileName + ".db");
                string connectionString = $"Data Source={dbFilePath}";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    string createTableQuery = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY AUTOINCREMENT, Login TEXT, AccessLevel TEXT)";
                    using (SqliteCommand createTableCommand = new SqliteCommand(createTableQuery, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }

                    string accessLevel = GetAccessLevel(radioButtonFullBan.Checked, radioButtonOnlyRead.Checked, radioButtonReadAndWrite.Checked);
                    string insertUserQuery = $"INSERT INTO Users (Login, AccessLevel) VALUES ('{selectedUser}', '{accessLevel}')";
                    using (SqliteCommand insertUserCommand = new SqliteCommand(insertUserQuery, connection))
                    {
                        insertUserCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < userLoginComboBoxes.Count; i++)
                    {
                        ComboBox comboBox = userLoginComboBoxes[i];
                        RadioButton radioButtonFullBan = radioButtonFullBanDynamicRBs[i];
                        RadioButton radioButtonOnlyRead = radioButtonOnlyReadDynamicRBs[i];
                        RadioButton radioButtonReadAndWrite = radioButtonReadAndWriteDynamicRBs[i];

                        string userLogin = comboBox.SelectedItem?.ToString();
                        string accessLevelDynamic = GetAccessLevel(radioButtonFullBan.Checked, radioButtonOnlyRead.Checked, radioButtonReadAndWrite.Checked);

                        string insertDynamicInfoQuery = $"INSERT INTO Users (Login, AccessLevel) VALUES ('{userLogin}', '{accessLevelDynamic}')";
                        using (SqliteCommand insertDynamicInfoCommand = new SqliteCommand(insertDynamicInfoQuery, connection))
                        {
                            insertDynamicInfoCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Файл успешно сохранен");
                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите имя файла и его содержание.");
            }
        }

        private string GetAccessLevel(bool fullBan, bool onlyRead, bool readAndWrite)
        {
            if (fullBan)
            {
                return "Full Ban";
            }
            else if (onlyRead)
            {
                return "Read Only";
            }
            else if (readAndWrite)
            {
                return "Read and Write";
            }

            return string.Empty;
        }


        private void buttonPlus_Click(object sender, EventArgs e)
        {
            AddDynamicElements();
        }

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            if (accessLevel == "Read and Write")
            {
                string content = richTextBoxFileContent.Text;
                string filesFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
                Directory.CreateDirectory(filesFolderPath);
                string filePath = Path.Combine(filesFolderPath, FileName + ".txt");
                File.WriteAllText(filePath, content);
                MessageBox.Show("Файл успешно сохранен");
                this.Close();
            }
            else
            {
                MessageBox.Show("В редактировании отказано!");
            }
        }
    }
}
