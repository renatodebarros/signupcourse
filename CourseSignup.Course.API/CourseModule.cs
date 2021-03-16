using Autofac;
using AutoMapper;
using CourseSignup.Course.Domain.Commands.Course;
using CourseSignup.infra.Enrollment.Data;
using CourseSignUp.Course.Service;
using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.Mapper;
using CourseSignUp.Domain.Contracts.Repository;
using CourseSignUp.Infra.Data.Course;
using lecturersignUp.Infra.Data.Lecturer;
using MediatR;
using MediatR.Pipeline;
using StudentSignup.Infra.Enrollment.Data;
using System.Collections.Generic;
using System.Reflection;

namespace CourseSignup.Course.API
{
	public class CourseModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
            builder.RegisterType<ViewModelToDomainMappingProfile>().As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();


            builder.RegisterType<DomainToViewModelMappingProfile>().As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterType<CourseRepository>().As<ICourseRepository>()
           .InstancePerLifetimeScope();

            builder.RegisterType<LeacturerRepository>().As<ILecturerRepository>()
            .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
            .InstancePerLifetimeScope();

            builder.RegisterType<EnrollmentRepository>().As<IEnrollmentRepository>()
            .InstancePerLifetimeScope();


            builder.RegisterType<CourseService>()
                .As<ICourseService>()
                .InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
           {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(CourseCreateCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    // when having a single class implementing several handler types
                    // this call will cause a handler to be called twice
                    // in general you should try to avoid having a class implementing for instance `IRequestHandler<,>` and `INotificationHandler<>`
                    // the other option would be to remove this call
                    // see also https://github.com/jbogard/MediatR/issues/462
                    .AsImplementedInterfaces();
            }

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

        }
    }
}
