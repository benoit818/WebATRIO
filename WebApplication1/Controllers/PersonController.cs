using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PeopleDbContext _context;
        public PersonController(PeopleDbContext dbContext)
        {
            // injection de dependance;
            _context = dbContext;
        }
        [HttpGet("people/{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _context.person.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
        // on peut configurer les routes...
        [HttpGet("people/{id}")]
        public async Task<IActionResult> GetAll()
        {
            var person = await _context.person.OrderBy(x => x).ToListAsync(); ;

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost("people/Save")]
        public IActionResult Save(Person person)
        {
            if (person.Naissance > new DateTime(1871, 3, 1, 7, 0, 0))
            {
                _context.Add(person);
                _context.SaveChanges();
                return Accepted();
            }
            else
            {
                return BadRequest(); 
            }
        }
    }
}
