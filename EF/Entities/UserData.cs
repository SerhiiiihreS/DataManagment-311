using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF.Entities
{
  public class UserData
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String Phone { get; set; } = null!;

        public override string ToString()
        {
            return $"UserData: Id({Id}), Name({Name}),Email({Email}), Phone({Phone})";
        }
    }
}
