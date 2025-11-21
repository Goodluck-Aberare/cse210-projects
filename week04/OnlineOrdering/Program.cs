using System;
using Models;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Dallas", "TX", "USA");
        Customer customer1 = new Customer("Goodluck Aberare", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Keyboard", "K100", 25.99, 2));
        order1.AddProduct(new Product("Mouse", "M200", 15.50, 1));

        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.TotalCost()}");
    }
}
