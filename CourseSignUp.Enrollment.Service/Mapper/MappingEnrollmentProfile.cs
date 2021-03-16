using AutoMapper;
using CourseSignup.Domain.Enrollment.Contracts.Models;
using CourseSignUp.Enrollment.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Enrollment.Service.Mapper
{
	public class MappingEnrollmentProfile : Profile
	{
		public MappingEnrollmentProfile()
		{
			CreateMap<EnrollmentVM, StudentModel>();
			CreateMap<EnrollmentVM, EnrollmentModel>();

		}
	}
}
