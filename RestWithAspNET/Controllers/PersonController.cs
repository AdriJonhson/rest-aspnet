using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Business;
using RestWithAspNET.Data.VO;
using RestWithAspNET.Hypermedia.Filters;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(200, Type = typeof(List<PersonVO>))]
        public IActionResult FindAll()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("filter")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(200, Type = typeof(List<PersonVO>))]
        public IActionResult FindByName([FromQuery] string firstName, [FromQuery] string lastName)
        {
            return Ok(_personBusiness.FindByName(firstName, lastName));
        }
        
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType(200, Type = typeof(List<PersonVO>))]
        public IActionResult FindAllPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(_personBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult FindById(long id)
        {
            PersonVO person = _personBusiness.FindById(id);

            if (person == null) return NotFound();

            return Ok(person);
        }
        
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Create([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));
        }
        
        [HttpPut("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Update(long id, [FromBody] PersonVO person)
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
        
        [HttpPatch("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Disable(long id)
        {
            PersonVO person = _personBusiness.Disable(id);

            if (person == null) return NotFound();

            return Ok(person);
        }
    }
}
