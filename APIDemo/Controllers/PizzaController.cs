using APIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIDemo.Services;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
          PizzaServices.GetAll();


        [HttpGet("{id}")]


        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaServices.Get(id);

            if (pizza == null)
                return NotFound();



            return pizza;
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaServices.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
            // This code will save the pizza and return a result
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
           if(id!=pizza.Id)
                return BadRequest();
           var existingpizza=PizzaServices.Get(id);
            if (existingpizza is null)
                return NotFound();

            PizzaServices.Update(pizza);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaServices.Get(id);
            if (pizza is null)
                return NotFound();

            PizzaServices.Delete(id);
            return NoContent();
            // This code will delete the pizza and return a result
        }
    }
}
