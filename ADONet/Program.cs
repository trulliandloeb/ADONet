using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADONet
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["localDB"].ToString();
            Console.WriteLine(connectionString);
            var sql = "select * from products";
            using (var connection = new SqlConnection(connectionString))
            {
                using ( var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}", reader[0], reader[1], reader[2], reader[3]);
                        }
                    }
                }
            }
        }
    }
}
