using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;
using System.Xml.Linq;

namespace PizzeriaAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{


    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient(string name)
    {
        var serviceResponse = await _ingredientService.CreateIngredient(name);

        if (serviceResponse == null)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(serviceResponse);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredientById(int id)
    {
        var serviceResponse = await _ingredientService.GetIngredientById(id);

        if (serviceResponse == null)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(serviceResponse);
    }

    [HttpGet("[action]/{name}")]
    public async Task<ActionResult<Ingredient>> GetIngredientByName(string name)
    {
        var serviceResponse = await _ingredientService.GetIngredientByName(name);

        if (serviceResponse == null)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(serviceResponse);
    }

    [HttpDelete]
    public async Task<ActionResult<Ingredient>> DeleteIngredient(int id)
    {
        var serviceResponse = await _ingredientService.DeleteIngredient(id);

        if (serviceResponse == null)
        {
            return BadRequest("Something went wrong");
        }
        return Ok(serviceResponse);
    }

}
