using System;

/// <summary>
/// Every time a password file is created, an ID must be assigned for the dropdown menu to find it and display it.
/// </summary>

namespace PasswordManagerProject
{
    class PlatformInformation
    {
        private string _platform, _password, _email;

        private int _dropDownID;

        private DateTime _timeCreated;

        private bool _loaded;

        public PlatformInformation(string platform, string email, string password, int id, DateTime timeCreated, bool loaded = false)
        {
            _platform = platform;
            _email = email;
            _password = password;
            _dropDownID = id;
            _timeCreated = timeCreated;
            _loaded = loaded;
        }

        public string Platform
        {
            get { return _platform; }
            set { _platform = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int FileID
        {
            get { return _dropDownID; }
            set { _dropDownID = value; }
        }

        public DateTime DateCreated
        {
            get { return _timeCreated; }
            set { _timeCreated = value; }
        }

        public bool Loaded
        {
            get { return _loaded; }
            set { _loaded = value; }
        }
    }
}
