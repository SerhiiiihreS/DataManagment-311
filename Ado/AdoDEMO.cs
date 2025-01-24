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
            cmd.CommandText= "SELECT*FROM UserRoles";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                Console.WriteLine("Id - {0}, Descr - {1}",
                    reader.GetString("Id"),
                    reader["Description"]);
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
