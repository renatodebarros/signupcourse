using CourseSignup.Course.Domain.Commands.Lecturer;
using CourseSignup.Course.Domain.Events;
using CourseSignup.Course.Domain.Events.Lecturer;
using CourseSignUp.Domain.Contracts.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Lecturer
{
	public class LecturerCreateCommandHandler : IRequestHandler<LecturerCreateCommand, LecturerNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly ILecturerRepository _repository;

		public LecturerCreateCommandHandler(IMediator mediator, ILecturerRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<LecturerNotification> Handle(LecturerCreateCommand request, CancellationToken cancellationToken)
		{
			string fullName = request.lecturer.FirstName + " " + request.lecturer.LastName;

			try
			{
				await _repository.Add(request.lecturer);

				var result = new LecturerNotification() { lecturer = request.lecturer, message = $"Lecturer {fullName} was created successful." };

				await _mediator.Publish(result);

				return await Task.FromResult(result);

			}
			catch (Exception ex)
			{
				await _mediator.Publish(new ErrorNotification { ErrorDescription = ex.Message, ErrorTrace = ex.StackTrace });
				var result = new LecturerNotification() { lecturer = request.lecturer, message = $"Some thing is wrong cannot create the lecturer {fullName}." };

				return await Task.FromResult(result);

			}
		}
	}
}
