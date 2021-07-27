using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.SalesTax
{
	public interface ISalesTaxStrategy
	{
		public decimal GetTaxFor(Order order);
	}
}
