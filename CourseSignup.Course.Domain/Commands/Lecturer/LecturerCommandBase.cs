using CourseSignup.Course.Domain.Events.Lecturer;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Commands.Lecturer
{
	public abstract class LecturerCommandBase : IRequest<LecturerNotification>
	{
		public LecturerModel lecturer { get; set; }

	}
}
