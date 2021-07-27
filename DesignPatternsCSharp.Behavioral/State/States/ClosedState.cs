using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.State
{
	class ClosedState : BookingState
	{
		private string reasonClosed;

		public ClosedState(string reason)
		{
			reasonClosed = reason;
		}

		public override void Cancel(BookingContext booking)
		{
			Console.WriteLine("Invalid Action for the state: Closed Booking Error");
		}

		public override void DatePassed(BookingContext booking)
		{
			Console.WriteLine("Invalid Action for the state: Closed Booking Error");
		}

		public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
		{
			Console.WriteLine("Invalid Action for the state: Closed Booking Error");
		}

		public override void EnterState(BookingContext booking)
		{
			booking.ShowState($"Closed: {reasonClosed}");

		}
	}
}
