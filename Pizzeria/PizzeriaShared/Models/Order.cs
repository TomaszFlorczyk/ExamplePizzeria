using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaShared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }

    }
}
