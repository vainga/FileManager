using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager1
{
    public class User
    {
        public int userId;
        public static int UID {  get; set; }
        public string _Login { get; set; }
        public string _Password { get; set; }

        public User()
        {
            _Login = "";
            _Password = "";
        }

        private User(string login, string password)
        {
            _Login = login;
            _Password = password;
        }

        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(6);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        private bool IsLoginUnique(string login)
        {
            bool isUnique = false;
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();

                using (var checkLoginCommand = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE Login = @Login", connection))
                {
                    checkLoginCommand.Parameters.AddWithValue("@Login", login);

                    int result = Convert.ToInt32(checkLoginCommand.ExecuteScalar());
                    if (result != 0)
                    {
                        return isUnique;
                    }
                    isUnique = (result == 0);
                }

                connection.Close();
            }
            return isUnique;
        }
        public int Enter(string login, string password)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);

            User user = new User();
            user._Login = login;
            user._Password = password;

            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();
                using (SqliteCommand cmd = new SqliteCommand("SELECT Id, Password FROM Users WHERE Login=@Login", connection))
                {
                    cmd.Parameters.AddWithValue("@Login", user._Login);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHashedPassword = reader["Password"] as string;
                            user.userId = reader.GetInt32(reader.GetOrdinal("Id"));

                            if (BCrypt.Net.BCrypt.Verify(user._Password, storedHashedPassword))
                            {
                                return user.userId;
                            }
                            else
                            {
                                MessageBox.Show("Пароль не совпадет!");
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден!");
                            Application.Exit();
                        }
                    }
                }
                connection.Close();
            }
            return -1;
        }

        public int Registration(string login, string password)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            string parentPath = Directory.GetParent(executablePath).FullName;
            string dataFolderPath = Path.Combine(parentPath, "Data");
            string userFolderPath = Path.Combine(dataFolderPath, "UserData");
            Directory.CreateDirectory(userFolderPath);
            
            User user = new User();
            user._Login = login;
            user._Password = password;


            using (var connection = new SqliteConnection($"Data Source={Path.Combine(userFolderPath, "userdata.db")}"))
            {
                connection.Open();

                using (var createTableCommand = new SqliteCommand("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY,Login TEXT, Password TEXT)", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                string hashedPassword = user.HashPassword(user._Password);
                if (!user.IsLoginUnique(user._Login))
                {
                    connection.Close();
                    return -1;
                }
                else
                {
                    using (var insertCommand = new SqliteCommand("INSERT INTO Users (Login, Password) VALUES (@Login, @Password); SELECT last_insert_rowid();", connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Login", user._Login);
                        insertCommand.Parameters.AddWithValue("@Password", hashedPassword);

                        user.userId = Convert.ToInt32(insertCommand.ExecuteScalar());
                    }
                    connection.Close();
                    return user.userId;
                }
            }
        }
    }
}
