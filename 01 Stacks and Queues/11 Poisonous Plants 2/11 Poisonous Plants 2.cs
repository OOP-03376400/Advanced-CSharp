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
            int[] plantsInput = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            Stack<int> plants = new Stack<int>();
            foreach (var plant in plantsInput)
                plants.Push(plant);

            int days = 0;
            while (true)
            {
                bool deadPlants = false;
                Stack<int> survivingPlants = new Stack<int>();
                for (int i = plants.Count - 1; i > 0; i--)
                {
                    int lastPlant = plants.Pop();
                    if (lastPlant <= plants.Peek())
                        survivingPlants.Push(lastPlant);
                    else
                        deadPlants = true;
                }
                survivingPlants.Push(plants.Pop());
                if (!deadPlants) break;
                days++;
                int[] survivingPlantsArr = survivingPlants.ToArray();
                foreach (var plant in survivingPlantsArr)
                    plants.Push(plant);
            }
            Console.WriteLine(days);
        }
    }
}