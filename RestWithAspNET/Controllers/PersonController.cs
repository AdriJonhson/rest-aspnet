using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Business;
using RestWithAspNET.Models;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personBusiness.FindAll());
        }   
        
        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Person person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Person person)
        {
            if (person == null) return BadRequest();

            person.Id = id;
            person = _personBusiness.Update(person);
            
            if (person == null) return NotFound();
            
            return Ok(person);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        { 
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
