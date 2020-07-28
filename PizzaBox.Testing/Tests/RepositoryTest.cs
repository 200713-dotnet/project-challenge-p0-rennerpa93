using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class RepositoryTest
  {
    [Fact]
    public void CreatePizzaTest()
    {
      var repo = new PizzaBoxRepository();
      Pizza p = new Pizza("Cheese Pizza", new Size("Small", 5.00), new Crust("Normal Crust", 0), new List<Topping>{new Topping("Cheese", 0.25), new Topping("Pepperoni", 0.25)});
      repo.CreatePizza(p, 1);
    }

    [Fact]
    public void CreateOrderTest()
    {
      var repo = new PizzaBoxRepository();
      Order o = new Order();
      Pizza p = new Pizza("Cheese Pizza", new Size("Small", 5.00), new Crust("Normal Crust", 0), new List<Topping>{new Topping("Cheese", 0.25), new Topping("Pepperoni", 0.25)});
      o.Pizzas.Add(p);
      repo.CreateOrder(o, 1, 1);
    }
  }
}