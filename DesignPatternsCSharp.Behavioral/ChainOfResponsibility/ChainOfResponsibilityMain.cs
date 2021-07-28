using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Chain_of_Responsibility_First_Look.Business;
using Chain_of_Responsibility_First_Look.Business.Models;

namespace DesignPatternsCSharp.Behavioral.ChainOfResponsibility
{
	public class ChainOfResponsibilityMain
	{
		public static void Run()
		{
            var user = new User("Christian Augustyn",
                            "870101XXXX",
                            new RegionInfo("SE"),
                            new DateTimeOffset(1987, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));


            Console.WriteLine(user.Age);
            var processor = new UserProcessor();

            var ressult = processor.Register(user);

            Console.WriteLine(ressult);

        }
	}
}
