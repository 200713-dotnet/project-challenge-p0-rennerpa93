using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
    public DateTime? LastOrdered { get; set; }

    public User(int id, string email, List<Order> orders, DateTime lastordered) 
    {
      Id = id;
      Email = email;
      Orders = orders;
      LastOrdered = lastordered;
    }
    public User(string email) 
    {
      Email = email;
      Orders = new List<Order>();
    }
    public User() 
    {
      Email = "";
      Orders = new List<Order>();
      LastOrdered = DateTime.Now;
    }
    public void DisplayOrders()
    {
      if (Orders.Count < 1)
      {
        System.Console.WriteLine("There are no orders!");
        System.Console.WriteLine();
      }
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