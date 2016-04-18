using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace LookupCollections
{
	class Program
	{

		static void Main(string[] args)
		{

			ListDictionary myList = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
			myList["Estados Unidos"] = "United States of America";
			myList["Canadá"] = "Canada";
			myList["España"] = "Spain";

			Console.WriteLine(myList["estados unidos"]);
			Console.WriteLine(myList["CANADÁ"]);
			Console.WriteLine(myList["españa"]);
			
			Console.ReadKey();
		}
	}
}
