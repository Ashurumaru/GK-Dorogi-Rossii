﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Identity.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Scripting;

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
            // Получаем учетную запись пользователя по имени пользователя
            var userAccount = await _context.UserAccount
                .FirstOrDefaultAsync(u => u.username == loginRequest.Username);

            if (userAccount == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Проверяем пароль
            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, userAccount.passwordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Получаем пользователя по id
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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || users.Count == 0)
                return NotFound();
            return users;
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
