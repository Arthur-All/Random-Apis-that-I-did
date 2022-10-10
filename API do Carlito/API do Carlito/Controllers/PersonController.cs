using API_do_Carlito.Interface;
using API_do_Carlito.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_do_Carlito.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonServices _personService;
        private readonly ILogger _logger;
        public PersonController(IPersonServices personService)
        {
            _personService = personService;
            


        }


        [HttpGet]
        public async Task <ActionResult<List<Person>>> FindAllPerson()
        {
            try {

               var pess = await _personService.FindAllPerson();

               return Ok(pess );
            } 
            catch(Exception ex) {

                return BadRequest(ex);
            }
            
        }

        /*[HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var person = _personService.FindById(Id);
            if (person == null)
            {
                return NotFound("Person not foud");
            }
            return Ok(person);
        }*/
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person.Email == null)
            {
                return BadRequest("Need a email");
            }
            return Ok(_personService.CreatePerson(person));
        }
        [HttpPut]
        public async Task< IActionResult> UpdatePerson([FromBody] Person personModel)
        {
            try
            {
                var edit = await _personService.UpdatePerson( personModel);
                return Ok(edit);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message); //Perguntar se statusCode não é muito generico
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _personService.DeletePerson(Id);
            return NoContent();
        }
    }
}
