using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Order
  {
    public List<Pizza> Pizzas { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public Store Store { get; set; }

    public Order(Store store) {
      Pizzas = new List<Pizza>();
      Date = DateTime.Now;
      Status = "Placed";
      Store = store;
    }
  }
}