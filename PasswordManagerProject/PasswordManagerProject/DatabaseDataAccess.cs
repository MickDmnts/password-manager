using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace PasswordManagerProject
{
    public class DatabaseDataAccess
    {
        public static ListBox FormListBox { get; set; }

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

        public static string GetEmailByID(int platformID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string id = platformID.ToString();
                var temp = cnn.Query<string>("select Email from Passwords where Id =" + id, new DynamicParameters());
                List<string> returnedEmail = temp.ToList();
                return returnedEmail[0];
            }
        }

        public static string GetPasswordByID(int platformID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string id = platformID.ToString();
                var temp = cnn.Query<string>("select Password from Passwords where Id =" + id, new DynamicParameters());
                List<string> output = temp.ToList();
                return output[0];
            }
        }

        public static void DeletePasswordAndResetSEQrow(int platformID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string id = platformID.ToString();
                cnn.Execute("delete from Passwords where Id =" + id);
                ResetSQL_SEQUENCE_SEQ_row();
            }
        }

        private static int GetDatabaseIdCount()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var databaseData = cnn.Query<PlatformInformation>("select * from Passwords", new DynamicParameters());
                List<PlatformInformation> tempDataList = databaseData.ToList();
                int databaseCount = tempDataList.Count;
                Debug.WriteLine(databaseCount);
                return databaseCount;
            }
        }

        private static void ResetSQL_SEQUENCE_SEQ_row()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update sqlite_sequence set seq =" + GetDatabaseIdCount() + " where name = \'Passwords\'");
            }
        }
    }
}
