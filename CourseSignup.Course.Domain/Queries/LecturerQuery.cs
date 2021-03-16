using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System.Collections.Generic;

namespace CourseSignup.Course.Domain.Queries
{
	public class LecturerQuery : IRequest<IEnumerable<LecturerModel>>
	{
		public string searchTerm { get; set; }
	}
}
