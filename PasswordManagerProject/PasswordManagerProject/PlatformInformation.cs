﻿
namespace PasswordManagerProject
{
    public class PlatformInformation
    {
        public int Id { get; set; }

        public string Platform { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string GetAllData
        {
            get
            {
                return $"{Id} {Platform} {Email} {Password}";
            }
        }
    }
}
