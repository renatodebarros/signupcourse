using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Events.Enrollment
{
	public class EnrollmentNotificationHandler :
		INotificationHandler<EnrollmentNotification>,
		INotificationHandler<ErrorNotification>
	{
		public Task Handle(EnrollmentNotification notification, CancellationToken cancellationToken)
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
