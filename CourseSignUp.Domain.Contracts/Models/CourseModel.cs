using System;

namespace CourseSignUp.Domain.Course.Contracts.Models
{
	public class CourseModel : BaseModel
	{
		public string CourseName { get; set; }
		public int MaxEnrollments { get; set; }
		public int Enrollmenteds { get; set; }

	}
}
