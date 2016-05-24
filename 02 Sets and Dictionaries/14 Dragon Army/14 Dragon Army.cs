using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Army
{
    class Dragon_Army
    {
        static void Main(string[] args)
        {
            // dragon type, dragon name, dragon stats[] {damage, health, armor} 
            Dictionary<string, SortedDictionary<string, int[]>> dragonStats = new Dictionary<string, SortedDictionary<string, int[]>>();
            Dictionary<String, long[]> dragonTypeTotal = new Dictionary<string, long[]>();  // type, {damage, health, armor}
            Dictionary<String, int[]> dragonTypeCount = new Dictionary<string, int[]>();    // type, {damage, health, armor}

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string dragonType = data[0];
                string dragonName = data[1];
                int dragonDamage = 45;  // default values
                int dragonHealth = 250; // default values
                int dragonArmor = 10;   // default values
                if (data[2] != "null")  dragonDamage = int.Parse(data[2]);
                if (data[3] != "null")  dragonHealth = int.Parse(data[3]);
                if (data[4] != "null")  dragonArmor =  int.Parse(data[4]);
                int[] currentStats = { dragonDamage, dragonHealth, dragonArmor };

                if (!dragonStats.ContainsKey(dragonType))
                {
                    dragonStats[dragonType] = new SortedDictionary<string, int[]>();
                    dragonTypeTotal[dragonType] = new long[3];
                    dragonTypeCount[dragonType] = new int[3];
                }
                if (!dragonStats[dragonType].ContainsKey(dragonName))
                {
                    dragonStats[dragonType][dragonName] = new int[3];
                    for (int j = 0; j < 3; j++)
                    {
                        dragonTypeCount[dragonType][j]++;
                        dragonTypeTotal[dragonType][j] += currentStats[j];
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                        dragonTypeTotal[dragonType][j] += currentStats[j] 
                                                        - dragonStats[dragonType][dragonName][j];
                }
                dragonStats[dragonType][dragonName] = currentStats; // overwrite previous data
            }
            foreach (var dragonTypePair in dragonStats.GroupBy(x => x.Key)) // group by dragon type
            {
                string dragonType = dragonTypePair.Key;
                double[] averageStats = new double[3];
                for (int i = 0; i < 3; i++)
                    averageStats[i] = (double)dragonTypeTotal[dragonType][i] / dragonTypeCount[dragonType][i];
                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})",
                    dragonType, 
                    averageStats[0], averageStats[1], averageStats[2]); // dragon type average stats
                foreach (var dragon in dragonStats[dragonType].OrderBy(x => x.Key)) // dragon names, ascending
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        dragon.Key,                                         // dragon name
                        dragon.Value[0], dragon.Value[1], dragon.Value[2]); // dragon stats
                }                
            }
        }
    }
}