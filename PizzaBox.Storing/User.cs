using System;
using System.Collections.Generic;

namespace PizzaBox.Storing
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public DateTime? LastOrdered { get; set; }
        public string CurrentStore { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
