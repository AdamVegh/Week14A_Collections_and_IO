using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
	class Program
	{
		static void Main(string[] args)
		{
			Dictionary<int, string> countryDict = new Dictionary<int, string>();
			countryDict[1] = "Hunngary";
			countryDict[2] = "Germany";
			countryDict[3] = "Russia";
			countryDict[4] = "USA";
			countryDict[5] = "Australia";
			countryDict[6] = "Antarctica";
			//countryDict["7"] = "Piresia"; -> Type safe dictionary

			Console.WriteLine("The first country is: " + countryDict[1]);

			Console.WriteLine();

			foreach (KeyValuePair<int, string> item in countryDict)
			{
				Console.WriteLine("The {0}th code goes to {1}.", item.Key, item.Value);
			}

			Console.ReadKey();
		}
	}
}
