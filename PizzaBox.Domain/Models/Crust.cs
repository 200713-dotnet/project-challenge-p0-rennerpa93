namespace PizzaBox.Domain.Models
{
  public class Crust
  {
    public string Type { get; set; }
    public double Price { get; set; }


    public Crust(string type, double price)
    {
      Type = type;
      Price = price;
    }

    public override string ToString() 
    {
      return Type;
    }
  }
}