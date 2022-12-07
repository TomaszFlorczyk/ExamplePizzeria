using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Services;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;

namespace PizzeriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpPost]
        public async Task<ActionResult<Pizza>> CreatePizza(string name, List<string> ingredientName)
        {
            var serviceResponse = await _pizzaService.CreatePizza(name, ingredientName);

            if (serviceResponse == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<List<Pizza>>> GetPizzas()
        {
            return await _pizzaService.GetPizzas();
        }

        [HttpGet("[action]/{name}")]
        public async Task<ActionResult<Pizza>> GetPizzaByName(string name)
        {
            var serviceResponse = await _pizzaService.GetPizzaByName(name);

            if (serviceResponse == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(serviceResponse);
        }



        [HttpDelete]
        public async Task<ActionResult<Pizza>> DeletePizza(int id)
        {
            var serviceResponse = await _pizzaService.DeletePizza(id);

            if (serviceResponse == null)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(serviceResponse);

        }
    }
    
}
