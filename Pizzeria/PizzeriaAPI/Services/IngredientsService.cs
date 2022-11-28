using Microsoft.EntityFrameworkCore;
using PizzeriaAPI.Data;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;

namespace PizzeriaAPI.Services
{
    public class IngredientsService : IIngredientService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IngredientsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<List<Ingredient>> GetIngredients()
        {
            var ingredients = await _applicationDbContext.Ingredients!.ToListAsync();
            return ingredients;
        }
        public async Task<Ingredient?> CreateIngredient(string name)
        {
            // string.IsNullOrEmpty
            if(string.IsNullOrWhiteSpace(name))
            {
                return null!;
            }

            try
            {
                var ingredientToBeAdded = new Ingredient
                {
                    Name = name,
                };

                _ = await _applicationDbContext.Ingredients!.AddAsync(ingredientToBeAdded);
                _ = await _applicationDbContext.SaveChangesAsync();

                return ingredientToBeAdded;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }


        }
        public async Task<Ingredient?> GetIngredientById(int Id)
        {
            if (Id <=0)
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Ingredients!.FirstOrDefaultAsync(ingredient => ingredient.Id.Equals(Id));
                
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

            public async Task<Ingredient> GetIngredientByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Ingredients!.FirstOrDefaultAsync(ingredient => ingredient.Name!.Equals(name));

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
        public async Task<Ingredient> DeleteIngredient(int Id)
        {
            if (Id <= 0)
            {
                return null!;
            }

            try
            {
                var dbResult = await _applicationDbContext.Ingredients!.FirstOrDefaultAsync(ingredient => ingredient.Id.Equals(Id));

                if (dbResult == null)
                {
                    return dbResult!;
                }

                _ = _applicationDbContext.Ingredients!.Remove(dbResult);
                _ = await _applicationDbContext.SaveChangesAsync();

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
