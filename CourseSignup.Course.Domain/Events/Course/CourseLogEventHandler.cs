using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Events.Course
{
	public class CourseLogEventHandler :
		INotificationHandler<CourseNotification>,
		INotificationHandler<ErrorNotification>
	{
		public Task Handle(CourseNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
				Console.WriteLine("Operation");
			});
		}

		public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
		{
			return Task.Run(() =>
			{
			});
		}
	}
}
