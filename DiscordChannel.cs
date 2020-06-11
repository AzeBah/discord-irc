using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WindowsFormsApp1
{
    public class Author
    {
        public string id { get; set; }
        public string username { get; set; }
        public string avatar { get; set; }
        public string discriminator { get; set; }
        public int public_flags { get; set; }
    }

    public class Attachment
    {
        public string id { get; set; }
        public string filename { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string proxy_url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Embed
    {
        public string type { get; set; }
        public string url { get; set; }
        public string title { get; set; }
    }

    public class Message
    {
        public string id { get; set; }
        public int type { get; set; }
        public string content { get; set; }
        public string channel_id { get; set; }
        public Author author { get; set; }
        public IList<Attachment> attachments { get; set; }
        public IList<Embed> embeds { get; set; }
        public IList<object> mentions { get; set; }
        public IList<object> mention_roles { get; set; }
        public bool pinned { get; set; }
        public bool mention_everyone { get; set; }
        public bool tts { get; set; }
        public DateTime timestamp { get; set; }
        public object edited_timestamp { get; set; }
        public int flags { get; set; }
    }






    class DiscordChannel
    {
        private static Random randomNum = new Random();
        public static string channelId;
        public static List<Message> messages = new List<Message>();
        public DiscordChannel(string channelID)
        {
            channelId = channelID;
            GetMessagesFromChannel();
        }




        // request to get the 50 last messages sent in a specific channel
        private void GetMessagesFromChannel()
        {
            if (channelId.Length != 18)
            {
                return;
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/channels/" + channelId + "/messages?limit=50");
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
            req.Referer = "https://discord.com/channels/@me";
            req.Headers.Add("Authorization", DiscordLogging.userToken);
            req.Timeout = 5000;

            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    messages.Clear();
                    messages = System.Text.Json.JsonSerializer.Deserialize<List<Message>> (response);
                }
            }
            catch (WebException) { }
        }

        private static string GenerateNonce()
        {
            string generatedNonce = "";
            for (int i = 0; i < 18; i++)
            {
                int randomNumber = randomNum.Next(0, 9);
                generatedNonce += Convert.ToString(randomNumber);
            }
            return generatedNonce;
        }

        // request to send a specific message to a channel
        public static void SendMessage(string message)
        {
            if (channelId.Length != 18)
            {
                return;
            }
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/channels/" + channelId + "/messages");
            req.Method = "POST";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
            req.ContentType = "application/json";
            req.Headers.Add("X-Super-Properties", "");
            req.Headers.Add("Authorization", DiscordLogging.userToken);
            req.Timeout = 5000;
            string postData = "{\"content\":\"" + message + "\",\"nonce\":\"" + GenerateNonce() + "\",\"tts\":false}";
            byte[] data = Encoding.ASCII.GetBytes(postData);

            try
            {
                using (Stream writer = req.GetRequestStream())
                {
                    writer.Write(data, 0, data.Length);
                }
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException)
            {
            }
        }


        // request to delete a specific message in a specific message
        public static void DeleteMessage(string messageID)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/channels/" + channelId + "/messages/" + messageID);
            req.Method = "DELETE";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
            req.Headers.Add("X-Super-Properties", "eyJvcyI6IldpbmRvd3MiLCJicm93c2VyIjoiQ2hyb21lIiwiZGV2aWNlIjoiIiwiYnJvd3Nlcl91c2VyX2FnZW50IjoiTW96aWxsYS81LjAgKFdpbmRvd3MgTlQgMTAuMDsgV2luNjQ7IHg2NCkgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzgxLjAuNDA0NC4xMzggU2FmYXJpLzUzNy4zNiIsImJyb3dzZXJfdmVyc2lvbiI6IjgxLjAuNDA0NC4xMzgiLCJvc192ZXJzaW9uIjoiMTAiLCJyZWZlcnJlciI6Imh0dHBzOi8vZGlzY29yZGFwcC5jb20vIiwicmVmZXJyaW5nX2RvbWFpbiI6ImRpc2NvcmRhcHAuY29tIiwicmVmZXJyZXJfY3VycmVudCI6IiIsInJlZmVycmluZ19kb21haW5fY3VycmVudCI6IiIsInJlbGVhc2VfY2hhbm5lbCI6InN0YWJsZSIsImNsaWVudF9idWlsZF9udW1iZXIiOjYwMDczLCJjbGllbnRfZXZlbnRfc291cmNlIjpudWxsfQ==");
            req.Headers.Add("Authorization", DiscordLogging.userToken);
            req.ContentLength = 0;
            req.Timeout = 5000;

            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException) { }
        }
    }
}
