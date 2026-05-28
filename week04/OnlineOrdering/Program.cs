using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Console.WriteLine();

        // 2 address objects
        Address address1 = new Address("1428 elm street", "seattle", "washington state", "usa");
        Address address2 = new Address("221B baker street", "london", "greater london", "gb");

        // 2 customer objects
        Customer customer1 = new Customer("arthur blake", address1);
        Customer customer2 = new Customer("winston a. miller", address2);

        //Products objects
        Product product1 = new Product("mechanical keyboard", "KB-9902", 85.0f, 1);
        Product product2 = new Product("wireless mouse", "MS-4412", 45.0f, 1);
        Product product3 = new Product("desk mat", "DM-1050", 15.7f, 2);

        Product product4 = new Product("cotton embroidery floss(pack of 50)", "EF-3320", 15.0f, 3);
        Product product5 = new Product("Embroidery Hoop Set", "EH-7710", 24.50f, 1);

        //Order Objects
        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        //Adding products to their respective Order Class
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        //Displaying
        foreach (var order in new[] { order1, order2 })
        {
            Console.WriteLine();
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total: ${order.CalculateOrderTotal()}");
        }

    }
}