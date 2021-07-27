using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatternsCSharp.Behavioral.State
{
	class PendingState : BookingState
	{
		CancellationTokenSource cancelToken;
		public override void Cancel(BookingContext booking)
		{
			cancelToken.Cancel();
		}

		public override void DatePassed(BookingContext booking)
		{

		}

		public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
		{
;
		}

		public override void EnterState(BookingContext booking)
		{
			cancelToken = new CancellationTokenSource();
			booking.ShowState("Pending: Processing booking");

			StaticFunctions.ProcessBooking(booking, ProcessingComplete, cancelToken);
		}

		private void ProcessingComplete(BookingContext booking, StaticFunctions.ProcessingResult result)
		{
			switch (result)
			{
				case StaticFunctions.ProcessingResult.Success:
					booking.TransitionToState(new BookedState());
					break;
				case StaticFunctions.ProcessingResult.Fail:
					Console.WriteLine("Error: pending resulted in an error");
					booking.TransitionToState(new NewState());
					break;
				case StaticFunctions.ProcessingResult.Cancel:
					booking.TransitionToState(new ClosedState("Processing canceled"));
					break;
			}
		}
	}
}
