using System.Globalization;
public class Product
{
    private string _productName;
    private string _id;
    private float _price;
    private int _quantity;

    public Product(string name, string id, float price, int quantity)
    {
        name = name.ToLower();

        TextInfo txtInfo = new CultureInfo("en-US", false).TextInfo;

        _productName = txtInfo.ToTitleCase(name);
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    public float CalculateTotalCost()
    {
        return _price * _quantity;
    }

    public string GetProductName()
    {
        return _productName;
    }

    public string GetProductID()
    {
        return _id;
    }
}