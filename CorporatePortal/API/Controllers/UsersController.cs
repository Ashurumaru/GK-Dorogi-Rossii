using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CorporatePortalContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(CorporatePortalContext context)
        {
            _context = context;
        }
        // POST: api/Users/Authorize
        [HttpPost("Authorize")]
        public async Task<ActionResult<User>> AuthorizeUser(LoginDto loginRequest)
        {
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(u => u.username == loginRequest.Username);

            if (userAccount == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, userAccount.passwordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.idUser == userAccount.idUser);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Select(e => new UserDto
                {
                    IdUser = e.idUser,
                    FirstName = e.firstName,
                    SecondName = e.secondName,
                    Patronymic = e.patronymic,
                    WorkNumber = e.workNumber,
                    BirthDay = e.birthDay,
                    DepartmentName = e.Department.nameDepartment,
                    IdSwapper = e.idSwapper,
                    Email = e.Email,
                    HomeNumber = e.homeNumber,
                    IdDepartment = e.idDepartment,
                    IdPosition = e.idPosition,
                    PhotoPath = e.photoPath,
                    PositionName = e.Position.namePosition,
                })
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserFromId(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.idUser)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.idUser }, user);
        }

        // DELETE: api/Users/5
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
            return _context.Users.Any(e => e.idUser == id);
        }
    }
}
