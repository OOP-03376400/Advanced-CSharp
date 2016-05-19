using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            while ((input = Console.ReadLine()) != "search")
            {
                string[] data = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                string phonenumber = data[1];
                phonebook[name] = phonenumber;
            }
            while ((input = Console.ReadLine()) != "stop")
            {
                string name = input;
                if (phonebook.ContainsKey(name))
                    Console.WriteLine("{0} -> {1}", name, phonebook[name]);
                else
                    Console.WriteLine("Contact {0} does not exist.", name);
            }
        }
    }
}