using CourseSignup.Course.Domain.Events.Enrollment;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Commands.Enrollment
{
	public class EnrollmentAddCommand : IRequest<EnrollmentNotification>
	{
		public EnrollmentModel enrollment { get; set; }
	}
}
