using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;

namespace PizzeriaAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IIngredientService _ingredientService;

        public PizzaService(ApplicationDbContext applicationDbContext, IIngredientService ingredientService)
        {
            _applicationDbContext = applicationDbContext;
            _ingredientService = ingredientService;
        }

        public async Task<Pizza> CreatePizza(string name, List<string> ingredientsNames)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null!;
            }

            try
            {
                var ingredients = new List<Ingredient>();

                foreach(var ingredientName in ingredientsNames)
                {
                    var ingredientFromDataBase = await _ingredientService.GetIngredientByName(ingredientName);

                    if(string.IsNullOrWhiteSpace(ingredientName))
                    {
                        return null!;
                    }
                    
                    if(ingredientFromDataBase != null)
                    { 
                        ingredients.Add(ingredientFromDataBase);
                    }


                }

                var pizzaToBeAdded = new Pizza
                {
                    Name = name,
                    Ingredients = ingredients
                };

                _ = await _applicationDbContext.Pizzas!.AddAsync(pizzaToBeAdded);
                _ = await _applicationDbContext.SaveChangesAsync();

                return pizzaToBeAdded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Pizza>> GetPizzas()
        {
            var pizzas = await _applicationDbContext.Pizzas!.ToListAsync();
            return pizzas;
        }

        public async Task<Pizza> DeletePizza(int Id)
        {
            if (Id <= 0)
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id.Equals(Id));

                if (dbResult == null)
                {
                    return dbResult!;
                }

                _ = _applicationDbContext.Pizzas!.Remove(dbResult);
                _ = await _applicationDbContext.SaveChangesAsync();

                return dbResult;
            }
            catch (Exception e)
            {

                Console.Write(e);

                return null!;
            }
        }

        public async Task<Pizza> GetPizzaById(int Id)
        {
            if (Id <= 0)
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Pizzas!.FirstOrDefaultAsync(pizza => pizza.Id.Equals(Id));

                if (dbResult == null)
                {
                    return dbResult!;
                }
                return dbResult;
            }
            catch (Exception e)
            {

                Console.Write(e);

                return null!;
            }

        }

        public async Task<Pizza> GetPizzaByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Pizzas!.FirstOrDefaultAsync(pizza => pizza.Name!.Equals(name));

                if (dbResult == null)
                {
                    return dbResult!;
                }
                return dbResult;
            }
            catch (Exception e)
            {

                Console.Write(e);

                return null!;
            }

        }
        public async Task<Pizza> GetPizzaPrice(int Id)
        {
            if (Id <= 0)
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Pizzas!.FirstOrDefaultAsync(pizza => pizza.Price.Equals(Id));

                if (dbResult == null)
                {
                    return dbResult!;
                }
                return dbResult;
            }
            catch (Exception e)
            {

                Console.Write(e);

                return null!;
            }
        }
    }
}
