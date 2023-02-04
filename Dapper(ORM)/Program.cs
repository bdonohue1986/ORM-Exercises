using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Dapper_ORM_
{
    public class Program
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
                Console.WriteLine($"{task3.DepartmentID} {task3.Name}");
            }
            Console.WriteLine("Would you like to add a department? (Yes or No)");
            var response = Console.ReadLine().ToLower();
            while (response != "yes" && response != "no")
            {
                Console.WriteLine($"{response} is not a valid response please enter yes or no.");
                response = Console.ReadLine().ToLower();
            }
            while (response == "yes")
            {

                Console.WriteLine("Please enter the New Department");
                var newInsert = Console.ReadLine().ToLower();
                task1.InsertDepartment(newInsert);
                Console.WriteLine("Do you need to add any other Departments? (yes or no)");
                response = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Products ... Press enter");
            Console.ReadLine().ToLower();

            var task4 = new DapperProductRepository(conn);
            var task5 = task4.GetAllProducts();
            foreach (var task6 in task5)
            {
                Console.WriteLine($"{task6.ProductID}  {task6.Name}");
            }
            Console.WriteLine("Would you like to add a product? yes or no");
            var answer = Console.ReadLine().ToLower();
            while (answer != "yes" && answer != "no")
            {
                answer = Console.ReadLine().ToLower();
            }
            while (answer == "yes")
            {


                Console.WriteLine("Enter your New Product Name.");
                var newProductName = Console.ReadLine();
                Console.WriteLine("Enter The Price using Dollars and cents. EX. 19.00");
                double NewPrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("What is the Category ID? (numbers only 1-4)");
                int CategoryID = Convert.ToInt32(Console.ReadLine());
                task4.InsertProduct(newProductName, NewPrice, CategoryID);
                Console.WriteLine("Would you like to add another product?");
                answer = Console.ReadLine().ToLower();



            }

            Console.WriteLine("Rerun program to see updated list");
            Console.WriteLine("Would you like to delete any of the products from above?");

            var answer2 = Console.ReadLine().ToLower();

            while (answer2 != "yes" && answer2 != "no")
            {
                Console.WriteLine("Please enter yes or no only");
                answer2 = Console.ReadLine().ToLower();                
            }
            if(answer2 == "yes")
            {
                Console.WriteLine("Enter the ProductID of the Item to delete. ( This is the 3 digit number before the item above");
                var answer3 = Convert.ToInt32(Console.ReadLine());
                task4.DeleteProduct(answer3);
            }
        }
    }
}
