using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisonous_Plants
{
    class Poisonous_Plants
    {
        static void Main(string[] args)
        {
            // NB 77 / 100: time limit & memory limit!
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            int days = 0;
            while (true)
            {
                bool deadPlants = false;
                Queue<int> survivingPlants = new Queue<int>();
                survivingPlants.Enqueue(plants[0]);

                for (int i = 1; i < plants.Length; i++)
                {
                    if (plants[i - 1] >= plants[i])
                        survivingPlants.Enqueue(plants[i]);
                    else
                        deadPlants = true;
                }
                if (!deadPlants) break;
                days++;
                plants = survivingPlants.ToArray();
            }
            Console.WriteLine(days);
        }
    }
}