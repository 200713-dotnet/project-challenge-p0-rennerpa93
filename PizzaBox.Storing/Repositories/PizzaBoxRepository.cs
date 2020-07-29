using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using domain = PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaBoxRepository
  {
    private PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public domain.User CreateUser(string email)
    {
      var entUser = new User();
      domain.User newUser = new domain.User();
      entUser.Email = email;
      newUser.Email = email;

      _db.Add(entUser);
      _db.SaveChanges();
      newUser.Id = entUser.UserId;

      return newUser;
    }

    public void CreatePizza(domain.Pizza pizza, int orderId)
    {
      var newPizza = new Pizza();


      newPizza.Name = pizza.Name;

      newPizza.Crust = new Crust()
      {
        Type = pizza.Crust.Type,
        Price = (decimal)pizza.Crust.Price
      };

      newPizza.Size = new Size()
      {
        Name = pizza.Size.Name,
        Price = (decimal)pizza.Size.Price
      };

      newPizza.OrderId = orderId;

      _db.Pizza.Add(newPizza);

      foreach (domain.Topping t in pizza.Toppings)
      {
        var pizzaTopping = new PizzaTopping();
        pizzaTopping.Pizza = newPizza;
        Topping newTop = new Topping()
        {
          Name = t.Name,
          Price = (decimal)t.Price
        };
        pizzaTopping.Topping = newTop;
        _db.PizzaTopping.Add(pizzaTopping);
      }

      _db.SaveChanges();
    }

    public int CreateOrder(domain.Order order, int userid, int storeid)
    {
      var newOrder = new Order();
      newOrder.UserId = userid;
      newOrder.StoreId = storeid;
      newOrder.Status = order.Status;
      newOrder.DateCreated = order.Date;
      _db.Order.Add(newOrder);
      _db.SaveChanges();
      int newOrderId = newOrder.OrderId;

      foreach (domain.Pizza p in order.Pizzas)
      {
        CreatePizza(p, newOrderId);
      }
      return newOrderId;
    }

    public List<domain.Order> ReadOrders(int id, string type = "Store")
    {
      List<domain.Order> orders = new List<domain.Order>();

      List<Order> orderEntities;
      if (type == "Store")
      {
        orderEntities = _db.Order.Where(o => o.StoreId == id).ToList();
      }
      else
      {
        orderEntities = _db.Order.Where(o => o.UserId == id).ToList();
      }

      foreach (Order o in orderEntities)
      {
        domain.Order newO = new domain.Order();
        newO.Date = o.DateCreated;
        newO.Status = o.Status;
        newO.OrderId = o.OrderId;
        newO.StoreId = o.StoreId;
        newO.UserId = o.UserId;

        newO.Pizzas = ReadAllPizzas(newO.OrderId);
        orders.Add(newO);
      }
      return orders;
    }

    public List<domain.Store> ReadStores()
    {
      List<domain.Store> stores = new List<domain.Store>();

      var storeEntities = _db.Store.ToList();
      foreach (Store s in storeEntities)
      {
        domain.Store newStore = new domain.Store();
        newStore.Location = s.Location;
        newStore.Id = s.StoreId;
        newStore.Orders = ReadOrders(s.StoreId, "Store");
        stores.Add(newStore);
      }

      return stores;
    }
    public domain.Pizza ReadPizza(int orderId)
    {
      //var pizzas = _db.Pizza;
      //var pizzaswithcrust = _db.Pizza.Include(t => t.Crust).Include(t => t.Size);
      var domainPizzas = new List<domain.Pizza>();
      var dbPizza = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).FirstOrDefault(t => t.OrderId == orderId);

      domain.Pizza pizza = new domain.Pizza();

      pizza.Name = dbPizza.Name;
      pizza.Size = new domain.Size() { Name = dbPizza.Size.Name, Price = (double)dbPizza.Size.Price };
      pizza.Crust = new domain.Crust() { Type = dbPizza.Crust.Type, Price = (double)dbPizza.Crust.Price };

      var pizzaToppings = _db.PizzaTopping.Where(t => t.PizzaId == dbPizza.PizzaId).Include(t => t.Topping);
      foreach (PizzaTopping pt in pizzaToppings)
      {
        domain.Topping newTop = new domain.Topping() { Name = pt.Topping.Name, Price = (double)pt.Topping.Price };
        pizza.Toppings.Add(newTop);
      }

      return pizza;
    }

    public List<domain.Pizza> ReadAllPizzas(int orderId)
    {
      //var pizzas = _db.Pizza;
      //var pizzaswithcrust = _db.Pizza.Include(t => t.Crust).Include(t => t.Size);
      var domainPizzas = new List<domain.Pizza>();
      var dbPizzas = _db.Pizza.Include(t => t.Crust).Include(t => t.Size).Where(t => t.OrderId == orderId).ToList();


      foreach (Pizza dbPizza in dbPizzas)
      {
        domain.Pizza pizza = new domain.Pizza();
        pizza.Name = dbPizza.Name;
        pizza.Size = new domain.Size() { Name = dbPizza.Size.Name, Price = (double)dbPizza.Size.Price };
        pizza.Crust = new domain.Crust() { Type = dbPizza.Crust.Type, Price = (double)dbPizza.Crust.Price };

        var pizzaToppings = _db.PizzaTopping.Where(t => t.PizzaId == dbPizza.PizzaId).Include(t => t.Topping);
        foreach (PizzaTopping pt in pizzaToppings)
        {
          domain.Topping newTop = new domain.Topping() { Name = pt.Topping.Name, Price = (double)pt.Topping.Price };
          pizza.Toppings.Add(newTop);
        }
        domainPizzas.Add(pizza);
      }

      return domainPizzas;
    }
    public domain.User ReadUser(string email)
    {
      //var rUser = _db.User.Where(u => u.Email == email).Include(u => u.Order).FirstOrDefault<User>();
      User rUser = new User();
      try
      {
        rUser = _db.User.First(u => u.Email == email);
      }
      catch (Exception e)
      {
        return CreateUser(email);
      }

      rUser = _db.User.First(u => u.Email == email);

      domain.User eUser = new domain.User();
      eUser.Id = rUser.UserId;
      eUser.Email = rUser.Email;
      eUser.LastOrdered = rUser.LastOrdered;
      eUser.Orders = ReadOrders(rUser.UserId, "User");
      return eUser;
    }

    // public void UpdatePizza(domain.Pizza pizza, int orderId)
    // {
    //   var newPizza = new Pizza();

    //   newPizza.Name = pizza.Name;

    //   newPizza.Crust = new Crust()
    //   {
    //     Type = pizza.Crust.Type,
    //     Price = (decimal)pizza.Crust.Price
    //   };

    //   newPizza.Size = new Size()
    //   {
    //     Name = pizza.Size.Name,
    //     Price = (decimal)pizza.Size.Price
    //   };

    //   newPizza.OrderId = orderId;

    //   _db.Pizza.Add(newPizza);

    //   foreach (domain.Topping t in pizza.Toppings)
    //   {
    //     var pizzaTopping = new PizzaTopping();
    //     pizzaTopping.Pizza = newPizza;
    //     Topping newTop = new Topping()
    //     {
    //       Name = t.Name,
    //       Price = (decimal)t.Price
    //     };
    //     pizzaTopping.Topping = newTop;
    //     _db.PizzaTopping.Add(pizzaTopping);
    //   }

    //   _db.SaveChanges();
    // }
    public void UpdateUser(domain.User user, int storeId, string store, DateTime date)
    {
      var entUser = new User();
      entUser.UserId = user.Id;
      entUser.Email = user.Email;
      entUser.CurrentStore = store;
      entUser.LastOrdered = date;
      List<Order> eOrders = new List<Order>();

      foreach (domain.Order order in user.Orders)
      {
        var eOrder = new Order();
        eOrder.OrderId = order.OrderId;
        eOrder.UserId = user.Id;
        eOrder.StoreId = storeId;
        eOrder.Status = order.Status;
        eOrder.DateCreated = order.Date;
        eOrders.Add(eOrder);

        // foreach (domain.Pizza p in order.Pizzas)
        // {
        //   UpdatePizza(p, eOrder.OrderId);
        // }
      }

      entUser.Order = eOrders;

      _db.User.Update(entUser);
      _db.SaveChanges();

    }
    public void UpdateStore(domain.Store store)
    {
    }
  }
}