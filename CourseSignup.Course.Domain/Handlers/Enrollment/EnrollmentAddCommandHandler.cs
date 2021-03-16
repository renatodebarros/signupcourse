using CourseSignup.Course.Domain.Commands.Course;
using CourseSignup.Course.Domain.Commands.Enrollment;
using CourseSignup.Course.Domain.Events;
using CourseSignup.Course.Domain.Events.Enrollment;
using CourseSignup.Course.Domain.Queries;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Enrollment
{
	public class EnrollmentAddCommandHandler : IRequestHandler<EnrollmentAddCommand, EnrollmentNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly IEnrollmentRepository _repository;

		public EnrollmentAddCommandHandler(IMediator mediator, IEnrollmentRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<EnrollmentNotification> Handle(EnrollmentAddCommand request, CancellationToken cancellationToken)
		{

			try
			{
				var course = await _mediator.Send(new CourseQueryById() { id = request.enrollment.CourseId });


				if (course.MaxEnrollments - course.Enrollmenteds > 0)
				{

					await _repository.Add(request.enrollment);

					await _mediator.Send(new CourseUpateAvailableCommand() { id = request.enrollment.CourseId });

					var result = new EnrollmentNotification() { enrollment = request.enrollment, message = "You assigned to course." };

					await _mediator.Publish(result);

					return await Task.FromResult(result);

				}
				else
				{
					var result = new EnrollmentNotification() { enrollment = request.enrollment, message = "There no more subscriptions available for this course." };
					await _mediator.Publish(result);
					return await Task.FromResult(result);
				}
			}
			catch(Exception ex)
			{
				await _mediator.Publish(new ErrorNotification { ErrorDescription = ex.Message, ErrorTrace = ex.StackTrace });
				return await Task.FromResult(new EnrollmentNotification() { enrollment = request.enrollment, message = "Sorry some wrong happend, please try later." });
			}
			
		}
	}
}
