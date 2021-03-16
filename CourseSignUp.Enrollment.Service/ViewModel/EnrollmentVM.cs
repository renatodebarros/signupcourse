using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Course.Service.ViewModel
{
	public class EnrollmentVM
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDayDate { get; set; }

		public bool accepted { get; set; }

		public int courseId { get; set; }

		public string Message { get; set; }


	}
}
