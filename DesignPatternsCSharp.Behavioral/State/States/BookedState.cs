using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.State
{
	class BookedState : BookingState
	{
		public override void Cancel(BookingContext booking)
		{
			booking.TransitionToState(new ClosedState("Booking Canceled: expect a refund"));
		}

		public override void DatePassed(BookingContext booking)
		{
			booking.TransitionToState(new ClosedState("We hope you enjoyed the event"));
		}

		public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
		{

		}

		public override void EnterState(BookingContext booking)
		{
			booking.ShowState("Booked: Enjoy the event");
		}
	}
}
