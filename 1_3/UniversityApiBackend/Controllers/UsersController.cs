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

        // Inicializamos el contexto

        // Este context tiene acceso a todos los DBSets que existan
        private readonly UniversityDBContext _context;

        public UsersController(UniversityDBContext context)
        {
            _context = context;
            
        }

        // Inicializamos el contexto. 


        // GET: https://localhost:7190/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: https://localhost:7190/api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                // Respuesta 404 preestrablecida de .net es un actionresult
                return NotFound();
            }

            return user;
        }

        // PUT: https://localhost:7190/api/users/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            // Si no coincide el ID de la petición con el ID del body de la petición
            if (id != user.Id)
            {
                // 400
                return BadRequest();
            }

            // Aquí es donde se modifican los datos de la entidad. 
            // Además se le genera estado modificado. 
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            // caso de un error de concurrencia, por ejempplo dos usuarios intentando
            // actualizar algo a al vez
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Si todo es correcto, devolvemos solo un 204 sin contenido
            return NoContent();
        }

        // POST: https://localhost:7190/api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // tipo predeterminado 201 que además llama al método getUser de manera interna
            // pasándote por pa
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: https://localhost:7190/api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
    }
}
