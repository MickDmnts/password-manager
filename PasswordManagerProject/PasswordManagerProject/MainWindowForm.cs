using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

//TO-DO  -- Make Delete, Copy buttons do something

#pragma warning disable
namespace PasswordManagerProject
{
    public partial class MainWindowForm : Form
    {
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

            CreateLoaderSaverInstances();
            PopulateTextBoxesArray();
            PopulateButtonArray();
            CreateDatabase();

            //Load dem files
            _fileLoader.LoadFiles();
        }

        void CreateLoaderSaverInstances()
        {
            _fileLoader = new FileLoader(PasswordsList, _listBox);
            _fileSaver = new FileSaver(_platformText, _nameText, _passwordText);
        }

        void PopulateTextBoxesArray()
        {
            _textBoxes = new TextBox[] { _platformText, _nameText, _passwordText };
        }

        void PopulateButtonArray()
        {
            _formButtons = new Button[] { _deleteButton, _copyEmailButton, _copyPasswordButton };
        }

        void CreateDatabase()
        {
            try
            {
                DatabaseDataAccess.CreateDatabase();
            }
            catch (Exception)
            {
                return;
            }
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
                _fileLoader.RefreshList();

                Utilities.ChangeButtonState(_formButtons, true);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //LaunchDeletionSequence();
        }
    }
}
