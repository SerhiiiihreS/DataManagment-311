using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF.Entities
{
    public  class Product
    {
        public String Id { get; set; } = null!;
        public String Item { get; set; } = null!;
        public String Name { get; set; } = null!;
        public String Characteristics { get; set; } = null!;
        public int CCost { get; set; }
        public int Markup { get; set; }
        public int Price { get; set; }

    }
}
