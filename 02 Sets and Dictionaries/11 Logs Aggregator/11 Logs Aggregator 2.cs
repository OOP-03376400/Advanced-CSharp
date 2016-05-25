using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Army
{
    public class Dragon_Army
    {
        public static void Main(string[] args)
        {
			// user, IP address, session duration
			SortedDictionary<string, SortedDictionary<string, int>> userLogs = new SortedDictionary<string, SortedDictionary<string, int>>();
			
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string ipAddress = data[0];
                string user = data[1];
                int sessionDuration = int.Parse(data[2]);

                if (!userLogs.ContainsKey(user))
                    userLogs[user] = new SortedDictionary<string, int>();
				if (!userLogs[user].ContainsKey(ipAddress))
					userLogs[user][ipAddress] = 0;
                userLogs[user][ipAddress] += sessionDuration;
            }
            foreach (var userPair in userLogs)
            {
                Console.WriteLine("{0}: {1} [{2}]", 
                    userPair.Key, 
                    userPair.Value.Select(x => x.Value).Sum(), 
                    string.Join(", ", 
						userPair.Value.Select(x => x.Key)));
            }
        }
    }
}