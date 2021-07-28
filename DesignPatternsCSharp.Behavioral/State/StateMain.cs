using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.State
{
	public class StateMain
	{
		public static void Run()
		{
			Console.WriteLine("Please select one of the options below:\n1 - New Booking\n");
			int option = 0;
			BookingContext booking = null;

			bool res = int.TryParse(Console.ReadLine(), out option);
			if (!res)
			{
				return;
			}
			

			switch (option)
			{
				case 1:
					string name;
					int tickets;

					Console.WriteLine("Atendee Name:");
					name = Console.ReadLine();
					Console.WriteLine("Number of tickets:");
					res = int.TryParse(Console.ReadLine(), out tickets);

					if (!res)
					{
						Console.WriteLine("Number of tickets is not valid");
						return;
					}

					booking = new BookingContext()
					{
						Attendee = name,
						TicketCount = tickets,
					};
					break;
				default:
					Console.WriteLine("Not a valid option");
					return;
			}

			if (booking != null)
			{
				option = 0;
				Console.WriteLine("Please select an option for the current booking session:\n1 - Submit\n2 - Cancel\n3 - Date Passed");
				res = int.TryParse(Console.ReadLine(), out option);

				if (!res)
				{
					return;
				}

				switch (option)
				{
					case 1:
						booking.SubmitDetails();
						break;
					case 2:
						booking.Cancel();
						break;
					case 3:
						booking.DatePassed();
						break;
					default:
						Console.WriteLine("Not a valid option");
						return;
				}

			}
		}
	}
}
