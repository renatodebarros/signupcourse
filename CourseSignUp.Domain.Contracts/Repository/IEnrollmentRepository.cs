using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Contracts.Repository
{
	public interface IEnrollmentRepository
	{
		Task Add(EnrollmentModel enrollment);

		Task<IEnumerable<EnrollmentModel>> GetAll();
	}
}
