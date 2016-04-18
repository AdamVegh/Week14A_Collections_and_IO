using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SequentialCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			Queue queue = new Queue();
			queue.Enqueue("First");
			queue.Enqueue("Second");
			queue.Enqueue("Third");
			queue.Enqueue("Fourth");
			while (queue.Count > 0)
			{
				Console.WriteLine("From queue: {0}", queue.Dequeue());
			}
			Console.WriteLine();

			Stack stack = new Stack();
			stack.Push("First");
			stack.Push("Second");
			stack.Push("Third");
			stack.Push("Fourth");
			while (stack.Count > 0)
			{
				Console.WriteLine("From stack: {0}", stack.Pop());
			}
			Console.ReadKey();
		}
	}
}
