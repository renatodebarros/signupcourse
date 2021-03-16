using CourseSignup.Course.Domain.Events.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Commands.Course
{
	public class CourseUpateAvailableCommand : IRequest<CourseAvailableNotification>
	{
		public int id { get; set; }
	}
}
