using CourseSignup.Course.Domain.Events.Course;
using CourseSignup.Course.Domain.Events.Enrollment;
using CourseSignup.Course.Domain.Events.Lecturer;
using CourseSignUp.Course.Service.ViewModel;
using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Course.Service.Interfaces
{
	public interface ICourseService
	{
		Task<CourseNotification> Add(CourseVM entity);

		Task<CourseNotification> Update(CourseVM entity);

		Task<LecturerNotification> Add(LecturerVM entity);

		Task<LecturerNotification> Update(LecturerVM entity);

		Task<IEnumerable<CourseVM>> GetCourse(string searchTerm);

		Task<CourseVM> GetCourse(int courseId);

		Task<IEnumerable<CourseVM>> GetCourses();

		Task<IEnumerable<LecturerVM>> GetLecturer(string searchTerm);

		Task<IEnumerable<LecturerVM>> GetLecturers();

		Task<EnrollmentNotification> Signup(EnrollmentVM enrollment);

		Task<IEnumerable<EnrollmentVM>> GetEnrollments();

	}
}
