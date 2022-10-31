#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        // Service
        private readonly IStudentsService _studentsService;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(UniversityDBContext context, IStudentsService studentsService, ILogger<StudentsController> logger)
        {
            _context = context;
            _studentsService = studentsService;
            _logger = logger;
        }



        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                return await _context.Students.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetStudents)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetStudents)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetStudents)} - Critical Level Log");

                return Problem(ex.ToString());
            }
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {

            try
            {

                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                return student;

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetStudent)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetStudent)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetStudent)} - Critical Level Log");

                return Problem(ex.ToString());

            }
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            try
            {

                if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(PutStudent)} - Warning Level Log");
                    _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(PutStudent)} - Error Level Log");
                    _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PutStudent)} - Critical Level Log");

                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            
            try
            {


                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                
                return CreatedAtAction("GetStudent", new { id = student.Id }, student);

            }
            catch (Exception ex)
            {
                _logger.LogWarning( ex, $"{nameof(StudentsController)} - {nameof(PostStudent)} - Warning Level Log");
                _logger.LogError( ex, $"{nameof(StudentsController)} - {nameof(PostStudent)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PostStudent)} - Critical Level Log");

                return Problem(ex.ToString());

            }
           

            
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            try
            {


                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(DeleteStudent)} - Critical Level Log");

                return Problem(ex.ToString());

            }
        }

        private bool StudentExists(int id)
        {
            try
            {
                _logger.LogWarning($"{nameof(StudentsController)} - {nameof(GetStudents)} - Warning Level Log");
                _logger.LogError($"{nameof(StudentsController)} - {nameof(GetStudents)} - Error Level Log");
                _logger.LogCritical($"{nameof(StudentsController)} - {nameof(GetStudents)} - Critical Level Log");

                return _context.Students.Any(e => e.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(StudentExists)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(StudentExists)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(StudentExists)} - Critical Level Log");

                return false;
            }
        }
    }
}
