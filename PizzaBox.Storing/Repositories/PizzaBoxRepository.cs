using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using domain = PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaBoxRepository
  {
    private PizzaBoxDbContext _db = new PizzaBoxDbContext();

    public void CreateUser(domain.User user)
    {
      var newUser = new User();

      newUser.Email = user.Email;

      _db.Add(newUser);
      _db.SaveChanges();
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

    public void CreateOrder(domain.Order order, int userid, int storeid)
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

    }

    public List<domain.Order> ReadOrders(int id, string type = "Store")
    {
      List<domain.Order> orders = new List<domain.Order>();
      if (type == "Store")
      {
        var orderEntities = _db.Order.Where(o => o.StoreId == id).Include(o => o.Pizza);
      }
      else
      {
        var orderEntities = _db.Order.Where(o => o.UserId == id).Include(o => o.Pizza);
      }
      return orders;
    }
    
    public List<domain.Store> ReadStores()
    {
      List<domain.Store> stores = new List<domain.Store>();

      var storeEntities = _db.Store.ToList();
      foreach (Store s in storeEntities)
      {

      }

      return stores;
    }
    public void ReadPizza()
    {
      //var pizzas = _db.Pizza;
      //var pizzaswithcrust = _db.Pizza.Include(t => t.Crust).Include(t => t.Size);
      var domainPizzas = new List<domain.Pizza>();
      var pizzas = _db.PizzaTopping.Include(t => t.Pizza).Include(t => t.Topping);

    }
    public domain.User ReadUser(string email)
    {
      //var rUser = _db.User.Where(u => u.Email == email).Include(u => u.Order).FirstOrDefault<User>();
      var rUser = _db.User.Include(u => u.Order).ThenInclude(u => u.Pizza).FirstOrDefault(u => u.Email == email);

      domain.User eUser = new domain.User();
      eUser.Id = rUser.UserId;
      eUser.Email = rUser.Email;
      eUser.LastOrdered = rUser.LastOrdered;

      List<domain.Order> nOrders = new List<domain.Order>();
      foreach (Order o in rUser.Order)
      {
        domain.Order nOrder = new domain.Order();
        nOrder.Date = o.DateCreated;
        nOrder.Status = o.Status;
        nOrder.OrderId = o.OrderId;
        nOrder.StoreId = o.StoreId;
        nOrder.UserId = o.UserId;
        nOrders.Add(nOrder);
      }
      eUser.Orders = nOrders;
      return eUser;
    }

    public void UpdatePizza()
    {
    }
    public void DeletePizza()
    {
    }
  }
}