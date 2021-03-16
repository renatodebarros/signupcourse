using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;

namespace CourseSignUp.Enrollment.Domain.Events
{
	public class EnrollmentAddNotification : INotification
	{

		public EnrollmentModel enrollment { get; set; }
			
	}
}