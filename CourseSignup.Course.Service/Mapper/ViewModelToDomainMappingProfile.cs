using AutoMapper;
using CourseSignUp.Course.Service.ViewModel;
using CourseSignUp.Domain.Course.Contracts.Models;

namespace CourseSignUp.Course.Service.Mapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<CourseVM, CourseModel>();
			CreateMap<CourseModel, CourseVM>();
			CreateMap<LecturerVM, LecturerModel>();
			CreateMap<LecturerModel, LecturerVM>();
			CreateMap<EnrollmentVM, StudentModel>();
			CreateMap<EnrollmentVM, EnrollmentModel>();
			CreateMap<EnrollmentModel, EnrollmentVM>();
		}
	}
}