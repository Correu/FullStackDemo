using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullStackDemo.Server.Models;

namespace FullStackDemo.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RealEstateController : Controller
    {
        private readonly RealEstateContext _context;

        public RealEstateController(RealEstateContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddRealEstate([FromBody] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realEstate);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetRealEstate()
        {
            var realEstate = await _context.RealEstate.ToListAsync();
            return Ok(realEstate);
        }
    }
}
