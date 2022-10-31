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

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        private readonly ILogger<ChaptersController> _logger;

        public ChaptersController(UniversityDBContext context, ILogger<ChaptersController> logger)
        {
            _context = context;
            _logger = logger;
        }



        // GET: api/Chapters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChapters()
        {

            try
            {
                return await _context.Chapters.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetChapters)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetChapters)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetChapters)} - Critical Level Log");

                return Problem(ex.ToString());
            }
        }

        // GET: api/Chapters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chapter>> GetChapter(int id)
        {
             
            try
            {
                var chapter = await _context.Chapters.FindAsync(id);

                if (chapter == null)
                {
                    return NotFound();
                }

                return chapter;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetChapter)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetChapter)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetChapter)} - Critical Level Log");

                return Problem(ex.ToString());
            }
        }

        // PUT: api/Chapters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter(int id, Chapter chapter)
        {
            try {

            if (id != chapter.Id)
            {
                return BadRequest();
            }

            _context.Entry(chapter).State = EntityState.Modified;
            
          
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ChapterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(PutChapter)} - Warning Level Log");
                    _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(PutChapter)} - Error Level Log");
                    _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PutChapter)} - Critical Level Log");
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Chapters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chapter>> PostChapter(Chapter chapter)
        {

            try
            {
                _context.Chapters.Add(chapter);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetChapter", new { id = chapter.Id }, chapter);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(PostChapter)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(PostChapter)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PostChapter)} - Critical Level Log");

                return Problem(ex.ToString());

            }            
        }

        // DELETE: api/Chapters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {


            try
            {

                var chapter = await _context.Chapters.FindAsync(id);
                if (chapter == null)
                {
                    return NotFound();
                }

                _context.Chapters.Remove(chapter);
                await _context.SaveChangesAsync();

                return NoContent();


            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(DeleteChapter)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(DeleteChapter)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(DeleteChapter)} - Critical Level Log");

                return Problem(ex.ToString());

            }            
        }

        private bool ChapterExists(int id)
        {
            try
            {

                return _context.Chapters.Any(e => e.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(ChapterExists)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(ChapterExists)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(ChapterExists)} - Critical Level Log");
                throw;

            }            
        }
    }
}
