using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF.Entities
{
 public class UserAccess
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String RoleId { get; set; } = null!;
        public String Login { get; set; } = null!;
        public String Salt { get; set; } = null!;
        public String Dk { get; set; } = null!;

        public override string ToString()
        {
            return $"UserData: Id({Id}), UserId({UserId}),RoleId({RoleId}), Login({Login})";
        }
    }
}
