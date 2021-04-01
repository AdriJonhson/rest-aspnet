﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Models;
using RestWithAspNET.Services.Implemetations;

namespace RestWithASPNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_personService.FindAll());
        }   
        
        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Person person = _personService.FindById(id);

            if (person == null) return NotFound("Person Not Found!");

            return Ok(person);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Person person)
        {
            if (person == null) return BadRequest();
            person.Id = id;
            return Ok(_personService.Create(person));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        { 
            _personService.Delete(id);
            return NoContent();
        }
    }
}