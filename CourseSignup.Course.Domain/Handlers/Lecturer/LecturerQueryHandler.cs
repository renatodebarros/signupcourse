using CourseSignup.Course.Domain.Queries;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Lecturer
{
	public class LecturerQueryHandler : IRequestHandler<LecturerQuery, IEnumerable<LecturerModel>>
	{
		internal readonly IMediator _mediator;
		internal readonly ILecturerRepository _repository;

		public LecturerQueryHandler(IMediator mediator, ILecturerRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<IEnumerable<LecturerModel>> Handle(LecturerQuery request, CancellationToken cancellationToken)
		{
			if (request.searchTerm == null)
				return await _repository.GetAll();
			else
				return await _repository.Get(request.searchTerm.ToLower());
		}
	}
}
