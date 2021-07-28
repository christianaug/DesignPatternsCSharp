using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Singleton
{
	public class SingletonMain
	{
		public static void Run()
		{
			var instanceOne = Singleton.Instance;
			var instanceTwo = Singleton.Instance;

			if (instanceOne.Equals(instanceTwo))
			{
				Console.WriteLine("Singleton instances are the same");
			}
		}
	}
}
