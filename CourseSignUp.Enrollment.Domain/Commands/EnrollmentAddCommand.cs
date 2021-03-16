using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;

namespace CourseSignUp.Enrollment.Domain.Commands
{
	public class EnrollmentAddCommand : IRequest<string>
	{
		public EnrollmentModel enrollment { get; set; }
	}
}
