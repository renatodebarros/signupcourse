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
	public class LecturerController : ControllerBase
	{
		private readonly ICourseService _courseService;

		public LecturerController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _courseService.GetLecturers();
			return Ok(result);
		}

		[HttpGet("{term}")]

		public async Task<IActionResult> Search(string term)
		{
			var result = await _courseService.GetLecturer(term);
			return Ok(result);
		}

		// POST api/<CourseController>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] LecturerVM value)
		{
			var result = await _courseService.Add(value);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] LecturerVM value)
		{
			var result = await _courseService.Update(value);

			return Ok(result);
		}
	}
}
