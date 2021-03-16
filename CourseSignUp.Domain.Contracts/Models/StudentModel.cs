using System;

namespace CourseSignUp.Domain.Course.Contracts.Models
{
	public class StudentModel : BaseModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDayDate { get; set; }
	}
}
