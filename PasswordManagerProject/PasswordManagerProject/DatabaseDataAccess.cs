using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Configuration;
using System.Data;

namespace PasswordManagerProject
{
    public class DatabaseDataAccess
    {
        public static void CreateDatabase()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("CREATE TABLE \"Passwords\" (\"Id\"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,	\"Platform\"	TEXT NOT NULL,	\"Email\"	TEXT NOT NULL,	\"Password\"	TEXT NOT NULL);");
            }
        }

        public static List<PlatformInformation> LoadDatabase()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var loadedPlatforms = cnn.Query<PlatformInformation>("select * from Passwords", new DynamicParameters());
                return loadedPlatforms.ToList();
            }
        }

        public static void SavePlatform(PlatformInformation platformInformationObj)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Passwords (Platform, Email, Password) values (@Platform, @Email, @Password)", platformInformationObj);
            }
        }

        private static string LoadConnectionString(string CSID = "DefaultDB")
        {
            return ConfigurationManager.ConnectionStrings[CSID].ConnectionString;
        }
    }
}
