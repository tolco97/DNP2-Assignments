using System;
using System.Collections.Generic;
using System.Linq;
using DNP2.Assignment4.CustomerModel;
using DNP2.Helpers.Common;

namespace DNP2.Assignment4.CustomerQueries
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Customer kim = CreateCustomer("Kim Foged", "Beder", new[]
            {
                CreateOrder(CreateProduct("Milk", 15), 1),
                CreateOrder(CreateProduct("Butter", 20), 1),
                CreateOrder(CreateProduct("Bread", 10), 1)
            });
            Customer ib = CreateCustomer("Ib Havn", "Horsens", new[]
            {
                CreateOrder(CreateProduct("Milk", 15), 1),
                CreateOrder(CreateProduct("Butter", 20), 1),
                CreateOrder(CreateProduct("Bread", 10), 1),
                CreateOrder(CreateProduct("Cacao", 30), 1)
            });
            Customer rasmus = CreateCustomer("Rasmus Bjerner", "Horsens", new[]
            {
                CreateOrder(CreateProduct("Juice", 15), 1)
            });
            IEnumerable<Customer> customers = new[] { kim, ib, rasmus };


            Console.WriteLine("Printing all customers:");
            PrintAllCustomerNamesAndCities(customers);

            Console.WriteLine("Printing all names of customers from Horsens:");
            PrintAllCustomersFromHorsens(customers);

            Console.WriteLine("Printing number of Ib's orders:");
            PrintOrderCountOfIb(customers);

            Console.WriteLine("Customers that have bought milk:");
            PrintNamesOfCustomersBuyingMilk(customers);

            Console.WriteLine("Customer name and price of all their products:");
            PrintCustomerNamesAndTotalPriceOfProducts(customers);

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

        private static void PrintAllCustomerNamesAndCities(IEnumerable<Customer> allCustomers)
        {
            allCustomers.Select(customer => new { customer.Name, customer.City })
                        .PrintAll();

            // Alternative approach with tuples
            allCustomers.Select(customer => (customer.Name, customer.City))
                        .PrintAll();

            // Alternative approach with Linq query expressions
            (from customer in allCustomers
            select new { customer.Name, customer.City })
                        .PrintAll();
        }

        private static void PrintAllCustomersFromHorsens(IEnumerable<Customer> allCustomers)
        {
            allCustomers.Where(customer => string.Equals(customer.City, "Horsens"))
                        .Select(customer => customer.Name)
                        .PrintAll();

            // Alternative approach with Linq query expressions
            (from customer in allCustomers
            where string.Equals(customer.City, "Horsens")
            select customer.Name)
                        .PrintAll();
        }

        private static void PrintOrderCountOfIb(IEnumerable<Customer> allCustomers)
        {
            var orderCount = allCustomers.First(customer => string.Equals(customer.Name, "Ib Havn")).Orders
                                         .Length;
            Console.WriteLine($"Ib has {orderCount} orders\n");

            // Alternative approach with Linq .Count()
            orderCount = allCustomers.First(customer => string.Equals(customer.Name, "Ib Havn")).Orders
                                         .Count();
            Console.WriteLine($"Ib has {orderCount} orders\n");
        }

        private static void PrintNamesOfCustomersBuyingMilk(IEnumerable<Customer> allCustomers)
        {
            allCustomers.Where(customer => customer.HasOrderedProduct("Milk"))
                        .Select(customer => customer.Name)
                        .PrintAll();

            // Alternative approach with Linq query expressions 
            (from customer in allCustomers
            where customer.HasOrderedProduct("Milk")
            select customer.Name)
                        .PrintAll();
        }

        private static void PrintCustomerNamesAndTotalPriceOfProducts(IEnumerable<Customer> allCustomers)
        {
            allCustomers.Select(customer => new { customer.Name, customer.OrdersPrice })
                        .PrintAll();

            // Alternative approach with tuples
            allCustomers.Select(customer => (customer.Name, customer.OrdersPrice))
                        .PrintAll();

            // Alternative approach with Linq query expressions 
            (from customer in allCustomers
            select new { customer.Name, customer.OrdersPrice })
                        .PrintAll();
        }

        private static void PrintTotalCostOfAllOrders(IEnumerable<Customer> allCustomers)
        {
            var totalCost = allCustomers.Sum(customer => customer.OrdersPrice);
            Console.WriteLine($"{totalCost} DKK");
        }

        #endregion
    }
}
