using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;

namespace CourseSignUp.Course.Service.ViewModel
{
	public class LecturerVM
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int IdCourse { get; set; }
	}
}
