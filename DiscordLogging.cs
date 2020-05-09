using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    class DiscordLogging
    {
        private string email;
        private string password;
        private string xFingerPrint;
        private string userToken;
        public DiscordLogging(string email, string password)
        {
            this.email = email;
            this.password = password;
            Login();
        }


        // scrape fingerprint from /api/v6/experiments
        private void GetFingerprint()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/experiments");
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.129 Safari/537.36";
            req.Referer = "https://discord.com/login";
            req.Headers.Add("X-Context-Properties", "eyJsb2NhdGlvbiI6IkxvZ2luIn0=");
            req.Headers.Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzgxLjAuNDA0NC4xMjkgU2FmYXJpLzUzNy4zNiIsImJyb3dzZXJfdmVyc2lvbiI6IjgxLjAuNDA0NC4xMjkiLCJvc192ZXJzaW9uIjoiMTAiLCJyZWZlcnJlciI6Imh0dHBzOi8vZGlzY29yZC5jb20vbG9naW4iLCJyZWZlcnJpbmdfZG9tYWluIjoiZGlzY29yZC5jb20iLCJyZWZlcnJlcl9jdXJyZW50IjoiIiwicmVmZXJyaW5nX2RvbWFpbl9jdXJyZW50IjoiIiwicmVsZWFzZV9jaGFubmVsIjoic3RhYmxlIiwiY2xpZW50X2J1aWxkX251bWJlciI6NTk1NzYsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
            req.Headers.Add("Authorization", "undefined");

            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    int position = response.IndexOf("fingerprint");
                    position = response.IndexOf(':', position);
                    position = response.IndexOf('"', position);
                    int secondPos = response.IndexOf('"', position + 1);
                    xFingerPrint = response.Substring(position, (secondPos - position));
                }
            }
            catch (WebException) { }

        }

        private void Login()
        {
            GetFingerprint();
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/auth/login");
            req.Method = "POST";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.129 Safari/537.36";
            req.Referer = "https://discord.com/login";
            req.ContentType = "application/json";
            req.Headers.Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzgxLjAuNDA0NC4xMjkgU2FmYXJpLzUzNy4zNiIsImJyb3dzZXJfdmVyc2lvbiI6IjgxLjAuNDA0NC4xMjkiLCJvc192ZXJzaW9uIjoiMTAiLCJyZWZlcnJlciI6Imh0dHBzOi8vZGlzY29yZC5jb20vbG9naW4iLCJyZWZlcnJpbmdfZG9tYWluIjoiZGlzY29yZC5jb20iLCJyZWZlcnJlcl9jdXJyZW50IjoiIiwicmVmZXJyaW5nX2RvbWFpbl9jdXJyZW50IjoiIiwicmVsZWFzZV9jaGFubmVsIjoic3RhYmxlIiwiY2xpZW50X2J1aWxkX251bWJlciI6NTk1NzYsImNsaWVudF9ldmVudF9zb3VyY2UiOm51bGx9");
            req.Headers.Add("X-Fingerprint", this.xFingerPrint);
            req.Headers.Add("Authorization", "undefined");
            byte[] data = Encoding.ASCII.GetBytes("{\"email\":\"" + this.email + "\",\"password\":\"" + this.password + "\",\"undelete\":false,\"captcha_key\":null,\"login_source\":null,\"gift_code_sku_id\":null}");


            try
            {
                using (Stream writer = req.GetRequestStream())
                {
                    writer.Write(data, 0, data.Length);
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    int position = response.IndexOf("token");
                    position = response.IndexOf(':');
                    position = response.IndexOf('"');
                    int secondPos = response.IndexOf('"', position + 1);
                    this.userToken = response.Substring(position, (secondPos - position));
                }
            }
            catch (WebException) { }
        }




    }
}
