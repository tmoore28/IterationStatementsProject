using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
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
            
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Please enter a new department name");

            var newDpartment = Console.ReadLine();

            repo.InsertDepartment(newDpartment);

            var departments = repo.GetAllDepartments();

            foreach(var department in departments)
            {
                Console.WriteLine(department);
            }
            var repo2 = new DapperProductRepository(conn);
            var products = repo2.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name} {prod.Price}{prod.CategoryID}");
            }

            Console.WriteLine("What is the name of your new product?");
            var productName = Console.ReadLine();

            Console.WriteLine("What is the price?");
            var productPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the category ID? ");
            var productID = int.Parse(Console.ReadLine());

            repo2.CreateProduct(productName, productPrice, productID);
            products = repo2.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{productName}{productPrice}{productID}");
            }
        }
    }
}
