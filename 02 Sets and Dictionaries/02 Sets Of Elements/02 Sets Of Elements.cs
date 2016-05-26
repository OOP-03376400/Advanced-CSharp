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
            int sizeN = size[0];
            int sizeM = size[1];
            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();
            for (int i = 0; i < sizeN; i++)
                setN.Add(int.Parse(Console.ReadLine()));
            for (int i = 0; i < sizeM; i++)
                setM.Add(int.Parse(Console.ReadLine()));
            setN.IntersectWith(setM);
            Console.WriteLine(string.Join(" ", setN));
        }
    }
}