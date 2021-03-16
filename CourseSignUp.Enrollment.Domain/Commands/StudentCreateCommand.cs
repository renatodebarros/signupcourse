using CourseSignup.Domain.Enrollment.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Enrollment.Domain.Commands
{
	public class StudentCreateCommand : IRequest<string>
	{
		public StudentModel student { get; set; }
	}
}
