using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Queue_Operations
{
    class Basic_Queue_Operations
    {
        static void Main(string[] args)
        {
            int[] inputParameters = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int elementsToEnqueue = inputParameters[0];
            int elementsToDequeue = inputParameters[1];
            int element = inputParameters[2];
            int[] numbersInput = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            Queue<int> sequence = new Queue<int>();
            for (int i = 0; i < elementsToEnqueue; i++)
                sequence.Enqueue(numbersInput[i]);
            for (int i = 0; i < elementsToDequeue; i++)
                sequence.Dequeue();

            if (sequence.Count == 0)                Console.WriteLine(0);
            else if (sequence.Contains(element))    Console.WriteLine("true");
            else                                    Console.WriteLine(sequence.Min());
        }
    }
}