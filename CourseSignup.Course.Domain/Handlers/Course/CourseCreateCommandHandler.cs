using CourseSignup.Course.Domain.Commands.Course;
using CourseSignup.Course.Domain.Events;
using CourseSignup.Course.Domain.Events.Course;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Course
{
	public class CourseCreateCommandHandler : IRequestHandler<CourseCreateCommand, CourseNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly ICourseRepository _repository;

		public CourseCreateCommandHandler(IMediator mediator, ICourseRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<CourseNotification> Handle(CourseCreateCommand request, 
			CancellationToken cancellationToken)
		{
			try
			{

				await _repository.Add(request.course);

				var result = new CourseNotification(){ course = request.course, message = $"Course {request.course.CourseName} was created successful." };

				await _mediator.Publish(result);

				return await Task.FromResult(result);

			}
			catch (Exception ex)
			{
				await _mediator.Publish(new ErrorNotification { ErrorDescription = ex.Message, ErrorTrace = ex.StackTrace });
				var result = new CourseNotification() { course = request.course, message = $"Some thing is wrong cannot create the course {request.course.CourseName}." };

				return await Task.FromResult(result);

			}
		}
	}
}
