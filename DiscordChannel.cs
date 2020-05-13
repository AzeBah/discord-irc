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
        private static string channelId;
        public static List<Message> messages = new List<Message>(); 

        public DiscordChannel(string channelID)
        {
            channelId = channelID;
            GetMessagesFromChannel();
        }




        // request to get the 50 last messages sent in a specific channel
        private void GetMessagesFromChannel()
        {
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
        public static Task SendMessage(string message)
        {
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
                return Task.CompletedTask;
            }
            catch (WebException)
            {
                return Task.CompletedTask;
            }

        }
    }
}
