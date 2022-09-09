using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

//using ContosoPizza.Data;
//using ContosoPizza.Data;

namespace MVCDemo.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDemo.Models.Pizza> Pizzas { get; set; } = default;
       // public DbSet<Topping> Toppings => Set<Topping>();
        //public DbSet<Sauce> Sauces => Set<Sauce>();
    }
}
