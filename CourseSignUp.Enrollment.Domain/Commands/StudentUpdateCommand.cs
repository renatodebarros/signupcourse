using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;

namespace CourseSignUp.Enrollment.Domain.Commands
{
	public class StudentUpdateCommand : IRequest<string>
	{
		public StudentModel student { get; set; }
	}
}
