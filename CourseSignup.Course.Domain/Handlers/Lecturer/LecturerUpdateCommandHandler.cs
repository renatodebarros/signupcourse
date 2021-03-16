using CourseSignup.Course.Domain.Commands.Lecturer;
using CourseSignup.Course.Domain.Events.Lecturer;
using CourseSignUp.Domain.Contracts.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Lecturer
{
	public class LecturerUpdateCommandHandler : IRequestHandler<LecturerUpdateCommand, LecturerNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly ILecturerRepository _repository;

		public LecturerUpdateCommandHandler(IMediator mediator, ILecturerRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<LecturerNotification> Handle(LecturerUpdateCommand request, CancellationToken cancellationToken)
		{
			string fullName = request.lecturer.FirstName + " " + request.lecturer.LastName;

			try
			{
				await _repository.Edit(request.lecturer);

				var result = new LecturerNotification() { lecturer = request.lecturer, message = $"Lecturer {fullName} was created successful." };

				await _mediator.Publish(result);

				return await Task.FromResult(result);

			}
			catch
			{
				var result = new LecturerNotification() { lecturer = request.lecturer, message = $"Some thing is wrong cannot create the lecturer {fullName}." };

				return await Task.FromResult(result);

			}
		}
	}
}
