using Chain_of_Responsibility_First_Look.Business.Exceptions;
using Chain_of_Responsibility_First_Look.Business.Models;
using Chain_of_Responsibility_First_Look.Business.Validators;
using DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers;
using DesignPatternsCSharp.Behavioral.ChainOfResponsibility.Handlers.UserValidation;

namespace Chain_of_Responsibility_First_Look.Business
{
    public class UserProcessor
    {
        public bool Register(User user)
        {

            try
			{
                var handler = new CitizenshipRegionValidationHandler();
                handler.SetNext(new AgeValidationHandler())
                    .SetNext(new NameValidationHandler())
                    .SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            } catch(UserValidationException e)
			{
                return false;
			}

            return true;
        }
    }
}
