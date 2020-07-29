using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public int? UserId { get; set; }
    public int? StoreId { get; set; }
    public List<Pizza> Pizzas { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public Order()
    {
      Pizzas = new List<Pizza>();
      Date = DateTime.Now;
      Status = "Incomplete";
    }

    public void CreatePizza(Store store)
    {
      Pizza pizza = store.ChoosePizza();
      pizza.Size = store.ChooseSize();
      pizza.Crust = store.ChooseCrust();
      if((this.CalculatePrice() + pizza.GetPrice()) > 250)
      {
        System.Console.WriteLine("Pizza cannot be added as the order will exceed the $250 limit!");
        System.Console.WriteLine();
        return;
      }
      Pizzas.Add(pizza);

    }

    public void RemovePizza()
    {
      bool end = false;
      int select;

      do
      {
        System.Console.WriteLine("Type the number of the pizza to remove or 0 to return");
        System.Console.WriteLine();
        DisplayOrder();
        if (int.TryParse(System.Console.ReadLine(), out select))
        {
          System.Console.WriteLine();
        }
        else
        {
          System.Console.WriteLine("Invalid Choice");
          end = true;
          continue;
        }
        if ((select > Pizzas.Count || select < 1))
        {
          System.Console.WriteLine("");
          end = false;
        }
        else
        {
          Pizzas.RemoveAt(select - 1);
          end = false;
        }
      } while (end);
    }

    public void DisplayOrder()
    {
      System.Console.WriteLine(this);
    }

    public double CalculatePrice()
    {
      double price = 0;
      foreach (Pizza p in Pizzas)
      {
        price += p.GetPrice();
      }
      return price;
    }

    public override string ToString()
    {
      int count = 1;
      var sb = new StringBuilder();
      foreach (Pizza p in Pizzas)
      {
        if (count == 1)
        {
          sb.Append($"{count} : {p} - Price: ${p.GetPrice()}");
        }
        else
        {
          sb.Append($"\n{count} : {p} - Price: ${p.GetPrice()}");
        }
        count += 1;
      }

      return $"{sb}\nStatus: {Status}  Total Cost: ${CalculatePrice()}\n";
    }
  }
}