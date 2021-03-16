using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System.Collections.Generic;

namespace CourseSignup.Course.Domain.Queries
{
	public class StudentQuery : IRequest<IEnumerable<StudentModel>>
	{
		public string searchTerm { get; set; }

		public int id { get; set; }

	}
}
