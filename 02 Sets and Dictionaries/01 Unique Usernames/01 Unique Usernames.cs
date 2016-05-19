using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unique_Usernames
{
    class Unique_Usernames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] usernames = new string[n];
            for (int i = 0; i < n; i++)
                usernames[i] = Console.ReadLine();
            HashSet<string> uniqueUsernames = new HashSet<string>(usernames);
            Console.WriteLine(string.Join("\n", uniqueUsernames));
        }
    }
}
