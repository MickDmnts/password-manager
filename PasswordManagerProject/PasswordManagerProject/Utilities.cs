using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManagerProject
{
    public class Utilities
    {
        public static void AddItemToDropDown(ComboBox comboBox,string itemName)
        {
            comboBox.Items.Add(itemName);
        }

        public static void SelectIndexZero(ComboBox comboBox)
        {
            comboBox.SelectedIndex = 0;
        }
        
        public static void ChangeButtonState(Button[] _buttons, bool state)
        {
            foreach (Button button in _buttons)
            {
                button.Enabled = state;
            }
        }

        public static void DropDownState(ComboBox _comboBox, bool state)
        {
            _comboBox.Enabled = state;
        }

        public static void RichTextBoxState(RichTextBox _rtb, bool state)
        {
            _rtb.Enabled = state;
        }

        public static bool CheckForBlankInput(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    return true;
                }
            }

            return false;
        }

        public static void ClearTextBoxes(TextBox[] _textBoxes)
        {
            foreach (TextBox textBox in _textBoxes)
            {
                textBox.Clear();
            }
        }

        public static void NotifyUser()
        {
            MessageBox.Show("File saved successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool CheckIfUsedBefore(string rootFolder)
        {
            string[] directories = Directory.GetDirectories(rootFolder);
            if (directories.Contains(rootFolder + @"\Password Manager"))
            {
                //SetMainDirectoryToPreviousPath(path);
                MainWindowForm.MainDirectory = rootFolder + @"\Password Manager";
                return true;
            }
            else
            {
                //DirectoryCreationIfFirstRun(path);
                MainWindowForm.MainDirectory = rootFolder;
                return false;
            }
        }

        public static void SetMainDirectoryToPreviousPath(string pathName)
        {
            MainWindowForm.MainDirectory = pathName;
        }

        public static void DirectoryCreationIfFirstRun(string pathName)
        {
            DirectoryInfo directory = Directory.CreateDirectory(pathName + @"\Password Manager");
            directory.Attributes = FileAttributes.Hidden;
            MainWindowForm.MainDirectory = directory.FullName;
        }
    }
}
