using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Events
{
	public class ErrorNotification : INotification
	{

		public string ErrorDescription { get; set; }

		public string ErrorTrace { get; set; }

	}
}
