using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Numbers
{
    class Reverse_Numbers
    {
        static void Main(string[] args)
        {
            int[] numbersInput = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < numbersInput.Length; i++)
                numbers.Push(numbersInput[i]);
            for (int i = 0; i < numbers.Count; i++)
                Console.Write("{0} ",numbers.Pop());            
        }
    }
}