using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

#pragma warning disable
namespace PasswordManagerProject
{
    public partial class MainWindowForm : Form
    {
        private static string _mainDirectory;
        public static string MainDirectory 
        {
            get
            {
                return _mainDirectory;
            }
            set
            {
                _mainDirectory = value;
            }
        }

        private static string _rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static string RootFolder
        { 
            get
            {
                return _rootFolder;
            }
        }

        List<PlatformInformation> _passwordsList = new List<PlatformInformation>();
        TextBox[] _textBoxes;
        Button[] _formButtons;
        FileLoader _fileLoader;

        public MainWindowForm()
        { 
            InitializeComponent();

            if (Utilities.CheckIfUsedBefore(RootFolder))
            {
                Utilities.SetMainDirectoryToPreviousPath(MainDirectory);
            }
            else
            {
                Utilities.DirectoryCreationIfFirstRun(MainDirectory);
            }

            CreateFileLoader(); 
            PopulateTextBoxesArray();
            PopulateButtonArray();
            _fileLoader.LoadFiles();
            if (_platformDropDown.Items.Count > 0)
            {
                NotFirstRunUtilities();
            }
        }

        void NotFirstRunUtilities()
        {
            Utilities.SelectIndexZero(_platformDropDown);
            Utilities.ChangeButtonState(_formButtons, true);
            Utilities.DropDownState(_platformDropDown, true);
            Utilities.RichTextBoxState(_richTextBox, true);
        }

        void CreateFileLoader()
        {
            _fileLoader = new FileLoader(_passwordsList, _platformDropDown);
        }

        void PopulateTextBoxesArray()
        {
            _textBoxes = new TextBox[] { _platformText, _nameText, _passwordText };
        }

        void PopulateButtonArray()
        {
            _formButtons = new Button[] { _deleteButton, _copyEmailButton, _copyPasswordButton };
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (Utilities.CheckForBlankInput(_textBoxes))
            {
                MessageBox.Show("An input field is blank, please review your input.", "Blank Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Utilities.ClearTextBoxes(_textBoxes);
                return;
            }
            else
            {
                SaveFile();
                //Cosmetics();
                Utilities.SelectIndexZero(_platformDropDown);
                Utilities.ChangeButtonState(_formButtons,true);
                Utilities.RichTextBoxState(_richTextBox, true);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + _platformDropDown.Text + " password file?","Delete file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string filePath = MainDirectory + @"/" + _platformDropDown.Text + @".pmf";
                File.Delete(filePath);

                foreach (PlatformInformation file in _passwordsList)
                {
                    if (file.Platform == _platformDropDown.Text)
                    {
                        _passwordsList.Remove(file);
                        break;
                    }
                }

                _platformDropDown.Items.RemoveAt(_platformDropDown.SelectedIndex);
                _platformDropDown.Update();
                //Cosmetics();
                if (_platformDropDown.Items.Count > 0)
                {
                    Utilities.SelectIndexZero(_platformDropDown);
                }
                else
                {
                    Utilities.ChangeButtonState(_formButtons, false);
                    _platformDropDown.Text = "";
                    _platformDropDown.Enabled = false;
                    _richTextBox.Clear();
                    Utilities.RichTextBoxState(_richTextBox, false);
                }
            }
            else
            {
                return;
            }
        }

        private void platformDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameOfFile = _platformDropDown.Text;
            SearchPIListForTheCorrectFile(nameOfFile);
        }

        private void copyEmailButton_Click(object sender, EventArgs e)
        {
            string fileName = _platformDropDown.Text;
            foreach (PlatformInformation file in _passwordsList)
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
            string fileName = _platformDropDown.Text;
            foreach (PlatformInformation file in _passwordsList)
            {
                if (file.Platform == fileName)
                {
                    Clipboard.SetText(file.Password);
                    return;
                }
            }
        }

        void SearchPIListForTheCorrectFile(string nameOfFile)
        {
            foreach (PlatformInformation file in _passwordsList)
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
            StreamReader reader = new StreamReader(MainDirectory + @"\" + correctFile.Platform + @".pmf");
            _richTextBox.Text = reader.ReadToEnd();
            reader.Close();
        }

        void SaveFile()
        {
            string platform = _platformText.Text.Trim();
            string name = _nameText.Text.Trim();
            string password = _passwordText.Text.Trim();
            DateTime dateCreated = DateTime.Now;

            WritePMFInDirectory(platform, CreatePIObjectAndAddToList(platform, name, password, dateCreated));

            Utilities.AddItemToDropDown(_platformDropDown, platform);
            Utilities.NotifyUser();
            Utilities.ClearTextBoxes(_textBoxes);
            Utilities.DropDownState(_platformDropDown, true);
        }

        void WritePMFInDirectory(string platformName,PlatformInformation passwordFile)
        {
            try
            {
                StreamWriter writer = new StreamWriter(MainDirectory + @"\" + platformName + @".pmf");
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
            _passwordsList.Add(passwordFile);
            return passwordFile;
        }
    }
}
