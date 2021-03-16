using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Enrollment.Domain.Events
{
	public class QueryNotification : INotification
	{

		public string SearchTerm { get; set; }

	}
}
