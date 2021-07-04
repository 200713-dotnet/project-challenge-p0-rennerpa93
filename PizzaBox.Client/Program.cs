using System;
using System.Linq;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var repo = new PizzaBoxRepository();
      var db = new PizzaBox.Storing.PizzaBoxDbContext();

      Store MainStore;
      List<Store> stores = repo.ReadStores();

      int num;
      bool storeEnd = true;
      do
      {
        int storeCount = 1;
        System.Console.WriteLine("Pick the number for the store you would like to use.");
        foreach (Store s in stores)
        {
          System.Console.WriteLine($"{storeCount} - {s.Location}");
          storeCount += 1;
        }

        if (int.TryParse(System.Console.ReadLine(), out num))
        {
          System.Console.WriteLine();
          storeEnd = false;
        }
        else
        {
          System.Console.WriteLine("Invalid Choice");
          continue;
        }
        if (num > stores.Count)
        {
          System.Console.WriteLine("Invalid Choice");
          storeEnd = true;
        }
      } while (storeEnd);

      MainStore = stores[num - 1];

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
              MainStore.DisplayOrders();
              break;
            case 2:
              MainStore.DisplaySales(new DateTime());
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
        System.Console.WriteLine("Please enter your username");
        email = System.Console.ReadLine();
        System.Console.WriteLine();
        User user = repo.ReadUser(email);

        bool check = true;
        int select;
        do
        {
          System.Console.WriteLine("Pick the number for what you would like to do.");
          System.Console.WriteLine("1 - Check Orders");
          System.Console.WriteLine("2 - Create");
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
              MainStore.ModifyOrder(user, order);
              repo.CreateOrder(order, user.Id, MainStore.Id);
              break;
              // bool orderEnd = true;
              // int choices;
              // Order order;
              // do
              // {
              //   System.Console.WriteLine("Pick the number to create or modify an order.");
              //   System.Console.WriteLine();
              //   System.Console.WriteLine("0 - New Order");
              //   System.Console.WriteLine();
              //   System.Console.WriteLine("---------------------");
              //   user.DisplayOrders();
              //   if (int.TryParse(System.Console.ReadLine(), out choices))
              //   {
              //     System.Console.WriteLine();
              //     orderEnd = false;
              //   }
              //   else
              //   {
              //     System.Console.WriteLine("Invalid Choice");
              //     System.Console.WriteLine();
              //     continue;
              //   }
              //   if (choices >= user.Orders.Count)
              //   {
              //     System.Console.WriteLine("Invalid Choice");
              //     System.Console.WriteLine();
              //     orderEnd = true;
              //   }
              // } while (orderEnd);
              // if (choices == 0)
              // {
              //   order = new Order();
              //   MainStore.ModifyOrder(user, order);
              // }
              // else
              // {
              //   order = user.Orders[choices - 1];
              //   MainStore.ModifyOrder(user, order, "mod");
              // }
              // break;
            default:
              check = false;
              break;
          }
        } while (check);
        // repo.UpdateUser(user, MainStore.Id, MainStore.Location, DateTime.Now);
      }
      
    }
  }
}
