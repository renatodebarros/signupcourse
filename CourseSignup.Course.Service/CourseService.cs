using AutoMapper;
using CourseSignup.Course.Domain.Commands.Course;
using CourseSignup.Course.Domain.Commands.Lecturer;
using CourseSignup.Course.Domain.Commands.Enrollment;
using CourseSignup.Course.Domain.Queries;
using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.ViewModel;
using CourseSignUp.Domain.Course.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseSignup.Course.Domain.Commands.Student;
using CourseSignup.Course.Domain.Events.Course;
using CourseSignup.Course.Domain.Events.Lecturer;
using CourseSignup.Course.Domain.Events.Student;
using CourseSignup.Course.Domain.Events.Enrollment;

namespace CourseSignUp.Course.Service
{
	public class CourseService : ICourseService
	{
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public CourseService(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}

		public async Task<CourseNotification> Add(CourseVM courseVM)
		{

			var entity = _mapper.Map<CourseModel>(courseVM);

			return await _mediator.Send(new CourseCreateCommand() { course = entity });
		}

		public async Task<LecturerNotification> Add(LecturerVM lecturer)
		{

			var entity = _mapper.Map<LecturerModel>(lecturer);

			return await _mediator.Send(new LecturerCreateCommand() { lecturer = entity });

			 
		}

		public async Task<IEnumerable<CourseVM>> GetCourse(string searchTerm)
		{
			var result = _mapper.Map<CourseVM>(await _mediator.Send(new CourseQueryByTerm() { searchTerm = searchTerm }));

			return (IEnumerable<CourseVM>)result;

		}

		public async Task<CourseVM> GetCourse(int id)
		{
			var result = _mapper.Map<CourseVM>(await _mediator.Send(new CourseQueryById() { id = id }));

			return _mapper.Map<CourseVM>(result);

		}

		public async Task<IEnumerable<CourseVM>> GetCourses()
		{
			var courses = await _mediator.Send(new CourseQueryByTerm());

			var result = _mapper.Map<IEnumerable<CourseVM>>(courses);

			return result;
		}

		public async Task<IEnumerable<LecturerVM>> GetLecturer(string searchTerm)
		{
			var lecturers = await _mediator.Send(new LecturerQuery() { searchTerm = searchTerm });

			return _mapper.Map<IEnumerable<LecturerVM>>(lecturers); 
		}

		public async Task<IEnumerable<LecturerVM>> GetLecturers()
		{
			var lecturers = await _mediator.Send(new LecturerQuery());

			return _mapper.Map<IEnumerable<LecturerVM>>(lecturers);
		}

		public async Task<EnrollmentNotification> Signup(EnrollmentVM enrollment)
		{
			var signup = _mapper.Map<EnrollmentModel>(enrollment);

			//Create the student
			var student = _mapper.Map<StudentModel>(enrollment);
			

			var studentResult = await  createStudent(student);

			signup.StudentyId = studentResult.student.Id;
			signup.EnrollmentedAt = DateTime.Now;

			var resultSignup = await _mediator.Send(new EnrollmentAddCommand() { enrollment = signup });

			
			return resultSignup;
		}

		private async Task<StudentNotification> createStudent(StudentModel _student)
		{
			return await _mediator.Send(new StudentCreateCommand() { student = _student });
		}

		public async Task<CourseNotification> Update(CourseVM courseVM)
		{
			return await _mediator.Send(new CourseUpdateCommand() { course = _mapper.Map<CourseModel>(courseVM) });
		}

		public async Task<LecturerNotification> Update(LecturerVM lecturerVM)
		{
			return await _mediator.Send(new LecturerUpdateCommand() { lecturer = _mapper.Map<LecturerModel>(lecturerVM) });
		}

		public async Task<IEnumerable<EnrollmentVM>> GetEnrollments()
		{
			var enrollments = await _mediator.Send(new EnrollementQuery());

			return _mapper.Map<IEnumerable<EnrollmentVM>>(enrollments);
		}
	}
}
