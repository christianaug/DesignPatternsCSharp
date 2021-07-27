using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Invoice
{
	class FileInvoiceStrategy : InvoiceStrategy
	{
		public override void Generate(Order order)
		{
			using (var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt"))
			{
				stream.Write(GenerateTextInvoice(order));
				stream.Flush();
				Console.WriteLine("wrote to file");
			}
		}
	}
}
