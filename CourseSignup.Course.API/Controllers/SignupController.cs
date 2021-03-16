using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseSignup.Course.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SignupController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public SignupController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		// GET: api/<SignupController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<SignupController>/5
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _courseService.GetEnrollments();
			return Ok(result);
		}

		// POST api/<SignupController>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EnrollmentVM value)
		{
			var result = await _courseService.Signup(value);

			return Ok(result);

		}

		// PUT api/<SignupController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<SignupController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
