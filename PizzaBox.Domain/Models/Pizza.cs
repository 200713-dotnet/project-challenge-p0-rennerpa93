using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public Size Size { get; set; }
    public Crust Crust { get; set; }
    public string Shape { get; set; }
    public List<Topping> Toppings { get; set; }
  }
}