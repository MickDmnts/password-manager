using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

//RE-WORK -- Modify the try_catch section so it identifies if the programs is used for the first time
//TO DO -- Refresh the list when an item is deleted so it shows the remaining items in the database -- IndexOutOfRangeException

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
                Utilities.ChangeButtonState(_formButtons, true);
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
            int platformID = _listBox.SelectedIndex + 1;
            Debug.WriteLine(platformID);
            DatabaseDataAccess.DeletePasswordAndResetSEQrow(platformID);
        }

        private void _copyEmailButton_Click(object sender, EventArgs e)
        {
            int platformID = _listBox.SelectedIndex + 1;
            Debug.WriteLine(platformID);
            Clipboard.SetText(DatabaseDataAccess.GetEmailByID(platformID));
        }

        private void _copyPasswordButton_Click(object sender, EventArgs e)
        {
            int platformID = _listBox.SelectedIndex + 1;
            Debug.WriteLine(platformID);
            Clipboard.SetText(DatabaseDataAccess.GetPasswordByID(platformID));
        }
    }
}
