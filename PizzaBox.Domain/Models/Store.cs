using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public List<Order> Orders { get; set; }
    public string Location { get; set; }
    public string Region { get; set; }
    public string Format { get; set; }

    public Store(string location, string region="en-US", string format="F")
    {
      Location = location;
      Region = region;
      Format = format;
    }
  }
}