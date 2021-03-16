using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Contracts.Repository
{
	public interface IStudentRepository
	{
		Task<IEnumerable<StudentModel>> GetAll();

		Task<StudentModel> Get(int id);

		Task<IEnumerable<StudentModel>> Get(string search);
		Task Add(StudentModel item);

		Task Edit(StudentModel item);

		Task Delete(int id);
	}
}
