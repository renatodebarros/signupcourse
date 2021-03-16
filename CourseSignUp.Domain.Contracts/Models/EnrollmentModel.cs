using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Course.Contracts.Models
{
	public class EnrollmentModel : BaseModel
	{
		public int StudentyId { get; set; }

		public int CourseId { get; set; }

		public DateTime EnrollmentedAt { get; set; }

		public bool Enrollmented { get; set; }

	}
}
