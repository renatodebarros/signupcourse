using System;

namespace CourseSignUp.Course.Service.ViewModel
{
	public class EnrollmentVM
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDayDate { get; set; }
		public int CourseId { get; set; }
	}
}
