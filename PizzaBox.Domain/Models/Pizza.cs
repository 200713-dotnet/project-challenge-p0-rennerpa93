using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Pizza
  {
    public string Name { get; set; }
    public Size Size { get; set; }
    public Crust Crust { get; set; }
    public List<Topping> Toppings { get; set; }

    public Pizza()
    {
      Name = "";
      Size = new Size();
      Crust = new Crust();
      Toppings = new List<Topping>();
    }

    public Pizza(string name, Size size, Crust crust, List<Topping> toppings)
    {
      Name = name;
      Size = size;
      Crust = crust;
      Toppings = toppings;
    }
    public double GetPrice()
    {
      double price = 0;
      foreach (Topping t in Toppings)
      {
        price += t.Price;
      }
      price += Size.Price;
      price += Crust.Price;
      return price;
    }

    public override string ToString()
    {
      int count = 0;
      var sb = new StringBuilder();
      foreach (Topping t in Toppings)
      {
        if (count == 0)
        {
          sb.Append(t);
        }
        else
        {
          sb.Append($" + {t}");
        }
        count += 1;
      }

      return $"{Size} {Crust} {Name} with {sb}";
    }
  }
}