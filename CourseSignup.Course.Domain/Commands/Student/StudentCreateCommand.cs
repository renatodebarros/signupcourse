using CourseSignup.Course.Domain.Events.Student;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Commands.Student
{
	public class StudentCreateCommand : IRequest<StudentNotification>
	{
		public StudentModel student { get; set; }
	}
}
