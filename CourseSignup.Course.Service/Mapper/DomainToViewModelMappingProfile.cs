using AutoMapper;
using CourseSignUp.Course.Service.ViewModel;
using CourseSignUp.Domain.Course.Contracts.Models;
using System.Collections.Generic;

namespace CourseSignUp.Course.Service.Mapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			CreateMap<CourseModel, CourseVM>();
			CreateMap<IEnumerable<CourseModel>, List<CourseVM>>();
			CreateMap<LecturerModel, LecturerVM>();
			CreateMap<IEnumerable<LecturerModel>, List<LecturerVM>>();
			CreateMap<IEnumerable<EnrollmentModel>, List<EnrollmentVM>>();
		}
	}
}