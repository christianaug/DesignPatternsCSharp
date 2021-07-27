using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatternsCSharp.Behavioral.State
{
	public class Booking
	{
		public string Attendee { get; set; }
		public int TicketCount { get; set; }
		public int BookingID { get; set; }

		private CancellationTokenSource cancelToken;
		private bool isNew;
		private bool isPending;
		private bool isBooked;

		public Booking()
		{
			isNew = true;
			BookingID = new Random().Next();
			ShowState("New");
		}

		public void SubmitDetails()
		{
			if (isNew)
			{
				isNew = false;
				isPending = true;
				//Attendee = attendee;
				//TicketCount = ticketCount;

				cancelToken = new CancellationTokenSource();

				//StaticFunctions.ProcessBooking(this, ProcessingComplete, cancelToken);

				ShowState("Pending");
			}
		}

		public void Cancel()
		{
			if (isNew)
			{
				Console.WriteLine("Closed: Canceld by user");
				isNew = false;
			}
			else if (isPending)
			{
				cancelToken.Cancel();
			}
			else if (isBooked)
			{
				ShowState("Closed: booking canceled");
				isBooked = false;
			}
			else
			{
				Console.WriteLine("Closed bookings cannot be canceled");
			}
		}

		public void DatePassed()
		{
			if (isNew)
			{
				Console.WriteLine("Closed: Booking expired");
				isNew = false;
			}
			else if (isBooked)
			{
				ShowState("Closed: we hoped you enjoyed the event");
				isBooked = false;
			}
		}

		public void ProcessingComplete(Booking booking, ProcessingResult result)
		{
			isPending = false;
			switch (result)
			{
				case ProcessingResult.Success:
					isBooked = true;
					ShowState("Booked");
					break;
				case ProcessingResult.Fail:
					Attendee = string.Empty;
					BookingID = new Random().Next();
					isNew = true;
					ShowState("New");
					break;
				case ProcessingResult.Cancel:
					ShowState("Closed");
					break;
			}

		}

		public void ShowState(string stateName)
		{
			Console.WriteLine(stateName, TicketCount, Attendee, BookingID);
		}
	}

	public enum ProcessingResult
	{
		Success,
		Fail,
		Cancel
	}
}
