using DataManagement_311.Ado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataManagment_311.EF
{
    internal class EFDEMO
    {
        public void Run()
        {
            DataContext dataContext = new();

            Console.WriteLine($"Database connected.Users:{dataContext.UsersData.Count()}");
            Console.WriteLine($"Database connected.Roles:{dataContext.UserRoles.Count()}");
            Console.WriteLine($"Database connected.Accesses:{dataContext.UserAccesses.Count()}");
            Console.WriteLine("All Users:");
            Console.WriteLine("________________________________");
            foreach (var userData in dataContext.UsersData)
            {
                Console.WriteLine($"{userData.Name} ({userData.Email})");
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("First 3 Users:");
            var f3 = dataContext.UsersData.Take(3);
            foreach (var userData in f3.ToList())
            {
                Console.WriteLine($"{userData.Name} ({userData.Email})");
                //var ua = dataContext.UserAccesses.Where(ua => ua.UserId == userData.Id);
                //foreach (var a in ua)
                //{
                //    Console.WriteLine($"Access:{a.Login} ({a.RoleId})");
                //}

            }
            Console.WriteLine("________________________________");
            var udua = dataContext
                .UsersData
                .Join(
                    dataContext.UserAccesses,
                    ud => ud.Id,
                    ua => ua.UserId,
                    (ud, ua) => $"{ud.Name} {ua.Login}"

                );
            foreach (var str in udua)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("________________________________");
            foreach (var pair in dataContext
                .UsersData
                .Join(
                    dataContext.UserAccesses,
                    ud => ud.Id,
                    ua => ua.UserId,
                    (ud, ua) => new { ud, ua }

                ))
            {
                Console.WriteLine($"{pair.ud.Email} {pair.ua.RoleId}");
            }


            Console.WriteLine("________________________________");
            foreach (var pair in dataContext.UsersData

                .GroupJoin(
                    dataContext.UserAccesses,
                    ud => ud.Id,
                    ua => ua.UserId,
                    (ud, uaGrp) => new { ud, cnp = uaGrp.Count() }

                ))
            {
                Console.WriteLine($"{pair.ud.Name} {pair.cnp}");
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("Show all editors");
            Console.WriteLine("________________________________");

            foreach (var data in dataContext
                .UsersData
                .Join(
                    dataContext.UserAccesses,
                    ud => ud.Id,
                    ua => ua.UserId,
                    (ud, ua) => new { ud, ua }
            )
            .Where(udua => udua.ua.RoleId == "editor")
            .Select(udua => $"{udua.ud.Name} {udua.ua.Login} {udua.ua.RoleId}")
                )
            {
                Console.WriteLine(data);
            }

            Console.WriteLine("________________________________");

            Console.WriteLine(System.String.Join('\n', dataContext.UserRoles
                .GroupJoin(
                dataContext.UserAccesses,
                ur => ur.Id,
                ua => ua.RoleId,
                (ur, uaGrp) => $"{ur.Description}{uaGrp.Count()} {System.String.Join(',', uaGrp.Select(a => a.Login))}")));
            Console.WriteLine("________________________________");

            dataContext.UsersData
                .Where(u => u.Name.Contains("a"))
                .ForEachAsync(Console.WriteLine)
                .Wait();

            Console.WriteLine("________________________________");
            dataContext.UsersData
                .Join(
                dataContext.UserAccesses,
                ud => ud.Id,
                ua => ua.UserId,
                (ud, ua) => new { ud, ua })
                .Join(
                dataContext.UserRoles,
                uda => uda.ua.RoleId,
                ur => ur.Id,
                (uda, ur) => $"{uda.ud.Name} ---- {ur.Description}"
                )
                .ForEachAsync(Console.WriteLine)
                .Wait();
            Console.WriteLine("__________ 1) Enter the number of clients who may be allowed to edit (canUpdate)____");
            int cnt1 = 0;
            int cnt3 = 0;
            foreach (var data in dataContext.UserRoles
                .GroupJoin(
                dataContext.UserAccesses,
                ur => ur.Id,
                ua => ua.RoleId,
                (ur, uaGpr) => new { ur, uaGpr })

            .Where(udua => udua.ur.CanUpdate == 1)
            .Select(udua => $"{udua.uaGpr.Count()}")
            )

            {
                cnt3 = Convert.ToInt32(data);
                cnt1 += cnt3;
            };
            Console.WriteLine();
            Console.WriteLine($"Have the right to edit ___{cnt1}___ users!");
            Console.WriteLine("________________________________");

            Console.WriteLine("__________ 2) Enter all accounts (logins) that may be allowed for editing (canUpdate)____");
            foreach (var data in dataContext.UserRoles
                .Join(
                dataContext.UserAccesses,
                ur => ur.Id,
                ua => ua.RoleId,
                (ur, ua) => new { ur, ua })

            .Where(udua => udua.ur.CanUpdate == 1)
            .Select(udua => $"{udua.ua.Login}")
            )
            {
                Console.WriteLine(data);
            };
            Console.WriteLine("________________________________");

            Console.WriteLine("__________ 3) Enter all current accountants (names) who may be allowed to edit (canUpdate)____");
            foreach (var data in dataContext.UsersData
                .Join(
                dataContext.UserAccesses,
                ud => ud.Id,
                ua => ua.UserId,
                (ud, ua) => new { ud, ua })
                .Join(
                dataContext.UserRoles,
                uda => uda.ua.RoleId,
                ur => ur.Id,
                (ur, uda) => new { ur, uda })

            .Where(udua => udua.uda.CanUpdate == 1)
            .Select(udua => $"{udua.ur.ud.Name}")
            )
            {
                Console.WriteLine(data);
            };
            Console.WriteLine("________________________________");

            Console.WriteLine("__________ 4) Enter the number of customers whose phones begin with \"555\"____");
            int cnt11 = 0;
            int cnt31 = 0;
            foreach (var data in dataContext.UsersData
                  .Where(u => u.Phone.Contains("555"))
                  .Select(u => u.Phone.Count())
            )

            {

                cnt31 = Convert.ToInt32(data);
                if (cnt31 > 0)
                {
                    cnt11++;
                }
            };
            Console.WriteLine($"The phone on 555 starts with - {cnt11} - users");
            Console.WriteLine("________________________________");
            Console.WriteLine("__________ 5) Enter all roles and names of koristuvachs (through whom) that may be in roles____");
            Console.WriteLine(System.String.Join('\n', dataContext.UserAccesses
                .GroupJoin(
                dataContext.UsersData,
                ur => ur.RoleId,
                ua => ua.Id,
                (ur, uaGrp) => $"{ur.RoleId}{uaGrp.Count()} {System.String.Join(',', uaGrp.Select(a => a.Name))}")));
            Console.WriteLine("________________________________");
        }
        }
        }
    
