using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      Store MainStore;
      Store store = new Store("Michigan");
      Store store2 = new Store("Texas");
      System.Console.WriteLine($"Please choose a Location: [{store.Location}]  [{store2.Location}]");
      string loc = System.Console.ReadLine();
      System.Console.WriteLine();
      MainStore = new Store(loc);

      string choice;
      System.Console.WriteLine("Are you a [Store] or [User]?");
      choice = System.Console.ReadLine();
      System.Console.WriteLine();

      if (choice == "Store")
      {
        bool check = true;
        int select;
        do
        {
          System.Console.WriteLine("Pick the number for what you would like to do.");
          System.Console.WriteLine("1 - Check Orders");
          System.Console.WriteLine("2 - Check Sales");
          System.Console.WriteLine("3 - Quit");
          if (int.TryParse(System.Console.ReadLine(), out select))
          {
            System.Console.WriteLine();
          }
          else
          {
            System.Console.WriteLine("Invalid Choice");
            continue;
          }
          switch (select)
          {
            case 1:
              store.DisplayOrders();
              break;
            case 2:
              store.DisplaySales(new DateTime());
              break;
            default:
              check = false;
              break;
          }
        } while (check);
      }
      else
      {
        string email;
        System.Console.WriteLine("Please enter your email");
        email = System.Console.ReadLine();
        System.Console.WriteLine();
        User user = new User(email);
        bool check = true;
        int select;
        do
        {
          System.Console.WriteLine("Pick the number for what you would like to do.");
          System.Console.WriteLine("1 - Check Orders");
          System.Console.WriteLine("2 - Create/Modify Order");
          System.Console.WriteLine("3 - Quit");
          if (int.TryParse(System.Console.ReadLine(), out select))
          {
            System.Console.WriteLine();
          }
          else
          {
            System.Console.WriteLine("Invalid Choice");
            continue;
          }
          switch (select)
          {
            case 1:
              user.DisplayOrders();
              break;
            case 2:
              Order order = new Order();
              store.ModifyOrder(user, order);
              break;
            default:
              check = false;
              break;
          }
        } while (check);

      }
    }
  }
}
