using CourseSignup.Course.Domain.Commands.Student;
using CourseSignup.Course.Domain.Events.Student;
using CourseSignUp.Domain.Contracts.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Student
{
	public class StudentCreateHandler : IRequestHandler<StudentCreateCommand, StudentNotification>
	{
		internal readonly IMediator _mediator;
		internal readonly IStudentRepository _repository;

		public StudentCreateHandler(IMediator mediator, IStudentRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<StudentNotification> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
		{
			string fullName = request.student.FirstName + " " + request.student.LastName;

			try
			{
				await _repository.Add(request.student);

				var result = new StudentNotification() { student = request.student, message = $"Student {fullName} was created successful." };

				await _mediator.Publish(result);

				return await Task.FromResult(result);

			}
			catch
			{
				var result = new StudentNotification() { student = request.student, message = $"Some thing is wrong cannot create the student {fullName}." };

				return await Task.FromResult(result);

			}
		}
	}
}
