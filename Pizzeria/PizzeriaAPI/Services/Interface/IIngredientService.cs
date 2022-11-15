using PizzeriaShared.Models;

namespace PizzeriaAPI.Services.Interface
{
    public interface IIngredientService
    {
        public Task<Ingredient?> CreateIngredient(string name);
        public Task<Ingredient?> GetIngredientById(int Id);
        public Task<Ingredient> GetIngredientByName(string name); 
        public Task<Ingredient> DeleteIngredient(int Id);
    }
}
