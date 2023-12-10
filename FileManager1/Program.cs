using Microsoft.VisualBasic.ApplicationServices;

namespace FileManager1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>=
        [STAThread]
        static void Main()
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 loginForm = new Form1();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
        }

    }
}