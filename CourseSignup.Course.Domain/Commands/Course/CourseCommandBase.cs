using CourseSignup.Course.Domain.Events.Course;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;

namespace CourseSignup.Course.Domain.Commands.Course
{
	public abstract class CourseCommandBase : IRequest<CourseNotification>
	{
		public CourseModel course { get; set; }
	}
}
