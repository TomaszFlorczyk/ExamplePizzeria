using PizzeriaShared.Models;

namespace PizzeriaAPI.Services.Interface
{
    public interface IPizzaService
    {
        public Task<Pizza> CreatePizza(string name, List<string> ingredientsNames);
        public Task<List<Pizza>> GetPizzas();
        public Task<Pizza> GetPizzaById(int Id);
        public Task<Pizza> GetPizzaByName(string name);
        public Task<Pizza> GetPizzaPrice(int Id);
        public Task<Pizza> DeletePizza(int Id);
    }
}
