﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.Strategy.Strategies.Invoice
{
	class EmailInvoiceStrategy : InvoiceStrategy
	{
		public override void Generate(Order order)
		{
			var body = GenerateTextInvoice(order);
            using (SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("chrisaug", "");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("chrisaug@rogers.com", "chrisaug@rogers.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = body
                };

                client.Send(mail);
            }

        }
	}
}
