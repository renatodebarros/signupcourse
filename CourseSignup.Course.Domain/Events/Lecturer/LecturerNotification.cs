using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Events.Lecturer
{
	public class LecturerNotification : INotification
	{
		public LecturerModel lecturer { get; set; }
		public string message { get; set; }
	}
}
