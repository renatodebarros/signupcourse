
using CourseSignup.Course.Domain.Commands.Course;
using CourseSignup.Course.Domain.Events;
using CourseSignup.Course.Domain.Events.Course;
using CourseSignUp.Domain.Contracts.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Course
{
	public class CourseUpdateAvailableHandler : IRequestHandler<CourseUpateAvailableCommand, CourseAvailableNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly ICourseRepository _repository;

		public CourseUpdateAvailableHandler(IMediator mediator, ICourseRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<CourseAvailableNotification> Handle(CourseUpateAvailableCommand request, CancellationToken cancellationToken)
		{
			try
			{

				await _repository.UpdateConsume(request.id);

				var result = new CourseAvailableNotification() { id = request.id, message = $"Quantity available  updated." };

				await _mediator.Publish(result);

				return await Task.FromResult(result);

			}
			catch (Exception ex)
			{
				await _mediator.Publish(new ErrorNotification { ErrorDescription = ex.Message, ErrorTrace = ex.StackTrace });
				var result = new CourseAvailableNotification() { id = request.id, message = $"Some thing is wrong when updated the quantity." };

				return await Task.FromResult(result);

			}
		}
	}
}

