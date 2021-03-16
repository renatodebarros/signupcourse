using CourseSignUp.Course.Service.Interfaces;
using CourseSignUp.Course.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseSignup.Course.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CourseController : ControllerBase
	{

		private readonly ICourseService _courseService;

		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}


		// GET: api/<CourseController>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _courseService.GetCourses();
			return Ok(result);
		}

		// GET api/<CourseController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _courseService.GetCourse(id);
			if (result != null)
			{
				return Ok(result);
			}
			else
			{
				return NoContent();
			}
		}

		[HttpGet("{term}")]
		
		public async Task<IActionResult> Search(string term)
		{
			var result = await _courseService.GetCourse(term);
			return Ok(result);
		}

		// POST api/<CourseController>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CourseVM value)
		{
			var result = await _courseService.Add(value);

			return Ok(result);
		}

		[HttpPut]
		public async Task<IActionResult> Update( [FromBody] CourseVM value)
		{
			var result = await _courseService.Update(value);

			return Ok(result);
		}

	
	}
}
