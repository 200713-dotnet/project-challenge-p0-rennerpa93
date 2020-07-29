﻿using System;
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
      System.Console.WriteLine("Pick the number for the store you would like to use.");
      foreach (Store s in stores)
      {
        System.Console.WriteLine($"{s.Id} - {s.Location}");
      }

      int num;
      bool storeEnd = true;
      do
      {
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
        System.Console.WriteLine("Please enter your email");
        email = System.Console.ReadLine();
        System.Console.WriteLine();
        User user = repo.ReadUser(email);

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
              MainStore.ModifyOrder(user, order);
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
