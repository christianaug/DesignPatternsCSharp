﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Shipping
{
	public class DhlShippingStrategy : IShippingStrategy
	{
		public void Ship(Order order)
		{
			using (var client = new HttpClient())
			{
				//TODO: IMPLEMENT DHL INTEGRATION

				Console.WriteLine("Order is shipped with DHL");
			}
		}
	}
}
