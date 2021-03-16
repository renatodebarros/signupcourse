using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSignup.Infra.Enrollment.Data
{
	public class StudentRepository : IStudentRepository
	{
		private static List<StudentModel> students = new List<StudentModel>();

		public async Task Add(StudentModel item)
		{
			if (students.Where(x => x.FirstName.ToLower() == item.FirstName.ToLower() && x.LastName.ToLower() == item.LastName.ToLower()).Count() == 0)
				await Task.Run(() => {
					item.Id = students.Count;
					item.Id++;
					students.Add(item);
					});
		}

		public async Task Delete(int id)
		{
			await Task.Run(() =>
			{
				var element = students.Where(x => x.Id == id).FirstOrDefault();
				students.Remove(element);
			});
		}

		public async Task Edit(StudentModel item)
		{
			await Task.Run(() =>
			{
				var element = students.Where(x => x.Id == item.Id).FirstOrDefault();
				students.Remove(element);

				students.Add(item);
			});
		}

		public async Task<IEnumerable<StudentModel>> Get(string search)
		{
			var result = students.Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search));
			return await Task.Run(() => result);
		}

		public async Task<StudentModel> Get(int id)
		{
			var result = students.Where(x => x.Id == id).FirstOrDefault();
			return await Task.Run(() => result);
		}

		public async Task<IEnumerable<StudentModel>> GetAll()
		{
			return await Task.Run(() => students);
		}
	}
}
