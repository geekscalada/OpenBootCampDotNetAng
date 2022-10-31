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
    [Route("api/[controller]")] // Controller for Requests to https://localhost:7190/api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        private readonly ILogger _logger;

        public UsersController(UniversityDBContext context, ILogger loger)
        {
            _context = context;
            _logger = loger;
        }

        // GET: https://localhost:7190/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            
            try
            {

                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetUsers)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetUsers)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetUsers)} - Critical Level Log");

                return Problem(ex.ToString());

            }


        }

        // GET: https://localhost:7190/api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            try
            {
                var user = await _context.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(GetUser)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(GetUser)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(GetUser)} - Critical Level Log");

                return Problem(ex.ToString());

            }            
        }

        // PUT: https://localhost:7190/api/users/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {

            try
            {

                if (id != user.Id)
            {
                return BadRequest();
            }

                _context.Entry(user).State = EntityState.Modified;
            
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(PutUser)} - Warning Level Log");
                    _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(PutUser)} - Error Level Log");
                    _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PutUser)} - Critical Level Log");
                    throw;
                }
            }
            return NoContent();
        }

        // POST: https://localhost:7190/api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(PostUser)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(PostUser)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(PostUser)} - Critical Level Log");

                return Problem(ex.ToString());
            }

            
        }

        // DELETE: https://localhost:7190/api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(DeleteUser)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(DeleteUser)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(DeleteUser)} - Critical Level Log");

                return Problem(ex.ToString());
            }
        }

        private bool UserExists(int id)
        {
            try
            {
                return _context.Users.Any(user => user.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, $"{nameof(StudentsController)} - {nameof(UserExists)} - Warning Level Log");
                _logger.LogError(ex, $"{nameof(StudentsController)} - {nameof(UserExists)} - Error Level Log");
                _logger.LogCritical(ex, $"{nameof(StudentsController)} - {nameof(UserExists)} - Critical Level Log");

                throw;
            }            
        }
    }
}
