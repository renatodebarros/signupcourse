using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;

namespace CourseSignUp.Enrollment.Domain.Events
{
	public class StudentCreateNotification : INotification
	{
		public StudentModel student {get;set;}
	}
}
