using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Course.Service.ViewModel
{
	public class CourseVM
	{
		public int Id { get; set; }
		public string CourseName { get; set; }
		public bool Enabled { get; set; }
		public int MaxEnrollments { get; set; }
		public int Enrollmenteds { get; set; }
		public string Message { get; set; }

		}
}
