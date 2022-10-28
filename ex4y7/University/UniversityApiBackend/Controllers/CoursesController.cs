using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService, UniversityDBContext context)
        {
            _coursesService = coursesService;
            _context = context;
        }


        [HttpGet("{category}")]

        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCategory(string category)
        {

            var listCourses = _coursesService.GetCourseByCategory(category).ToList();

            return listCourses;

        }

        [HttpGet("courseswitnochapter")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithNoChapter()
        {
            var listCoursesWithNoChapter = _coursesService.GetCoursesWithNoChapter().ToList();

            return listCoursesWithNoChapter;
        }

        [HttpGet("studentsbycourse")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByCourse(string nameCourse)
        {
            var listStudentsByCourse = _coursesService.GetStudentsByCourse(nameCourse).ToList();

            return listStudentsByCourse;

        }


        [HttpGet("getchapterbycourse")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapterByCourse(string nameCourse)
        {
            return _coursesService.GetChapterByCourse(nameCourse).ToList();
        }

        [HttpGet("getcoursebycatandlevel")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCatAndLevel(string categoryName, Level level)
        {
            var listCourses = _coursesService.GetCoursesByCatAndLevel(categoryName, level);

            return Ok(listCourses);
        }




    }
}
