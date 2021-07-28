using System;
using System.Collections.Generic;
using System.Text;
using Chain_of_Responsibility_First_Look.Business.Exceptions;
using Chain_of_Responsibility_First_Look.Business.Models;

namespace DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers.UserValidation
{
	class CitizenshipRegionValidationHandler : Handler<User>
	{
		public override void Handle(User user)
		{
			if (user.CitizenshipRegion.TwoLetterISORegionName == "NO")
			{
				throw new UserValidationException("We do not support norwegians");
			}
			base.Handle(user);
		}
	}
}
