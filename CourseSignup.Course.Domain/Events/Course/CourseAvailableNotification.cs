using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Events.Course
{
	public class CourseAvailableNotification : INotification
	{
		public int id { get; set; }
		public string message { get; set; }
	}
}
