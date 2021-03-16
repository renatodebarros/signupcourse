using CourseSignup.Course.Domain.Queries;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Course
{
	public class CourseQueryHandler : IRequestHandler<CourseQueryByTerm, IEnumerable<CourseModel>>
	{
		internal readonly IMediator _mediator;
		internal readonly ICourseRepository _repository;

		public CourseQueryHandler(IMediator mediator, ICourseRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<IEnumerable<CourseModel>> Handle(CourseQueryByTerm request, CancellationToken cancellationToken)
		{

			if (request.searchTerm != null)
			{
				return await  _repository.Get(request.searchTerm.ToLower());
			}
			else
			{
				return await _repository.GetAll();
			}
		}
	}
}
