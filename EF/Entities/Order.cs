using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string IdProduct { get; set; } = null!;
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int Total { get; set; }
        public string Status { get; set; } = null!;

    }
}
