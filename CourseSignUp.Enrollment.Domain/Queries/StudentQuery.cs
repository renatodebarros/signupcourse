using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Enrollment.Domain.Queries
{
	public class StudentQuery : IRequest<IEnumerable<StudentModel>>
	{

		public string searchTerm { get; set; }
	}
}
