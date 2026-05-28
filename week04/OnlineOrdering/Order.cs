public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public float CalculateOrderTotal()
    {
        float total = 0;
        foreach (var product in _products)
        {
            total += product.CalculateTotalCost();
        }

        if (_customer.LivesInUSA() == true)
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        List<string> strings = new List<string>();

        foreach (var product in _products)
        {
            string productName = product.GetProductName();
            string id = product.GetProductID();

            strings.Add($"Product: {productName}    ID: {id}");
        }

        return string.Join(Environment.NewLine, strings);
    }

    public string GetShippingLabel()
    {
        return _customer.GetName() + Environment.NewLine + _customer.GetAddressObject().GetAddress();
    }

}