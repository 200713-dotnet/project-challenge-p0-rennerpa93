using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
          Store store = new Store();
          Order order = new Order(store);
            Console.WriteLine(order.Date);
        }
    }
}
