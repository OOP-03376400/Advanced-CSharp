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
            Dictionary<string, string> modifiedEmails = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "stop")
                emails[input] = Console.ReadLine();
            // remove dict entries containing uk/us domains
            foreach (var pair in emails)
                if (!pair.Value.EndsWith("uk") && !pair.Value.EndsWith("us"))
                    modifiedEmails[pair.Key] = pair.Value; 
            foreach (var pair in modifiedEmails)
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}