using System;
using System.Windows.Forms;
using System.IO;

namespace PasswordManagerProject
{
    class FileSaver
    {
        public FileSaver(TextBox platformText, TextBox nameText, TextBox passwordText, ComboBox platformDropDown)
        {
            _platformBoxText = platformText;
            _nameBoxText = nameText;
            _passwordBoxText = passwordText;
            _platformDropDown = platformDropDown;
        }

        TextBox _platformBoxText;
        TextBox _nameBoxText;
        TextBox _passwordBoxText;
        ComboBox _platformDropDown;

        public void SaveFile()
        {
            string platform = _platformBoxText.Text.Trim();
            string name = _nameBoxText.Text.Trim();
            string password = _passwordBoxText.Text.Trim();
            DateTime dateCreated = DateTime.Now;

            WritePMFInDirectory(platform, CreatePIObjectAndAddToList(platform, name, password, dateCreated));

            Utilities.AddItemToDropDown(_platformDropDown, platform);
            Utilities.NotifyUser();
            Utilities.ClearTextBoxes(MainWindowForm.TextBoxArray);
            Utilities.DropDownState(_platformDropDown, true);
        }

        void WritePMFInDirectory(string platformName, PlatformInformation passwordFile)
        {
            try
            {
                StreamWriter writer = new StreamWriter(MainWindowForm.MainDirectory + @"\" + platformName + @".pmf");
                writer.Write("Email / Username: " + passwordFile.Email);
                writer.WriteLine();
                writer.Write("Password: " + passwordFile.Password);
                writer.WriteLine();
                writer.Write("Creation Date: " + passwordFile.DateCreated);
                writer.Close();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Save folder not found! \n" +
                    "Shutting down the program.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static PlatformInformation CreatePIObjectAndAddToList(string platform, string name, string password, DateTime dateCreated)
        {
            PlatformInformation passwordFile = new PlatformInformation(platform, name, password, dateCreated);
            MainWindowForm.PasswordsList.Add(passwordFile);
            return passwordFile;
        }

    }
}
