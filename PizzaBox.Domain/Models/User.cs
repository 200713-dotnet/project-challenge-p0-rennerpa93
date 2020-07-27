using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public string Email { get; set; }
    public List<Order> Orders { get; set; }

    public User(string Email) {
      Orders = new List<Order>();
    }
    public void DisplayOrders()
    {
      int count = 1;
      foreach (Order order in Orders)
      {
        System.Console.WriteLine($"Order #{count}");
        System.Console.WriteLine(order);
        System.Console.WriteLine("---------------------");
        count += 1;
      }
    }
  }
}