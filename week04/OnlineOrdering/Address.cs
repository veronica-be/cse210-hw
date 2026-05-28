using System.Globalization;
// learned title case: https://learn.microsoft.com/es-es/%20dotnet/api/system.globalization.textinfo.totitlecase?view=netframework-2.0

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        street = street.ToLower();
        city = city.ToLower();
        state = state.ToLower();

        TextInfo txtInfo = new CultureInfo("en-US", false).TextInfo;

        _street = txtInfo.ToTitleCase(street);
        _city = txtInfo.ToTitleCase(city);
        _stateOrProvince = txtInfo.ToTitleCase(state);
        _country = country.ToUpper();
    }

    public bool IsUSA()
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public string GetAddress()
    {
        return _street + Environment.NewLine + _city + ", " + _stateOrProvince + Environment.NewLine + _country;
    }

}
