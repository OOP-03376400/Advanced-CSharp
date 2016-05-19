using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Miner_s_Task
{
    class A_Miner_s_Task
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string, double> resources = new Dictionary<string, double>();

            while ((input = Console.ReadLine()) != "stop")
            {
                if (resources.ContainsKey(input))
                    resources[input] += double.Parse(Console.ReadLine());
                else
                    resources[input] = double.Parse(Console.ReadLine());
            }
            foreach (var pair in resources)
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
        }
    }
}
