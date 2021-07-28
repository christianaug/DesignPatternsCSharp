using System;
using System.Collections.Generic;
using System.Text;
using Chain_of_Responsibility_First_Look.Business.Exceptions;
using Chain_of_Responsibility_First_Look.Business.Models;

namespace DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers.UserValidation
{
	class NameValidationHandler : Handler<User>
	{
		public override void Handle(User user)
		{
			if (user.Name.Length <= 1)
			{
				throw new UserValidationException("Your name is too short");
			}
			base.Handle(user);
		}
	}
}
