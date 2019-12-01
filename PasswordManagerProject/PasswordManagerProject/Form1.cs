using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

#pragma warning disable
namespace PasswordManagerProject
{
    public partial class Form1 : Form
    {
        //Main vars
        string mainDirectory;
        List<PlatformInformation> passwordsList = new List<PlatformInformation>();
        int passwordFileIDs = 0;

        public Form1()
        {
            //VS Functions
            InitializeComponent();

            //My Functions
            CheckIfUsedBefore();
            LoadFiles();
            Cosmetics();
        }

        //VS Specific functions
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (CheckForBlankInput())
            {
                MessageBox.Show("An input field is blank, please review your input.", "Blank Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                SaveFile();
                Cosmetics();
            }
        }

        private void platformDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            //Index of the selected file in the drop down box
            int indexOfFile = comboBox.FindStringExact(platformDropDown.Text);
            SearchPIListForTheCorrectFile(indexOfFile);
        }

        //My functions
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

        void SearchPIListForTheCorrectFile(int indexOfFile)
        {
            foreach (PlatformInformation file in passwordsList)
            {
                if (file.FileID == indexOfFile)
                {
                    WriteFileDataOnRTB(file);
                    break;
                }
            }
        }

        void WriteFileDataOnRTB(PlatformInformation correctFile)
        {
            StreamReader reader = new StreamReader(mainDirectory + @"\" + correctFile.Platform + @".pmf");
            fileInformationTextBox.Text = reader.ReadToEnd();
            reader.Close();
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

        void SaveFile()
        {
            //Helpful vars
            string platform = platformText.Text.Trim();
            string name = nameText.Text.Trim();
            string password = passwordText.Text.Trim();
            int fileID = passwordFileIDs;
            DateTime dateCreated = DateTime.Now;
            IncrementIDs();

            WritePMFInDirectory(platform,CreatePIObjectAndAddToList(platform, name, password, fileID, dateCreated));

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
                writer.Write("File ID: " + passwordFile.FileID);
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

        PlatformInformation CreatePIObjectAndAddToList(string platform, string name, string password, int fileID, DateTime dateCreated)
        {
            PlatformInformation passwordFile = new PlatformInformation(platform, name, password, fileID, dateCreated);
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
            platformText.Clear();
            nameText.Clear();
            passwordText.Clear();
        }

        void LoadFiles()
        {
            //Get the file names on a CreationTime order
            var filesInDirectoryByTime = new DirectoryInfo(mainDirectory).GetFiles().OrderBy(f => f.CreationTime).ToArray();
            string[] filesNamesInDirectory = new string[filesInDirectoryByTime.Length];
            for (int i = 0; i < filesInDirectoryByTime.Length; i++)
            {
                filesNamesInDirectory[i] = filesInDirectoryByTime[i].ToString();
                CreateLoadedFileObject(filesNamesInDirectory[i]); //Create an object for each file
            }
        }

        void CreateLoadedFileObject(string name)
        {
            StreamReader streamReader = new StreamReader(mainDirectory + @"\" + name);
            string fileEmail = streamReader.ReadLine().Replace("Email / Username: ", ""); //Email
            string filePassword = streamReader.ReadLine().Replace("Password: ", ""); //Password
            string fileIdAsString = streamReader.ReadLine().Replace("File ID:", ""); //Take the int ID as a String
            int fileID = ParseFileID(fileIdAsString); //Convert the stringID to int
            streamReader.Close();

            DateTime timeCreated = Directory.GetCreationTime(mainDirectory + @"\" + name + @".pmf");

            string fileNameWithoutExtension = name.Replace(".pmf", "");

            PlatformInformation fileToAdd = new PlatformInformation(fileNameWithoutExtension, fileEmail, filePassword, fileID, timeCreated); //Create the file object
            passwordsList.Add(fileToAdd); //Add it to the list of password files
            AddItemToDropDown(fileNameWithoutExtension);
            IncrementIDs();
            return;
        }

        int ParseFileID(string stringToParse)
        {
            Int32.TryParse(stringToParse, out int id);
            return id;
        }

        void IncrementIDs()
        {
            passwordFileIDs++;
        }

        void Cosmetics()
        {
            try
            {
                platformDropDown.SelectedIndex = 0;
                fileCounterText.Text = "Saved Passwords: " + passwordFileIDs;
            }
            catch (ArgumentOutOfRangeException)
            {
                platformDropDown.Enabled = false;
                fileCounterText.Text = "Saved Passwords: 0";
            }
        }
    }
}
