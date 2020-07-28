using System.Collections.Generic;
using System.Linq;
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
    }

    public void ReadUser()
    {
      
    }
    public void CreateTopping(domain.Topping topping)
    {
      var newTopping = new Topping();

    }
    public void CreatePizza(domain.Pizza pizza)
    {
      var newPizza = new Pizza();

      newPizza.Name = pizza.Name;
      newPizza.Crust = new Crust() { Type = pizza.Crust.Type };
      newPizza.Size = new Size() { Name = pizza.Size.Name };

      _db.Pizza.Add(newPizza);
      _db.SaveChanges();

    }
    public void ReadPizza()
    {
    }
    public void UpdatePizza()
    {
    }
    public void DeletePizza()
    {
    }
  }
}