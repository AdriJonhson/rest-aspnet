using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithAspNET.Business;
using RestWithAspNET.Models;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        private readonly IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(_bookBusiness.FindAll());
        }   
        
        [HttpGet("{id}")]
        public IActionResult FindById(long id)
        {
            Book book = _bookBusiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Book book)
        {
            if (book == null) return BadRequest();

            book.Id = id;
            book = _bookBusiness.Update(book);
            
            if (book == null) return NotFound();
            
            return Ok(book);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        { 
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
