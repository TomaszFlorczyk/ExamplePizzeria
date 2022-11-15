using Microsoft.AspNetCore.Mvc;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;

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
}
