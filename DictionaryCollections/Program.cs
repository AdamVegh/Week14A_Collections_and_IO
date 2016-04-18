using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DictionaryCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			Hashtable lookup = new Hashtable();
			lookup["0"] = "Zero";
			lookup["1"] = "One";
			lookup["2"] = "Two";
			lookup["3"] = "Three";
			lookup["4"] = "Four";
			lookup["5"] = "Five";
			lookup["6"] = "Six";
			lookup["7"] = "Seven";
			lookup["8"] = "Eight";
			lookup["9"] = "Nine";

			string myNumber = "0.2.4.6.8.9-1-3-5-7-9";

			foreach (char c in myNumber)
			{
				string digit = c.ToString();
				if (lookup.ContainsKey(digit))
				{
					Console.WriteLine(lookup[digit]);
				}
			}
			Console.ReadKey();
		}
	}
}
