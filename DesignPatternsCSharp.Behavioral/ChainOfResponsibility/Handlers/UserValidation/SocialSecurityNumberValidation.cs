using System;
using System.Collections.Generic;
using System.Text;
using Chain_of_Responsibility_First_Look.Business.Exceptions;
using Chain_of_Responsibility_First_Look.Business.Models;
using Chain_of_Responsibility_First_Look.Business.Validators;

namespace DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers.UserValidation
{
	public class SocialSecurityNumberValidation : Handler<User>
	{
		private SocialSecurityNumberValidator socialSecurityNumberValidator
			= new SocialSecurityNumberValidator();
		public override void Handle(User request)
		{
			if (!socialSecurityNumberValidator.Validate(request.SocialSecurityNumber, request.CitizenshipRegion))
			{
				throw new UserValidationException("Social security number could not be validated");
			}
			base.Handle(request);
		}
	}
}
