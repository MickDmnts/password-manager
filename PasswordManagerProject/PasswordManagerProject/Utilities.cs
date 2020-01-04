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
        
        public static void ChangeButtonState(Button[] _buttons, bool state)
        {
            foreach (Button button in _buttons)
            {
                button.Enabled = state;
            }
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
    }
}
