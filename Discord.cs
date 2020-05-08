using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    class Discord
    {
        private string email;
        private string password;
        private string xFingerPrint;
        public Discord(string email, string password)
        {
            this.email = email;
            this.password = password;
            Login();
        }


        // scrape fingerprint from /api/v6/experiments
        private void GetFingerprint()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://discord.com/api/v6/experiments");
        }

        public void Login()
        {
            
        }






    }
}
