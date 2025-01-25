using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement_311.Ado
{
    // "CREATE TABLE UserData (" +
    //     "Id     UNIQUEIDENTIFIER  PRIMARY KEY," +
    //     "Name   NVARCHAR(128)     NOT NULL," +
    //     "Email  NVARCHAR(256)     NOT NULL," +
    //     "Phone  VARCHAR(32)       NULL )"
    public class UserData
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String Phone { get; set; } = null!;
    }

    // "CREATE TABLE UserAccess (" +
    //    "Id     UNIQUEIDENTIFIER  PRIMARY KEY," +
    //    "UserId UNIQUEIDENTIFIER  NOT NULL," +
    //    "RoleId UNIQUEIDENTIFIER  NOT NULL," +
    //    "Login  NVARCHAR(256)     NOT NULL," +
    //    "Salt   CHAR(16)          NOT NULL," +
    //    "Dk     VARCHAR(32)       NOT NULL )"
    public class UserAccess
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public String RoleId { get; set; } = null!;
        public String Login { get; set; } = null!;
        public String Salt { get; set; } = null!;
        public String Dk { get; set; } = null!;
    }

    // "CREATE TABLE UserRoles (" +
    //    "Id          VARCHAR(32)        PRIMARY KEY," +
    //    "Description NVARCHAR(256)      NOT NULL," +
    //    "CanCreate   INT                NOT NULL DEFAULT 0," +
    //    "CanRead     INT                NOT NULL DEFAULT 0," +
    //    "CanUpdate   INT                NOT NULL DEFAULT 0," +
    //    "CanDelete   INT                NOT NULL DEFAULT 0 )"
    public class UserRole
    {
        public String Id { get; set; } = null!;
        public String Description { get; set; } = null!;
        public int CanCreate { get; set; }
        public int CanRead { get; set; }
        public int CanUpdate { get; set; }
        public int CanDelete { get; set; }

        public override string ToString()
        {
            return $"{Id} ({Description}): { CanCreate }/{CanRead}/{CanUpdate}/{CanDelete}";
        }
    }
}

/* ORM - Object Relation Mapping - відображення даних на об'єкти
 * Суть - дані з формату, яким вони передаються (DB, JSON, XML, CSV),
 * перетворюються у об'єкти мови програмування (їх колекції), з 
 * якими продовжується алгоритмічна робота
 * 
 *                                          ORM
 * { "Name": "The User", "Email": "u@i.ua" } => new User("The User", "u@i.ua")
 * 
 *  class User {     | DTO - Data Transfer Object
 *   String Name;    | Entity
 *   String Email;   | 
 *  }                | 
 */
