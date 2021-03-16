﻿
using CourseSignUp.Enrollment.Domain.Commands;
using CourseSignUp.Enrollment.Domain.Events;
using MediatR;
using StudentSignup.Domain.Enrollment.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Enrollment.Domain.Handlers
{
	public class StudentCreateCommandHandler : IRequestHandler<StudentCreateCommand, string>
	{
		internal readonly IMediator _mediator;
		internal readonly IStudentRepository _repository;


		public StudentCreateCommandHandler(IMediator mediator, IStudentRepository repository)
		{
			_mediator = mediator;
			_repository = repository;
		}

		public async Task<string> Handle(StudentCreateCommand request, CancellationToken cancellationToken)
		{
			try
			{
				string fullName = request.student.FirstName + "" + request.student.LastName;

				await _repository.Add(request.student);
				await _mediator.Publish(new StudentCreateNotification() { student = request.student });
				return await Task.FromResult($"Student {fullName} was created successfull.");
			}
			catch (Exception ex)
			{
				await _mediator.Publish(new StudentCreateNotification() { student = request.student });
				await _mediator.Publish(new ErrorNotification { Error = ex.Message, SourceError = ex.StackTrace });
				return await Task.FromResult("Some wrong happened to create the student.");
			};
		}
	}
}
