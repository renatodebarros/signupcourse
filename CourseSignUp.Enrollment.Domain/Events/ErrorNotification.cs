using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Enrollment.Domain.Events
{
	public class ErrorNotification : INotification
	{
		public string Error { get; set; }
		public string SourceError { get; set; }
	}
}
