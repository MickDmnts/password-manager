using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Data;

#pragma warning disable
namespace PasswordManagerProject
{
    public partial class Form1 : Form
    {
        string mainDirectory;
        List<PlatformInformation> passwordsList = new List<PlatformInformation>();
        TextBox[] textBoxes;

        public Form1()
        { 
            InitializeComponent();

            CheckIfUsedBefore();
            LoadFiles();
            Cosmetics();
            PopulateTextBoxesArray();
        }

        void PopulateTextBoxesArray()
        {
            textBoxes = new TextBox[] { platformText, nameText, passwordText };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (CheckForBlankInput())
            {
                MessageBox.Show("An input field is blank, please review your input.", "Blank Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearTextBoxes();
                return;
            }
            else
            {
                SaveFile();
                Cosmetics();
            }
        }

        bool CheckForBlankInput()
        {
            if (string.IsNullOrWhiteSpace(platformText.Text))
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(nameText.Text))
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(passwordText.Text))
            {
                return true;
            }

            return false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + platformDropDown.Text + " password file?","Delete file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string filePath = mainDirectory + @"/" + platformDropDown.Text + @".pmf";
                File.Delete(filePath);

                foreach (PlatformInformation file in passwordsList)
                {
                    if (file.Platform == platformDropDown.Text)
                    {
                        passwordsList.Remove(file);
                        break;
                    }
                }

                platformDropDown.Items.RemoveAt(platformDropDown.SelectedIndex);
                platformDropDown.Update();
                Cosmetics();
            }
            else
            {
                return;
            }
        }

        private void platformDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfFile = platformDropDown.Text;
            SearchPIListForTheCorrectFile(nameOfFile);
        }

        private void copyEmailButton_Click(object sender, EventArgs e)
        {
            string fileName = platformDropDown.Text;
            foreach (PlatformInformation file in passwordsList)
            {
                if (file.Platform == fileName)
                {
                    Clipboard.SetText(file.Email);
                    return;
                }
            }

        }

        private void copyPasswordButton_Click(object sender, EventArgs e)
        {
            string fileName = platformDropDown.Text;
            foreach (PlatformInformation file in passwordsList)
            {
                if (file.Platform == fileName)
                {
                    Clipboard.SetText(file.Password);
                    return;
                }
            }
        }

        void CheckIfUsedBefore()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] directories = Directory.GetDirectories(path);
            if (directories.Contains(path + @"\Password Manager"))
            {
                SetMainDirectoryToPreviousPath(path);
            }
            else
            {
                DirectoryCreationIfFirstRun(path);
            }
        }

        void SetMainDirectoryToPreviousPath(string pathName)
        {
            mainDirectory = pathName + @"\Password Manager";
        }

        void DirectoryCreationIfFirstRun(string pathName)
        {
            DirectoryInfo directory = Directory.CreateDirectory(pathName + @"\Password Manager");
            directory.Attributes = FileAttributes.Hidden;
            mainDirectory = directory.FullName;
        }

        void SearchPIListForTheCorrectFile(string nameOfFile)
        {
            foreach (PlatformInformation file in passwordsList)
            {
                if (file.Platform == nameOfFile)
                {
                    WriteFileDataOnRTB(file);
                    return;
                }
            }
        }

        void WriteFileDataOnRTB(PlatformInformation correctFile)
        {
            StreamReader reader = new StreamReader(mainDirectory + @"\" + correctFile.Platform + @".pmf");
            fileInformationTextBox.Text = reader.ReadToEnd();
            reader.Close();
        }

        void SaveFile()
        {
            string platform = platformText.Text.Trim();
            string name = nameText.Text.Trim();
            string password = passwordText.Text.Trim();
            DateTime dateCreated = DateTime.Now;

            WritePMFInDirectory(platform,CreatePIObjectAndAddToList(platform, name, password,dateCreated));

            AddItemToDropDown(platform);
            NotifyUser();
            ClearTextBoxes();
            EnableDropDownBox();
        }

        void WritePMFInDirectory(string platformName,PlatformInformation passwordFile)
        {
            try
            {
                StreamWriter writer = new StreamWriter(mainDirectory + @"\" + platformName + @".pmf");
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

        PlatformInformation CreatePIObjectAndAddToList(string platform, string name, string password, DateTime dateCreated)
        {
            PlatformInformation passwordFile = new PlatformInformation(platform, name, password, dateCreated);
            passwordsList.Add(passwordFile);
            return passwordFile;
        }

        void EnableDropDownBox()
        {
            if (platformDropDown.Enabled == true)
            {
                platformDropDown.SelectedIndex = 0;
                return;
            }
            else
            {
                platformDropDown.Enabled = true;
            }
        }

        void AddItemToDropDown(string itemName)
        {
            platformDropDown.Items.Add(itemName);
        }

        void NotifyUser()
        {
            MessageBox.Show("File saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        void ClearTextBoxes()
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        void LoadFiles()
        {
            //Get the file names on a CreationTime order
            var filesInDirectoryByTime = new DirectoryInfo(mainDirectory).GetFiles().OrderBy(f => f.CreationTime).ToArray();
            string[] filesNamesInDirectory = new string[filesInDirectoryByTime.Length];
            for (int i = 0; i < filesInDirectoryByTime.Length; i++)
            {
                filesNamesInDirectory[i] = filesInDirectoryByTime[i].ToString();
                CreateLoadedFileObject(filesNamesInDirectory[i]);
            }
        }

        void CreateLoadedFileObject(string name)
        {
            StreamReader streamReader = new StreamReader(mainDirectory + @"\" + name);
            string fileEmail = streamReader.ReadLine().Replace("Email / Username: ", "");
            string filePassword = streamReader.ReadLine().Replace("Password: ", "");
            streamReader.Close();

            DateTime timeCreated = Directory.GetCreationTime(mainDirectory + @"\" + name + @".pmf");

            string fileNameWithoutExtension = name.Replace(".pmf", "");

            PlatformInformation fileToAdd = new PlatformInformation(fileNameWithoutExtension, fileEmail, filePassword, timeCreated);
            passwordsList.Add(fileToAdd);
            AddItemToDropDown(fileNameWithoutExtension);
            return;
        }

        void Cosmetics()
        {
            try
            {
                platformDropDown.SelectedIndex = 0;
                deleteButton.Enabled = true;
                copyEmailButton.Enabled = true;
                copyPasswordButton.Enabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                platformDropDown.Text = "";
                fileInformationTextBox.Clear();
                platformDropDown.Enabled = false;
                deleteButton.Enabled = false;
                copyEmailButton.Enabled = false;
                copyPasswordButton.Enabled = false;
            }
        }
    }
}
