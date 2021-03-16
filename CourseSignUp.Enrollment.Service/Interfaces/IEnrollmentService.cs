using CourseSignUp.Enrollment.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Enrollment.Service.Interfaces
{
	public interface IEnrollmentService
	{
		Task<EnrollmentVM> Signup(EnrollmentVM enrollment);
	}
}
