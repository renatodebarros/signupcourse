using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Contracts.Repository
{
	public interface ICourseRepository
	{
		Task<IEnumerable<CourseModel>> GetAll();
		Task<IEnumerable<CourseModel>> Get(string search);
		Task<CourseModel> Get(int id);
		Task Add(CourseModel item);

		Task Edit(CourseModel item);

		Task Delete(int id);

		Task UpdateConsume(int id);

	}
}
