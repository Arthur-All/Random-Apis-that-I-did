using API_DO_PAIZAO.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API_DO_PAIZAO.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonService _personService;
        private readonly ILogger<PersonController> _logger;
        
        public PersonController(ILogger<PersonController>logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var person = _personService.FindById(Id);
            {
                if(person == null) return NotFound();
                
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Person person)
        {
            
            if (person == null) return BadRequest();
            
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Models.Person person)
        {
            
            if (person == null) return BadRequest();
            
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
           _personService.Delete(Id);

            return NoContent();
        }



    }
}

