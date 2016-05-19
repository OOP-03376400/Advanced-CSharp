using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Emails
{
    class Fix_Emails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "stop")
                emails[input] = Console.ReadLine();

            // remove dict entries containing uk/us domains
            List<string> emailsToRemove = new List<string>();
            foreach (var pair in emails)
            {
                string email = pair.Value;
                if (email.EndsWith("uk") || email.EndsWith("us"))
                    emailsToRemove.Add(pair.Key);
            }
            foreach (var entry in emailsToRemove)
                emails.Remove(entry);

            foreach (var pair in emails)
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}
