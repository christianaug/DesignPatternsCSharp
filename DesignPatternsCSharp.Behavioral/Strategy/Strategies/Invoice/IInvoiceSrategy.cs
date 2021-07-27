using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Invoice
{
	public interface IInvoiceStrategy
	{
		public void Generate(Order order);
	}
}
