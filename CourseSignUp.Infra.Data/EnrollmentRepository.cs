using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Domain.Course.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignup.infra.Enrollment.Data
{
	public class EnrollmentRepository : IEnrollmentRepository
	{
		private static List<EnrollmentModel> enrollments = new List<EnrollmentModel>();

		public async Task Add(EnrollmentModel enrollment)
		{


			if (enrollments.Where(x => x.StudentyId == enrollment.StudentyId && x.CourseId == enrollment.CourseId).Count() == 0)
			{
				await Task.Run(() => {
					enrollment.Id = enrollments.Count;
					enrollment.Id++;
					enrollments.Add(enrollment); });
			}
			
		}

		public async Task<IEnumerable<EnrollmentModel>> GetAll()
		{
			return await Task.Run(() => enrollments);
		}

	}
}
