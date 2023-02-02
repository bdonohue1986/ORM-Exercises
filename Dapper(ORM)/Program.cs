using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper_ORM_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            
            var task1 = new DapperDepartmentRepository(conn);
            var task2 = task1.GetAllDepartments();
            foreach (var task3 in task2)
            {
                Console.WriteLine($"{task3.DepartmentID} {task3.Name}" );
            }
            var task4 = new DapperProductRepository(conn);
            var task5 = task4.GetAllProducts();
            foreach( var task6 in task5)
            {
                Console.WriteLine($"{task6.Name} {task6.Price}{task6.CategoryID} {task6.ProductID}");
            }
        }
    }
}
