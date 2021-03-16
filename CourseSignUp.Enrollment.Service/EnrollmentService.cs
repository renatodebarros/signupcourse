using AutoMapper;
using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Domain.Commands;
using CourseSignUp.Course.Service.ViewModel;
using MediatR;
using System;
using System.Threading.Tasks;
using CourseSignUp.Domain.Course.Contracts.Models;

namespace CourseSignUp.Course.Service
{
	public class EnrollmentService : IEnrollmentService
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;


		public EnrollmentService(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		public async Task<EnrollmentVM> Signup(EnrollmentVM enrollment)
		{


			//Check if has course available to siguup

			var signup = _mapper.Map<EnrollmentModel>(enrollment);

			var student = _mapper.Map<StudentModel>(enrollment);
			student.Id = enrollment.Id;

			signup.StudentyId = student.Id;
			signup.EnrollmentedAt = DateTime.Now;

			createStudent(student);

			var resultSignup =	await _mediator.Send(new EnrollmentAddCommand() { enrollment = signup });

			enrollment.Message = resultSignup;


			return enrollment;
		}

		private void createStudent(StudentModel _student)
		{
			_mediator.Send(new StudentCreateCommand() { student = _student });
		}



	}
}
