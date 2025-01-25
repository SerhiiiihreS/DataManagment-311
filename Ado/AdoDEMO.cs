using Dapper;
using DataManagement_311.Ado;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataManagment_311.Ado
{
    internal class AdoDEMO
    {
        private SqlConnection? _sqlconnection;
        public SqlConnection sqlconnection
        {
            get
            {
                if (_sqlconnection == null)
                {
                    String? connectionString =
                JsonSerializer.Deserialize<JsonElement>(
                    File.ReadAllText("appsetting.json")
                )
                .GetProperty("ConnectionStrings")
                .GetProperty("Db311")
                .GetString();
                    if (connectionString == null)
                    {
                        throw new FileNotFoundException("Connection string not Found");
                    }
                    _sqlconnection  = new(connectionString);
                    _sqlconnection.Open();
                }
                return _sqlconnection!;
            }
        }
        public void Run()
        {
            Console.WriteLine("ADO.NET Demo");
            try
            {
                Console.WriteLine("Connection Ok" + sqlconnection.State);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            //CreateTable(); 
            //InsertData();
            using SqlCommand cmd = new();
            cmd.Connection = sqlconnection;
            cmd.CommandText = "SELECT*FROM UserRoles";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Id - {0}, Descr - {1}",
                        reader.GetString("Id"),
                        reader["Description"]);
                }
            }
            //orm 
            using (SqlCommand cmd2 = new())
            {
                cmd2.Connection = sqlconnection;
                cmd2.CommandText = "SELECT TOP 1 *FROM UserRoles";
                using SqlDataReader reader2 = cmd2.ExecuteReader();
                reader2.Read();
                UserRole ur = new()
                {
                    Id = reader2.GetString("Id"),
                    Description = reader2.GetString("Description"),
                    CanCreate = reader2.GetInt32("CanCreate"),
                    CanRead = reader2.GetInt32("CanRead"),
                    CanUpdate = reader2.GetInt32("CanUpdate"),
                    CanDelete = reader2.GetInt32("CanDelete"),
                };
                Console.WriteLine(ur);
            }
            DapperDemo();
        }


           private void DapperDemo()
        {
            String sql = "SELECT COUNT(*) FROM UserRoles";
            var cnt = sqlconnection.ExecuteScalar(sql);
            sql = "SELECT CURRENT_TIMESTAMP";
            DateTime dt= sqlconnection.ExecuteScalar<DateTime>(sql);
            Console.WriteLine($"In DB there {cnt} roles at {dt}");

            UserRole ur1=
            sqlconnection.QuerySingle<UserRole>("SELECT TOP 1 *FROM UserRoles");

            Console.WriteLine(ur1);
            Console.WriteLine("________________________________"); 
             ur1 =
            sqlconnection.QueryFirst<UserRole>("SELECT TOP 2 *FROM UserRoles");
            Console.WriteLine(ur1);
            var ur2= sqlconnection.QueryFirstOrDefault<UserRole>(
                "SELECT  *FROM UserRoles WHERE Id='undefined'");
            Console.WriteLine(ur2?.ToString()??"No data");
            Console.WriteLine("________________________________");
            var roles= sqlconnection.Query<UserRole>("SELECT *FROM UserRoles");
            foreach(UserRole r in roles)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("________________________________");
            Console.WriteLine(
            sqlconnection.QuerySingleOrDefault<UserRole>(
                "SELECT *FROM UserRoles WHERE Id = @RoleId",
                new {RoleId="moderator"}
                ));

            Console.WriteLine("________________________________");

            foreach (UserRole r in sqlconnection.Query<UserRole>(
                "SELECT *FROM UserRoles WHERE Id IN @RoleIds",
                new { RoleIds = new String[] { "moderator", "guest" } }
                )) {
                Console.WriteLine(r);
            }

            Console.WriteLine("________________________________");

            foreach (UserRole r in sqlconnection.Query<UserRole>(
                "SELECT *FROM UserRoles WHERE CanRead=@read AND CanUpdate=@update",
                new { read=1, update=1 }
                ))
            {
                Console.WriteLine(r);
            }

        }



        private void InsertData()
        {
            try
            {
                QueryDbl("INSERT INTO UserRoles VALUES('quest'," +
                    "'Autorized person with minimal access',0,0,0,0)");
                Console.WriteLine("SQL OK");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            try
            {
                using SqlCommand cmd = new();
                cmd.Connection = sqlconnection;
                cmd.CommandText = "INSERT INTO UserRoles VALUES('admin', @description,1,1,1,1)";
                cmd.Parameters.AddWithValue("description", "User that hasn't restrictions");
                cmd.ExecuteNonQuery();
                Console.WriteLine("SQL OK");

            }


            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            try
            {
                using SqlCommand cmd = new();
                cmd.Connection = sqlconnection;
                cmd.CommandText = "INSERT INTO UserRoles VALUES('moderator', @description,@canCreate,1,1,1)";

                var param = cmd.Parameters.Add("description", SqlDbType.Text, 256);
                param.Value = "User that can correct but not create";

                var param2 = cmd.Parameters.Add("canCreate", SqlDbType.Int);
                param2.Value = 0;

                cmd.ExecuteNonQuery();
                Console.WriteLine("SQL OK");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
        
        private void QueryDbl(String sql) { 
            using SqlCommand cmd = new();
            cmd.Connection = sqlconnection;
            cmd.CommandText =sql;
            cmd.ExecuteNonQuery();
        }

        private void CreateTable() {
            try
            {
                QueryDbl("CREATE TABLE UserData(" +
                "Id UNIQUEIDENTIFIER PRIMARY KEY," +
                "Name NVARCHAR(128) NOT NULL," +
                "Email NVARCHAR(256) NOT NULL," +
                "Phone VARCHAR(32)  NULL)");
                Console.WriteLine("SQL OK");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            try
            {
                QueryDbl("CREATE TABLE UserAccess(" +
                "Id UNIQUEIDENTIFIER      PRIMARY KEY," +
                "UserId UNIQUEIDENTIFIER  NOT NULL," +
                "RoleId UNIQUEIDENTIFIER  NOT NULL," +
                "Login NVARCHAR(256)      NOT NULL," +
                "Salt CHAR(16)            NOT NULL," +
                "Dk VARCHAR(32)           NOT NULL)");
                Console.WriteLine("SQL OK");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            try
            {
                QueryDbl("CREATE TABLE UserRoles(" +
                "Id VARCHAR(32)      PRIMARY KEY," +
                "Description NVARCHAR(256)  NOT NULL," +
                "CanCreate   INT  NOT NULL DEFAULT 0," +
                "CanRead     INT  NOT NULL DEFAULT 0," +
                "CanUpdate   INT  NOT NULL DEFAULT 0," +
                "CanDelete   INT  NOT NULL DEFAULT 0)");
                Console.WriteLine("SQL OK");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            try
            {
                QueryDbl("CREATE TABLE Product(" +
                "Id VARCHAR(32)      PRIMARY KEY," +
                "Item NVARCHAR(256)  NOT NULL," +
                "Name NVARCHAR(128) NOT NULL," +
                "Characteristics     NVARCHAR(256)  NOT NULL," +
                "Cost   INT  NOT NULL DEFAULT 0," +
                "Markup   INT  NOT NULL DEFAULT 0," +
                "Price   INT  NOT NULL DEFAULT 0)");
                Console.WriteLine("SQL OK");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }


        }

    }


}
