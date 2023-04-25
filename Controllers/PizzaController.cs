using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBayServer.Services;
using PizzaLogic.DataModels;
using PizzaLogic.Models;

namespace PizzaBayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IService service;

        public PizzaController(IService service)
        {
            this.service = service;
        }

        //Piza
        [HttpPost]
        public async Task<ActionResult<Response>> AddPizza(Pizza model)
        {
            if (model != null)
                return Ok(await service.AddPizza(model));
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<Pizza>>> GetPizzas()
        {
            var pizzas = await service.GetPizzas();
            if (pizzas != null)
                return Ok(pizzas);
            return BadRequest(new Response { Success = false, Message = "No data found" });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            if (id > 0)
            {
                return Ok(await service.GetPizza(id));
            }
            return BadRequest("Sorry Error occured");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Response>> DeletePizza(int id)
        {
            if (id > 0)
            {
                return Ok(await service.DeletePizza(id));
            }
            return BadRequest("Sorry Error occured");
        }
    }
}
