using Chain_of_Responsibility_First_Look.Business.Exceptions;
using DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers.UserValidation;
using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look.Business.Validators
{
    public class SocialSecurityNumberValidator
    {
        public bool Validate(string socialSecurityNumber, RegionInfo region)
        {
            switch(region.TwoLetterISORegionName)
            {
                case "SE": return ValidateSwedishSocialSecurityNumber(socialSecurityNumber);
                case "US": return ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber);
                default: throw new UnsupportedSocialSecurityNumberException();
            }

            // C# 8.0 version
            //return region.TwoLetterISORegionName switch
            //{
            //    "SE" => ValidateSwedishSocialSecurityNumber(socialSecurityNumber),
            //    "US" => ValidateUnitedStatesSocialSecurityNumber(socialSecurityNumber),
            //    _ => throw new UnsupportedSocialSecurityNumberException()
            //};
        }

		internal object SetNext(AgeValidationHandler ageValidationHandler)
		{
			throw new NotImplementedException();
		}

		private bool ValidateSwedishSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 1;
        }

        private bool ValidateUnitedStatesSocialSecurityNumber(string socialSecurityNumber)
        {
            // Not actually how it's done..

            return socialSecurityNumber.Length > 2;
        }
    }
}
