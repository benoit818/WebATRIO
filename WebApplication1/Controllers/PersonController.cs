using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net;

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
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Person> Get(int id)
        {
            var person = _context.person.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
        // on peut configurer les routes...
        [HttpGet("people/{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Save([FromBody]  Person person)
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
