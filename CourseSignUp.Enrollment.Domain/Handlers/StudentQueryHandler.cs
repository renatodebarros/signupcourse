using CourseSignup.Domain.Enrollment.Contracts.Models;
using CourseSignUp.Enrollment.Domain.Events;
using CourseSignUp.Enrollment.Domain.Queries;
using MediatR;
using StudentSignup.Domain.Enrollment.Contracts.Repository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Enrollment.Domain.Handlers
{
	public class StudentQueryHandler : IRequestHandler<StudentQuery, IEnumerable<StudentModel>>
	{
		internal readonly IMediator _mediator;
		internal readonly IStudentRepository _repository;

		public StudentQueryHandler(IMediator mediator, IStudentRepository repository)
		{
			_mediator = mediator;
			this._repository = repository;
		}

		public async Task<IEnumerable<StudentModel>> Handle(StudentQuery request, CancellationToken cancellationToken)
		{
			IEnumerable<StudentModel> data;
			if (!string.IsNullOrEmpty(request.searchTerm))
			{
				var resultSet = await _repository.Get(request.searchTerm);

				data = resultSet;
			}
			else
			{
				var resultSet = await _repository.GetAll();

				data = resultSet;
			}

			await _mediator.Publish(new QueryNotification() { SearchTerm = request.searchTerm });
			return await Task.FromResult(data);
		}

	}
}
