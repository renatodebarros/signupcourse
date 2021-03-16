
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
	public class EnrollmentQueryHandler : IRequestHandler<EnrollementQuery, IEnumerable<EnrollmentModel>>
	{
		internal readonly IMediator _mediator;
		internal readonly IEnrollmentRepository _repository;

		public EnrollmentQueryHandler(IMediator mediator, IEnrollmentRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<IEnumerable<EnrollmentModel>> Handle(EnrollementQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAll();
		}
	}
}
