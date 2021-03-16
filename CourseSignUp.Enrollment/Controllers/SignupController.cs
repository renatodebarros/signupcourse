using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseSignUp.Course.API.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class SignupController : ControllerBase
	{
		private readonly IEnrollmentService _enrollmentService;

		public SignupController(IEnrollmentService enrollmentService)
		{
			_enrollmentService = enrollmentService;
		}


		[HttpGet]
		public async Task<IActionResult> Get()
		{

			return NoContent();
		}


		// POST: SignupController/Create
		[HttpPost]

		public async Task<IActionResult> Create([FromBody] EnrollmentVM enrollment)
		{
			var resultSet = await _enrollmentService.Signup(enrollment).ConfigureAwait(false);

			return Ok(resultSet);
		}

	}
}
