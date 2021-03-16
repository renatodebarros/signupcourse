using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Contracts.Repository
{
	public interface ILecturerRepository
	{
		Task<IEnumerable<LecturerModel>> GetAll();
		Task<IEnumerable<LecturerModel>> Get(string search);
		Task Add(LecturerModel item);

		Task Edit(LecturerModel item);

		Task Delete(int id);
	}
}
