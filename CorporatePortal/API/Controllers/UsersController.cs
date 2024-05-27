using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CorporatePortalContext _context;

        public UsersController(CorporatePortalContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Пользователи.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Пользователи.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ПользовательID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
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

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user.РольID != 0 && !_context.Роли.Any(r => r.РольID == user.РольID))
            {
                return BadRequest("Invalid RoleID");
            }

            if (user.ПодразделениеID != null && user.ПодразделениеID != 0 && !_context.Подразделения.Any(d => d.ПодразделениеID == user.ПодразделениеID))
            {
                return BadRequest("Invalid ПодразделениеID");
            }

            if (user.РуководительID != null && user.РуководительID != 0 && !_context.Пользователи.Any(u => u.ПользовательID == user.РуководительID))
            {
                return BadRequest("Invalid РуководительID");
            }

            if (user.ЗаменяющийID != null && user.ЗаменяющийID != 0 && !_context.Пользователи.Any(u => u.ПользовательID == user.ЗаменяющийID))
            {
                return BadRequest("Invalid ЗаменяющийID");
            }

            _context.Пользователи.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ПользовательID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Пользователи.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Пользователи.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Пользователи.Any(e => e.ПользовательID == id);
        }
    }
}
