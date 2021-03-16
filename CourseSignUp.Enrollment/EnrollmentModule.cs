using Autofac;
using CourseSignUp.Course.Service;
using CourseSignUp.Course.Domain.Handlers;
using CourseSignUp.Course.Service;
using MediatR;
using StudentSignup.Infra.Enrollment.Data;
using System.Reflection;

namespace StudentSignUp.Enrollment.API
{
	public class EnrollmentModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(StudentRepository).GetTypeInfo().Assembly).AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(typeof(EnrollmentService).GetTypeInfo().Assembly).AsImplementedInterfaces();
			builder.RegisterAssemblyTypes(typeof(CourseService).GetTypeInfo().Assembly).AsImplementedInterfaces();


			builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
						   .AsImplementedInterfaces();

			//Register alls command handlers
			builder.RegisterAssemblyTypes(typeof(StudentCreateCommandHandler).GetTypeInfo().Assembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>));

			builder.RegisterAssemblyTypes(typeof(EnrollmentAddHandler).GetTypeInfo().Assembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>));

			builder.Register<ServiceFactory>(context =>
			{
				var componentContext = context.Resolve<IComponentContext>();
				return t =>
				{
					object o;
					return componentContext.TryResolve(t, out o) ? o : null;
				};
			});
		}
	}
}
