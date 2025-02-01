using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF
{
    internal class EFDEMO
    {
        public void Run()
        {
            DataContext dataContext = new();

            Console.WriteLine($"Database connected.Users:{dataContext.UsersData.Count()}");
            Console.WriteLine($"Database connected.rRoles:{dataContext.UserRoles.Count()}");
            Console.WriteLine("All Users:");
            foreach(var userData in dataContext.UsersData)
            {
                Console.WriteLine($"{userData.Name} ({userData.Email})");
            }
            Console.WriteLine("First 3 Users:");
            var f3 = dataContext.UsersData.Take(3);
            foreach(var userData in f3)
            {
                Console.WriteLine($"{userData.Name} ({userData.Email})");
            }
        }
    }
}
