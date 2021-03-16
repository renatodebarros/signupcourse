using CourseSignup.Domain.Enrollment.Contracts.Repository;
using CourseSignUp.Enrollment.Domain.Commands;
using CourseSignUp.Enrollment.Domain.Events;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Enrollment.Domain.Handlers
{
	public class EnrollmentAddHandler : IRequestHandler<EnrollmentAddCommand, string>
	{
		internal readonly IMediator _mediator;
		internal readonly IEnrollmentRepository _repository;

		public EnrollmentAddHandler(IMediator mediator, IEnrollmentRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<string> Handle(EnrollmentAddCommand request, CancellationToken cancellationToken)
		{
			try
			{
				bool result = await _repository.Add(request.enrollment);

				request.enrollment.Accepted = result;

				await _mediator.Publish(new EnrollmentAddNotification() { enrollment = request.enrollment });
				return await Task.FromResult(result ? "Your signup was created successfull." : "Your already enrollmented in this course.");
			}
			catch (Exception ex)
			{
				await _mediator.Publish(new ErrorNotification { Error = ex.Message, SourceError = ex.StackTrace });
				return await Task.FromResult("Some wrong happened to create your signup.");
			};
		}
	}
}
