using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    class StreamManip
    {

        public static void LoadToken()
        {
            try
            {
                using (StreamReader reader = new StreamReader("token.txt"))
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        DiscordLogging.isLogged = true;
                    }
                }
            }
            catch (Exception) { }
        }


    }
}
