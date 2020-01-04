using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManagerProject
{
    class FileLoader
    { 
        public FileLoader(List<PlatformInformation> passwordsList, ListBox listBox)
        {
            _passwordsList = passwordsList;
            _listBox = listBox;
        }

        List<PlatformInformation> _passwordsList;
        ListBox _listBox;

        public void LoadFiles()
        {
            _passwordsList = DatabaseDataAccess.LoadDatabase();
            _listBox.DataSource = null;
            _listBox.DataSource = _passwordsList;
            _listBox.DisplayMember = "Platform";
        }

        public void RefreshList()
        {
            LoadFiles();
        }
    }
}
