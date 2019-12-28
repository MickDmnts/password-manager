using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PasswordManagerProject
{
    class FileLoader
    { 
        public FileLoader(List<PlatformInformation> list, ComboBox comboBox)
        {
            _mainDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Password Manager";
            _passwordsList = list;
            _comboBox = comboBox;
        }

        string _mainDirectory;
        List<PlatformInformation> _passwordsList;
        ComboBox _comboBox;

        public void LoadFiles()
        {
            //Get the file names on a CreationTime order
            var filesInDirectoryByTime = new DirectoryInfo(_mainDirectory).GetFiles().OrderBy(f => f.CreationTime).ToArray();
            string[] filesNamesInDirectory = new string[filesInDirectoryByTime.Length];
            for (int i = 0; i < filesInDirectoryByTime.Length; i++)
            {
                filesNamesInDirectory[i] = filesInDirectoryByTime[i].ToString();
                CreateLoadedFileObject(filesNamesInDirectory[i]);
            }
        }

        void CreateLoadedFileObject(string name)
        {
            StreamReader streamReader = new StreamReader(_mainDirectory + @"\" + name);
            string fileEmail = streamReader.ReadLine().Replace("Email / Username: ", "");
            string filePassword = streamReader.ReadLine().Replace("Password: ", "");
            streamReader.Close();

            DateTime timeCreated = Directory.GetCreationTime(_mainDirectory + @"\" + name + @".pmf");

            string fileNameWithoutExtension = name.Replace(".pmf", "");

            PlatformInformation fileToAdd = new PlatformInformation(fileNameWithoutExtension, fileEmail, filePassword, timeCreated);
            _passwordsList.Add(fileToAdd);
            Utilities.AddItemToDropDown(_comboBox, fileNameWithoutExtension);
            return;
        }
    }
}
