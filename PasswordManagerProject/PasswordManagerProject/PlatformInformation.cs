using System;

namespace PasswordManagerProject
{
    class PlatformInformation
    {
        public PlatformInformation(string platform, string email, string password, DateTime timeCreated)
        {
            Platform = platform;
            Email = email;
            Password = password;
            DateCreated = timeCreated;
        }

        public string Platform { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
