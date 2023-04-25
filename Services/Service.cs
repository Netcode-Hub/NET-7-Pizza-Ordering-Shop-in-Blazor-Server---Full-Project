using Microsoft.EntityFrameworkCore;
using PizzaLogic.DataModels;
using PizzaLogic.Models;
using Server.Data;

namespace PizzaBayServer.Services
{
    public class Service : IService
    {
        private readonly AppDbContext appDbContext;

        public Service(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //pizza
        public async Task<Response> AddPizza(Pizza model)
        {
            if (model != null)
            {
                if (model.Id > 0)
                {
                    var result = await GetPizza(model.Id);
                    if (result != null)
                    {
                        result.Name = model.Name;
                        result.Description = model.Description;
                        result.SmallPrice = model.SmallPrice;
                        result.MediumPrice = model.MediumPrice;
                        result.LargePrice = model.LargePrice;
                        result.ExtraLargePrice = model.ExtraLargePrice;
                        result.Image = model.Image;
                        await appDbContext.SaveChangesAsync();
                        return new Response { Success = true, Message = $"{model.Name} updated successfully" };
                    }
                    return new Response { Success = false, Message = $"Error occured, {model.Name} not found" };
                }
                else
                {
                    var checkEx = await appDbContext.Pizzas.Where(i => i.Name!.ToLower().Equals(model.Name!.ToLower()))
                    .FirstOrDefaultAsync();
                    if (checkEx == null)
                    {
                        appDbContext.Pizzas.Add(model); await appDbContext.SaveChangesAsync();
                        return new Response();
                    }
                    return new Response { Success = false, Message = "Already added" };
                }
            }
            return new Response { Success = false, Message = "All fields required" };

        }

        public async Task<List<Pizza>> GetPizzas()
        {
            return await appDbContext.Pizzas.ToListAsync();
        }

        public async Task<Pizza> GetPizza(int id)
        {
            var result = await appDbContext.Pizzas.FirstOrDefaultAsync(i => i.Id == id);
            return result!;
        }
        public async Task<Response> DeletePizza(int id)
        {
            var result = await GetPizza(id);
            if (result != null)
            {
                appDbContext.Pizzas.Remove(result); await appDbContext.SaveChangesAsync();
                return new Response { Success = true, Message = $"{result.Name} deleted successfully" };
            }
            return new Response { Success = false, Message = "Error occured! Pizza not found" };
        }
    }
}
