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

    public void CreatePizza(domain.Pizza pizza)
    {
      var newPizza = new Pizza();
      var pizzaTopping = new PizzaTopping();

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

      pizzaTopping.Pizza = newPizza;

      _db.Pizza.Add(newPizza);

      foreach (domain.Topping t in pizza.Toppings)
      {
        Topping newTop = new Topping()
        {
          Name = t.Name,
          Price = (decimal)t.Price
        };
        pizzaTopping.Topping = newTop;
      }

      _db.PizzaTopping.Add(pizzaTopping);
      _db.SaveChanges();
    }

    

    public void ReadPizza()
    {
      //var pizzas = _db.Pizza;
      //var pizzaswithcrust = _db.Pizza.Include(t => t.Crust).Include(t => t.Size);
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