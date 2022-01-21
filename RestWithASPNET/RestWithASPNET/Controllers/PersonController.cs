using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiRest.Model;
using ApiRest.Services;

namespace ApiRest.Controllers
{
   
    [ApiVersion("1")] //Versão do controle
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")] //string de acc 
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        
        [HttpGet]
        public IActionResult Get() //FindAll
        {
            return Ok(_personService.FindAll());
        }

        
        [HttpGet("{id}")] 
        public IActionResult Get(long id) //FINDBYID
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }
      
        [HttpPost]
        public IActionResult Post([FromBody] Person person) //Post
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person) // [FromBody] Coisa o Json 
        {
            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(long id) //Delete
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
