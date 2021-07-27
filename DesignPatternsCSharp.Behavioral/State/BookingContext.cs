using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsCSharp.Behavioral.State
{
	public class BookingContext
	{
		public string Attendee { get; set; }
		public int TicketCount { get; set; }
		public int BookingID { get; set; }
		private BookingState currentState;

		public void TransitionToState(BookingState state)
		{
			currentState = state;
			currentState.EnterState(this);
		}

		public BookingContext()
		{
			TransitionToState(new NewState());
		}

		public void SubmitDetails()
		{
			currentState.EnterDetails(this, Attendee, TicketCount);
		}

		public void Cancel()
		{
			currentState.Cancel(this);
		}

		public void DatePassed()
		{
			currentState.DatePassed(this);
		}

		public void ShowState(string stateName)
		{
			Console.WriteLine(stateName, TicketCount, Attendee, BookingID);
		}
	}
}
