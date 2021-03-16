using CourseSignup.Course.Domain.Queries;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignup.Course.Domain.Handlers.Course
{
	public class CourseQueryByIdHandlerBase : IRequestHandler<CourseQueryById, CourseModel>
	{
		internal readonly IMediator _mediator;
		internal readonly ICourseRepository _repository;

		public CourseQueryByIdHandlerBase(IMediator mediator, ICourseRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<CourseModel> Handle(CourseQueryById request, CancellationToken cancellationToken)
		{
			return await _repository.Get(request.id);
		}
	}
}