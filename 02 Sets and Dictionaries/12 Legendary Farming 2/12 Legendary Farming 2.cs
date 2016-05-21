using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_Farming
{
    class Legendary_Farming
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            materials["fragments"] = 0;
            materials["motes"] = 0;
            materials["shards"] = 0;

            Dictionary<string, string> keyMaterials = new Dictionary<string, string>();
            keyMaterials["fragments"] = "Valanyr";
            keyMaterials["motes"] = "Dragonwrath";
            keyMaterials["shards"] = "Shadowmourne";    // legendary items

            bool itemObtained = false;
            while (!itemObtained)
            {
                string[] data = Console.ReadLine()
                    .ToLower()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < data.Length; i += 2)
                {
                    int quantity = int.Parse(data[i]);
                    string material = data[i + 1];
                    if (!materials.ContainsKey(material))
                        materials[material] = 0;
                    materials[material] += quantity;

                    if (keyMaterials.ContainsKey(material) && materials[material] >= 250)
                    {
                        foreach (var keyMaterial in keyMaterials)
                            if (material == keyMaterial.Key)
                            {
                                Console.WriteLine($"{keyMaterial.Value} obtained!");
                                materials[material] -= 250;
                            }
                        itemObtained = true;

                        // print remaining key materials
                        var keyMaterialsDescOrder = materials
                            .Where(x => keyMaterials.ContainsKey(x.Key))
                            .OrderBy(x => x.Key)
                            .OrderByDescending(x => x.Value);
                        foreach (var item in keyMaterialsDescOrder)
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);

                        // print remaining junk items
                        var junkDescOrder = materials
                            .Where(x => !keyMaterials.ContainsKey(x.Key))
                            .OrderBy(x => x.Key);
                        foreach (var item in junkDescOrder)
                            Console.WriteLine("{0}: {1}", item.Key, item.Value);
                        break;
                    }
                }
            }
        }
    }
}