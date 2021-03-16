using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignup.Course.Domain.Queries
{
	public class EnrollementQuery : IRequest<IEnumerable<EnrollmentModel>>
	{

	}
}
