using System;
using System.Collections.Generic;
using System.Linq;
using DNP2.Assignment4.CustomerModel;

namespace CustomerQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer kim = CreateCustomer("Kim Foged", "Beder", new[]
            {
                CreateOrder(CreateProduct("Milk", 15), 3),
                CreateOrder(CreateProduct("Butter", 20), 3),
                CreateOrder(CreateProduct("Bread", 10), 3)
            });
            Customer ib = CreateCustomer("Ib Havn", "Horsens", new[]
            {
                CreateOrder(CreateProduct("Milk", 15), 4),
                CreateOrder(CreateProduct("Butter", 20), 4),
                CreateOrder(CreateProduct("Bread", 10), 4),
                CreateOrder(CreateProduct("Cacao", 30), 4)
            });
            Customer rasmus = CreateCustomer("Rasmus Bjerner", "Horsens", new[]
            {
                CreateOrder(CreateProduct("Juice", 15), 1)
            });
            IEnumerable<Customer> customers = new[] { kim, ib, rasmus };


            Console.WriteLine("Printing all customers:");
            PrintCustomerNameAndCity(customers);

            Console.WriteLine("Printing all names of customers from Horsens:");
            PrintAllCustomersFromHorsens(customers);

            Console.WriteLine("Printing number of Ib's orders:");
            PrintOrderCountForIb(customers);

            Console.WriteLine("Customers that have bought milk:");
            PrintNamesOfCustomersBuyingMilk(customers);

            Console.WriteLine("Customer name and price of all products:");
            PrintNamesAndPriceOfProducts(customers);

            Console.WriteLine("Total cost of all products:");
            PrintTotalCostOfAllOrders(customers);
        }

        #region Helpers

        private static Product CreateProduct(string name, decimal price)
        {
            return new Product
            {
                Name = name,
                Price = price
            };
        }

        private static Customer CreateCustomer(string name, string city, Order[] orders)
        {
            return new Customer
            {
                Name = name,
                City = city,
                Orders = orders
            };
        }

        private static Order CreateOrder(Product product, int quantity)
        {
            return new Order
            {
                Product = product,
                Quantity = quantity
            };
        }

        #endregion

        #region Queries

        private static void PrintCustomerNameAndCity(IEnumerable<Customer> customers)
        {
            var namesAndCities = customers.Select(customer => new { customer.Name, customer.City });
            Console.WriteLine(string.Join("\n", namesAndCities));
            Console.WriteLine();
        }

        private static void PrintAllCustomersFromHorsens(IEnumerable<Customer> customers)
        {
            var customersFromHorsens = customers.Where(customer => string.Equals(customer.City, "Horsens"));
            var names = customersFromHorsens.Select(customer => customer.Name);
            Console.WriteLine(string.Join("\n", names));
            Console.WriteLine();
        }

        private static void PrintOrderCountForIb(IEnumerable<Customer> customers)
        {
            var ibOrderCount = customers.First(customer => string.Equals(customer.Name, "Ib Havn")).Orders.Length;
            Console.WriteLine($"Ib has {ibOrderCount} orders");
            Console.WriteLine();
        }

        private static void PrintNamesOfCustomersBuyingMilk(IEnumerable<Customer> customers)
        {
            var customersBuyingMilk = customers.Where(customer => customer.Orders
                                                .Any(order => string.Equals(order.Product.Name, "Milk")));
            var namesOfCustomers = customersBuyingMilk.Select(customer => customer.Name);
            Console.WriteLine(string.Join("\n", namesOfCustomers));
            Console.WriteLine();
        }

        private static void PrintNamesAndPriceOfProducts(IEnumerable<Customer> customers)
        {
            var namesAndProductSum = customers.ToDictionary(customer => customer.Name, customer => customer.Orders
                                                .Select(order => order.Product)
                                                .Sum(product => product.Price));
            Console.WriteLine(string.Join("\n", namesAndProductSum));
            Console.WriteLine();
        }

        private static void PrintTotalCostOfAllOrders(IEnumerable<Customer> customers)
        {
            var totalCost = customers.Sum(customer => customer.Orders
                                    .Select(order => order.Product)
                                    .Sum(product => product.Price));
            Console.WriteLine(totalCost);
        }

        #endregion
    }
}
