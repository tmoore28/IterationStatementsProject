using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyPractices1
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
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Please enter a new Department name.");

            var newDepartment = Console.ReadLine();

            repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
            }
            var repo1 = new DapperProductRepo(conn);
            var products = repo1.GetAllProducts();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name}, {prod.Price}, {prod.CategoryID}");
            }
            Console.WriteLine();

            Console.WriteLine("What is the Name of your product?");
            var prodName = Console.ReadLine();

            Console.WriteLine("What is the Price?");
            var prodPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("What is the Category ID");
            var prodCat = int.Parse(Console.ReadLine());

            repo1.CreateProduct(prodName, prodPrice, prodCat);

            products = repo1.GetAllProducts();

            Console.WriteLine("Please enter the product ID to update");
            var newID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a new price to update your product");
            var newPrice = double.Parse(Console.ReadLine());


            repo1.UpdateProduct(newID, newPrice);

            products = repo1.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.Name}{prod.Price}{prod.CategoryID}");
            }
            Console.WriteLine("PLease enter a product ID to delete");
            newID = int.Parse(Console.ReadLine());

            repo1.DeleteProduct(newID);

            products = repo1.GetAllProducts();

            foreach (var prod in products)
            {
                Console.WriteLine($"{ prod.Name}{ prod.Price}{ prod.CategoryID}{prod.ProductID}");
            }

        }
    }
}
