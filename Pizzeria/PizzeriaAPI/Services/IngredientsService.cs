using PizzeriaAPI.Data;
using PizzeriaAPI.Services.Interface;
using PizzeriaShared.Models;

namespace PizzeriaAPI.Services
{
    public class IngredientsService : IIngredientService
    {
        private ApplicationDbContext _applicationDbContext;

        public IngredientsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Ingredient> CreateIngredient(string name)
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
        public Task<Ingredient> GetIngredientById(int Id)
        {
            throw new NotImplementedException();
        }
        public Task<Ingredient> GetIngredientByName(string name)
        {
             throw new NotImplementedException();
        }
        public Task<Ingredient> DeleteIngredient(int Id)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
