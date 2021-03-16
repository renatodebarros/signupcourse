using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Queries
{
	public class CourseQueryByTerm : IRequest<IEnumerable<CourseModel>>
	{
		public string searchTerm { get; set; }

	}

	public class CourseQueryById : IRequest<CourseModel>
	{
		public int id { get; set; }
	}
}
