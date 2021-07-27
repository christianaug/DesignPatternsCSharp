using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace DesignPatternsCSharp.Behavioral.Singleton
{
	public sealed class Singleton
	{
		private static Singleton _instance;
		private static readonly object padlock = new object();
		//This implementation of singleton is naive, it is not thread safe.
		//if 'Singleton.Instance' were called on different threads, it would result in 3 seperate instances
		public static Singleton Instance
		{
			get
			{
				lock (padlock) //this lock is used on every reference to the singleton (solves naive issue, pad on performance)
				{
					Console.WriteLine("Instance called.");
					if (_instance == null)
					{
						_instance = new Singleton();
					}
					return _instance;
				}
			}
		}

		private Singleton()
		{
			Console.WriteLine("Constructor invoked.");
		}
	}
}
