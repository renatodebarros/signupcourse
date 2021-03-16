
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;

namespace lecturersignUp.Infra.Data.Lecturer
{
	public class LeacturerRepository : ILecturerRepository
	{

		private static List<LecturerModel> lecturers = new List<LecturerModel>();

		public async Task Add(LecturerModel item)
		{
			if (lecturers.Where(x => x.FirstName.ToLower() == item.FirstName.ToLower() && x.LastName.ToLower() == item.LastName.ToLower()).Count() == 0)
				await Task.Run(() => {
					item.Id = lecturers.Count;
					item.Id++;
					lecturers.Add(item);
				});
		}

		public async Task Delete(int id)
		{
			await Task.Run(() =>
			{
				var element = lecturers.Where(x => x.Id == id).FirstOrDefault();
				lecturers.Remove(element);
			});
		}

		public async Task Edit(LecturerModel item)
		{
			await Task.Run(() =>
			{
				var element = lecturers.Where(x => x.Id == item.Id).FirstOrDefault();
				lecturers.Remove(element);
				
				lecturers.Add(item);
			});
		}

		public async Task<IEnumerable<LecturerModel>> Get(string search)
		{
			var result = lecturers.Where(x => x.FirstName.ToLower().Contains(search) || x.LastName.ToLower().Contains(search));
			return await Task.Run(() => result);
		}

		public async Task<IEnumerable<LecturerModel>> GetAll()
		{
			return await Task.Run(() => lecturers);
		}
	}
}
