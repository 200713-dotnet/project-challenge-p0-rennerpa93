using System.Collections.Generic;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class PizzaTest
  {
    [Fact]
    public void Test_Pizza()
    {
      Pizza p = new Pizza("Cheese Pizza", new Size("Small", 5.00), new Crust("Normal", 0), new List<Topping>{new Topping("Cheese", 0.25)});
      Assert.IsType<Pizza>(p);
    }

    [Fact]
    public void Test_PizzaCalculate()
    {
      double act = 5.25;
      Pizza p = new Pizza("Cheese Pizza", new Size("Small", 5.00), new Crust("Normal", 0), new List<Topping>{new Topping("Cheese", 0.25)});
      double res = p.GetPrice();
      Assert.Equal(act, res);
    }

  }
}