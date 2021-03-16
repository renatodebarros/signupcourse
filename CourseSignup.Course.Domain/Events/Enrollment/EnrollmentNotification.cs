using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Events.Enrollment
{
	public class EnrollmentNotification : INotification
	{
		public EnrollmentModel enrollment { get; set; }
		public string message { get; set; }
	}
}
