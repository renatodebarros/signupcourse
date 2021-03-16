using System.Collections.Generic;

namespace CourseSignUp.Domain.Course.Contracts.Models
{
	public class LecturerModel : BaseModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public int IdCourse { get; set; }

	}
}
