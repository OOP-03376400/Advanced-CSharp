using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Logs
{
    class User_Logs
    {
        static void Main(string[] args)
        {
            // username, IPaddress, IPaddress hits		
            SortedDictionary<string, Dictionary<string, int>> userIPadresses = new SortedDictionary<string, Dictionary<string, int>>();
            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ipAddress = data[0].Substring("IP=".Length, data[0].Length - "IP=".Length);
                string user = data[2].Substring("user=".Length, data[2].Length - "user=".Length);

                Dictionary<string, int> ipCounts = new Dictionary<string, int>();
                if (userIPadresses.ContainsKey(user))
                {
                    ipCounts = userIPadresses[user];
                    if (ipCounts.ContainsKey(ipAddress))
                        ipCounts[ipAddress]++;
                    else ipCounts[ipAddress] = 1;
                }
                else ipCounts[ipAddress] = 1;
                userIPadresses[user] = ipCounts;
            }
            foreach (var userPair in userIPadresses)
            {
                string ipLogs = "";
                foreach (var ipPair in userPair.Value)  // ipAddresses & hits
                    ipLogs += ipPair.Key + " => " + ipPair.Value + ", ";
                ipLogs = ipLogs.Substring(0, ipLogs.Length - 2);
                Console.WriteLine("{0}:\n{1}.", userPair.Key, ipLogs);
            }
        }
    }
}