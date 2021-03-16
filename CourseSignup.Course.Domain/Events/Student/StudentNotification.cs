using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Events.Student
{
	public class StudentNotification : INotification
	{
		public StudentModel student { get; set; }
		public string message { get; set; }
	}
}
