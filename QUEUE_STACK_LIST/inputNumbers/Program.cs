using System;
using System.Collections;
using System.Collections.Generic;

namespace inputNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();

            do
            {
                int number;
                while (true)
                {
                    Console.WriteLine("Enter a number");
                    if (int.TryParse(Console.ReadLine(), out number)) { break; }
                }
                queue.Enqueue(number);
                stack.Push(number);
                lista.Add(number);
                Console.WriteLine("Do you want to enter another number? Y/N");
            } while (Console.ReadLine().ToUpper() == "Y");
            PrintCollection(lista);
            PrintCollection(queue);
            PrintCollection(stack);
        }
        static void PrintCollection(IEnumerable collection)
        {
            foreach(object a in collection)
            {
                Console.WriteLine($"{collection} : {a}");
            }
        }
    }
}
