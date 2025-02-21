using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackDemo.Server.Models;

namespace FullStackDemo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        //create user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        //get users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
