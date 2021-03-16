
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;

namespace CourseSignUp.Infra.Data.Course
{
	public class CourseRepository : ICourseRepository
	{

		private static List<CourseModel> courses = new List<CourseModel>();

		public async Task Add(CourseModel item)
		{
			if (courses.Where(x => x.CourseName.ToLower() == item.CourseName.ToLower()).Count() == 0)
				await Task.Run(() => {
					item.Id = courses.Count;
					item.Id++;
					courses.Add(item); });
		}

		public async Task Delete(int id)
		{
			await Task.Run(() =>
			{
				var element = courses.Where(x => x.Id == id).FirstOrDefault();
				courses.Remove(element);
			});
		}

		public async Task Edit(CourseModel item)
		{
			await Task.Run(() =>
			{
				var element = courses.Where(x => x.Id == item.Id).FirstOrDefault();
				courses.Remove(element);
				
				courses.Add(item);
			});
		}

		public async Task<IEnumerable<CourseModel>> Get(string search)
		{
			var result = courses.Where(x => x.CourseName.ToLower().Contains(search));
			return await Task.Run(() => result);
		}

		public async Task<CourseModel> Get(int id)
		{
			var result = courses.Where(x => x.Id==id).FirstOrDefault();

			return await Task.Run(() => result);
		}

		public async Task<IEnumerable<CourseModel>> GetAll()
		{
			return await Task.Run(() => courses);
		}

		public async Task UpdateConsume(int id)
		{
			await Task.Run(() =>
			{
				var element = courses.Where(x => x.Id == id).FirstOrDefault();
				courses.Remove(element);

				element.Enrollmenteds++;
				courses.Add(element);
			});

		}
	}
}
