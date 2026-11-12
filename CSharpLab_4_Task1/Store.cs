namespace CSharpLab_4_Task1
{ 
class Store
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Profit { get; set; } = 0;

    public void Sell(Customer customer, Product product)
    {
        if (product.Quantity > 0 && customer.Money >= product.Price)
        {
            customer.Buy(product);
            Profit += product.Price;

            Console.WriteLine(
                $"Картка {customer.CardNumber}: куплено {product.Name}, ціна {product.Price}");
        }
    }
}

}
