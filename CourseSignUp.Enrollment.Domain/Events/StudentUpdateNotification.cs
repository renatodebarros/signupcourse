using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Enrollment.Domain.Events
{
	public class StudentUpdateNotification : INotification
	{
		public StudentModel student { get; set; }
	}
}
