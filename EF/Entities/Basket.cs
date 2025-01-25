using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF.Entities
{
    public  class Basket
    {
        public String Id { get; set; } = null!;
        public String IdUser { get; set; } = null!;
        public String Order { get; set; } = null!;
    }
}
