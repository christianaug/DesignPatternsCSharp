using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Shipping
{
	public interface IShippingStrategy
	{
		void Ship(Order order);
	}
}
