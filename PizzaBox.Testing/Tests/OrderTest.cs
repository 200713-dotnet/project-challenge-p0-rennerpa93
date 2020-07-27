using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class OrderTest
  {
    [Fact]
    public void Test_CalculatePrice()
    {
      Order order = new Order();
      Pizza p = new Pizza("Cheese Pizza", new Size("Small", 5.00), new Crust("Normal", 0), new List<Topping>{new Topping("Cheese", 0.25)});
      Assert.Equal(5.25, p.GetPrice());
      order.Pizzas.Add(p);
      Assert.Equal(5.25, order.CalculatePrice());
      order.Pizzas.Add(p);
      Assert.Equal(10.50, order.CalculatePrice());
    }
  }
}