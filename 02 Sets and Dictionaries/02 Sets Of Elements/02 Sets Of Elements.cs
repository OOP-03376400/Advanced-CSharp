using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_Of_Elements
{
    class Sets_Of_Elements
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            int[] arrayN = new int[size[0]];
            int[] arrayM = new int[size[1]];

            for (int i = 0; i < arrayN.Length; i++)
                arrayN[i] = int.Parse(Console.ReadLine());
            for (int i = 0; i < arrayM.Length; i++)
                arrayM[i] = int.Parse(Console.ReadLine());

            HashSet<int> setN = new HashSet<int>(arrayN);
            HashSet<int> setM = new HashSet<int>(arrayM);

            setN.IntersectWith(setM);
            Console.WriteLine(string.Join(" ", setN));
        }
    }
}
