using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public List<Order> Orders { get; set; }
    public string Location { get; set; }

    public Store()
    {
      Location = "";
      Orders = new List<Order>();
    }
    public Store(string location)
    {
      Location = location;
    }

    public void DisplayOrders()
    {
      foreach (Order order in Orders)
      {
        System.Console.WriteLine(order);
      }
    }

    public void DisplaySales(System.DateTime startTime, string option="weekly")
    {
      if (option == "weekly")
      {
        
      }
    }
  }
}