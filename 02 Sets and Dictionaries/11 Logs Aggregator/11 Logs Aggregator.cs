using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs_Aggregator
{
    class Logs_Aggregator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, HashSet<string>> userIPAddresses = new SortedDictionary<string, HashSet<string>>();
            SortedDictionary<string, int> userSessionDuration = new SortedDictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ipAddress = data[0];
                string user = data[1];
                int sessionDuration = int.Parse(data[2]);

                if (!userIPAddresses.ContainsKey(user))
                {
                    userIPAddresses[user] = new HashSet<string>();
                    userSessionDuration[user] = 0;
                }
                userIPAddresses[user].Add(ipAddress);
                userSessionDuration[user] += sessionDuration;                
            }
            foreach (var user in userSessionDuration)
            {
                Console.WriteLine("{0}: {1} [{2}]", 
                    user.Key, 
                    user.Value, 
                    string.Join(", ", userIPAddresses[user.Key].OrderBy(x => x)));
            }
        }
    }
}
