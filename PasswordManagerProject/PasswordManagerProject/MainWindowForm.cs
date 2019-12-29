using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

//The app currently saves in desktop for testing purposes

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

        static List<PlatformInformation> _passwordsList = new List<PlatformInformation>();
        public static List<PlatformInformation> PasswordsList
        {
            get
            {
                return _passwordsList;
            }
        }

        static TextBox[] _textBoxes;
        public static TextBox[] TextBoxArray
        {
            get
            {
                return _textBoxes;
            }
        }

        Button[] _formButtons;
        FileLoader _fileLoader;
        FileSaver _fileSaver;

        public MainWindowForm()
        { 
            InitializeComponent();

            if (Utilities.CheckIfUsedBefore(RootFolder))
            {
                MainDirectory = RootFolder + @"\Password Manager";
                Utilities.SetMainDirectoryToPreviousPath(MainDirectory);
            }
            else
            {
                MainDirectory = RootFolder;
                Utilities.DirectoryCreationIfFirstRun(MainDirectory);
            }

            CreateLoaderSaverInstances(); 
            PopulateTextBoxesArray();
            PopulateButtonArray();
            _fileLoader.LoadFiles();

            if (_platformDropDown.Items.Count > 0)
            {
                NotFirstRunCosmetics();
            }
        }

        void NotFirstRunCosmetics()
        {
            Utilities.SelectIndexZero(_platformDropDown);
            Utilities.ChangeButtonState(_formButtons, true);
            Utilities.DropDownState(_platformDropDown, true);
            Utilities.RichTextBoxState(_richTextBox, true);
        }

        void CreateLoaderSaverInstances()
        {
            _fileLoader = new FileLoader(_passwordsList, _platformDropDown);
            _fileSaver = new FileSaver(_platformText, _nameText, _passwordText, _platformDropDown);
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
            LaunchSavingSequence();
        }

        void LaunchSavingSequence()
        {
            if (Utilities.CheckForBlankInput(TextBoxArray))
            {
                MessageBox.Show("An input field is blank, please review your input.", "Blank Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Utilities.ClearTextBoxes(TextBoxArray);
                return;
            }
            else
            {
                _fileSaver.SaveFile();

                //Cosmetics
                Utilities.SelectIndexZero(_platformDropDown);
                Utilities.ChangeButtonState(_formButtons, true);
                Utilities.RichTextBoxState(_richTextBox, true);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            LaunchDeletionSequence();
        }

        void LaunchDeletionSequence()
        {
            if (MessageBox.Show("Are you sure you want to delete " + _platformDropDown.Text + " password file?", "Delete file", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            LaunchSearchSequence();
        }

        void LaunchSearchSequence()
        {
            string nameOfFile = _platformDropDown.Text;
            SearchPIListForTheCorrectFile(nameOfFile);
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

    }
}
