using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Shipping
{
	public class CanadaPostShippingStrategy : IShippingStrategy
	{
		public void Ship(Order order)
		{
			using (var client = new HttpClient())
			{
				//TODO: IMPLEMENT CanadaPost INTEGRATION

				Console.WriteLine("Order is shipped with CanadaPost");
			}
		}
	}
}
