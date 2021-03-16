using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Events.Course
{
	public class CourseNotification : INotification
	{
		public CourseModel course { get; set; }
		public string message { get; set; }
	}
}
