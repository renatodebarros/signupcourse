using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CourseSignUp.Course.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			// The `UseServiceProviderFactory(new AutofacServiceProviderFactory())` call here allows for
			// ConfigureContainer to be supported in Startup with
			// a strongly-typed ContainerBuilder. If you don't
			// have the call to AddAutofac here, you won't get
			// ConfigureContainer support. This also automatically
			// calls Populate to put services you register during
			// ConfigureServices into Autofac.
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
				.UseServiceProviderFactory(new AutofacServiceProviderFactory())
				.ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });
	}
}
