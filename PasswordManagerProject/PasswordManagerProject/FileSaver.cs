using System.Windows.Forms;

namespace PasswordManagerProject
{
    class FileSaver
    {
        public FileSaver(TextBox platformText, TextBox nameText, TextBox passwordText)
        {
            _platformBoxText = platformText;
            _nameBoxText = nameText;
            _passwordBoxText = passwordText;
        }

        TextBox _platformBoxText;
        TextBox _nameBoxText;
        TextBox _passwordBoxText;

        public void SaveFile()
        {
            PlatformInformation tempP = new PlatformInformation();
            tempP.Platform = _platformBoxText.Text;
            tempP.Email = _nameBoxText.Text;
            tempP.Password = _passwordBoxText.Text;
            DatabaseDataAccess.SavePlatform(tempP);

            Utilities.NotifyUser();
            Utilities.ClearTextBoxes(MainWindowForm.TextBoxArray);
        }
    }
}
