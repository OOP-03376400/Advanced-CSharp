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
            HashSet<string> uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < n; i++)
                uniqueUsernames.Add(Console.ReadLine());
            Console.WriteLine(string.Join("\n", uniqueUsernames));
        }
    }
}