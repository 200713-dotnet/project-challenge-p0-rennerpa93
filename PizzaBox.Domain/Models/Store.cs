using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public List<Order> Orders { get; set; }
    public string Location { get; set; }

    public Store(string location)
    {
      Location = location;
      Orders = new List<Order>();
    }

    public void DisplayOrders()
    {
      foreach (Order order in Orders)
      {
        System.Console.WriteLine(order);
      }
    }

    public void DisplaySales(System.DateTime startTime, string option = "weekly")
    {
      if (option == "weekly")
      {

      }
      else
      {

      }
    }

    public void ModifyOrder(User user, Order order)
    {
      bool modify = true;
      int select;

      do
      {
        System.Console.WriteLine("Type 1 to add a pizza, 2 to remove a pizza, or 3 to quit");
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
            order.CreatePizza(this);
            break;
          case 2:
            order.RemovePizza();
            break;
          default:
            modify = false;
            break;
        }
      } while (modify);

      System.Console.WriteLine("Final Order:");
      order.DisplayOrder();
      Orders.Add(order);
      user.Orders.Add(order);

    }
    public Pizza ChoosePizza()
    {
      int select;
      bool end = false;
      Pizza pizza = new Pizza();
      do
      {
        System.Console.WriteLine("Type a number to select a pizza");
        System.Console.WriteLine("1 - Cheese Pizza - $5.25");
        System.Console.WriteLine("2 - Pepperoni Pizza - $5.50");
        System.Console.WriteLine("3 - Vegetarian Pizza - $5.75");
        System.Console.WriteLine("4 - Hawaiian Pizza - $6.25");
        System.Console.WriteLine("5 - Custom - $5.00 + toppings");
        if (int.TryParse(System.Console.ReadLine(), out select))
        {
          System.Console.WriteLine();
          end = false;
        }
        else
        {
          System.Console.WriteLine("Invalid Choice");
          end = true;
          continue;
        }

        switch (select)
        {
          case 1:
            pizza.Name = "Cheese Pizza";
            pizza.Toppings = new List<Topping> { new Topping("Cheese", 0.25) };
            break;
          case 2:
            pizza.Name = "Pepperoni Pizza";
            pizza.Toppings = new List<Topping> { new Topping("Cheese", 0.25), new Topping("Pepperoni", 0.25) };
            break;
          case 3:
            pizza.Name = "Vegetarian Pizza";
            pizza.Toppings = new List<Topping> { new Topping("Cheese", 0.25), new Topping("Onions", 0.25), new Topping("Green Peppers", 0.25) };
            break;
          case 4:
            pizza.Name = "Vegetarian Pizza";
            pizza.Toppings = new List<Topping> { new Topping("Cheese", 0.25), new Topping("Ham", 0.50), new Topping("Pineapple", 0.50) };
            break;
          case 5:
            pizza.Name = "Custom Pizza";
            pizza.Toppings = ChooseToppings();
            break;
          default:
            end = true;
            System.Console.WriteLine("Invalid Choice");
            break;
        }

      } while (end);

      return pizza;
    }

    public Size ChooseSize()
    {
      int select;
      bool end = false;
      do
      {
        System.Console.WriteLine("Type a number to select a size");
        System.Console.WriteLine("1 - Small");
        System.Console.WriteLine("2 - Medium : $2.00 extra");
        System.Console.WriteLine("3 - Large : $4.00 extra");
        System.Console.WriteLine("4 - Extra Large : $6.00 extra");
        if (int.TryParse(System.Console.ReadLine(), out select))
        {
          System.Console.WriteLine();
          end = false;
        }
        else
        {
          System.Console.WriteLine("Invalid Choice");
          end = true;
          continue;
        }

        switch (select)
        {
          case 1:
            break;
          case 2:
            return new Size("Medium", 7.00);
          case 3:
            return new Size("Large", 9.00);
          case 4:
            return new Size("Extra Large", 11.00);
          default:
            System.Console.WriteLine("Invalid Choice");
            end = true;
            break;
        }
      } while (end);

      return new Size("Small", 5.00);
    }

    public Crust ChooseCrust()
    {
      int select;
      bool end = false;
      do
      {
        System.Console.WriteLine("Type a number to select a crust");
        System.Console.WriteLine("1 - Normal");
        System.Console.WriteLine("2 - Cheese-Stuffed : $1.00 extra");
        System.Console.WriteLine("3 - Parmesan Garlic : $1.00 extra");
        System.Console.WriteLine("4 - Parmesan Garlic Cheese-Stuffed : $2.00 extra");
        if (int.TryParse(System.Console.ReadLine(), out select))
        {
          System.Console.WriteLine();
          end = false;
        }
        else
        {
          System.Console.WriteLine("Invalid Choice");
          end = true;
          continue;
        }

        switch (select)
        {
          case 1:
            break;
          case 2:
            return new Crust("Cheese-Stuffed Crust", 1.00);
          case 3:
            return new Crust("Parmesan Garlic Crust", 1.00);
          case 4:
            return new Crust("Parmesan Garlic Cheese-Stuffed Crust", 2.00);
          default:
            System.Console.WriteLine("Invalid Choice");
            end = true;
            break;
        }
      } while (end);

      return new Crust("Normal Crust", 0);
    }

    public List<Topping> ChooseToppings()
    {
      List<Topping> toppings = new List<Topping>();
      int select;
      bool end = true;
      do
      {
        System.Console.WriteLine("Type a number to select add a topping");
        System.Console.WriteLine("1 - Cheese : $0.25");
        System.Console.WriteLine("2 - Pepperoni : $0.25");
        System.Console.WriteLine("3 - Green Peppers : $0.25");
        System.Console.WriteLine("4 - Onions : $0.25");
        System.Console.WriteLine("5 - Ham : $0.50");
        System.Console.WriteLine("6 - Sausage : $0.50");
        System.Console.WriteLine("7 - Pineapple : $0.50");
        System.Console.WriteLine("8 - Finish");

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
            toppings.Add(new Topping("Cheese", 0.25));
            break;
          case 2:
            toppings.Add(new Topping("Pepperoni", 0.25));
            break;
          case 3:
            toppings.Add(new Topping("Green Peppers", 0.25));
            break;
          case 4:
            toppings.Add(new Topping("Onions", 0.25));
            break;
          case 5:
            toppings.Add(new Topping("Ham", 0.50));
            break;
          case 6:
            toppings.Add(new Topping("Sausage", 0.50));
            break;
          case 7:
            toppings.Add(new Topping("Pineapple", 0.50));
            break;
          case 8:
            end = false;
            break;
        }
      } while(end);

      return toppings;
    }
  }
}