using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Invoice
{
	class PrintOnDemandInvoiceStrategy : InvoiceStrategy
	{
		public override void Generate(Order order)
		{
			using (var client = new HttpClient())
			{
				var content = JsonConvert.SerializeObject(order);

				client.BaseAddress = new Uri("http://pluralsight.com");

				client.PostAsync("/print-on-demand", new StringContent(content));
			}
		}
	}
}
