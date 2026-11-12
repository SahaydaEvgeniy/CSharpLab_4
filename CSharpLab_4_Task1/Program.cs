using CSharpLab_4_Task1;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Random random = new Random();

    Store store = new Store();

store.Products.Add(new Product("Хліб", 30, 20));
store.Products.Add(new Product("Молоко", 45, 15));
store.Products.Add(new Product("Сир", 120, 10));
store.Products.Add(new Product("Масло", 90, 12));
store.Products.Add(new Product("Яблука", 50, 25));
store.Products.Add(new Product("М'ясо", 250, 8));
store.Products.Add(new Product("Сік", 60, 18));
store.Products.Add(new Product("Печиво", 40, 20));

Console.Write("Введіть кількість покупців: ");

if (!int.TryParse(Console.ReadLine(), out int count)
    || count <= 0 || count > 1000)
{
    Console.WriteLine("Помилка! Введіть число від 1 до 1000.");
    return;
}

List<Customer> customers = new List<Customer>();
HashSet<int> usedCards = new HashSet<int>();

for (int i = 0; i < count; i++)
{
    int card;

    do
    {
        card = random.Next(1, 1001);
    }
    while (!usedCards.Add(card));

    int money = random.Next(1000, 10001);

    customers.Add(new Customer(card, money));
}

Console.WriteLine("\nПочаток покупок!");

foreach (Customer customer in customers)
{
    Console.WriteLine(
        $"\nПокупець {customer.CardNumber}, гроші: {customer.Money}");

    while (true)
    {
        List<Product> available = new List<Product>();

        foreach (Product product in store.Products)
        {
            if (product.Quantity > 0 && customer.Money >= product.Price)
            {
                available.Add(product);
            }
        }

        if (available.Count == 0)
        {
            break;
        }

        Product selected = available[random.Next(available.Count)];

        store.Sell(customer, selected);
    }

    Console.WriteLine(
        $"Залишок: {customer.Money}, покупок: {customer.PurchaseCount}");
}

Customer mostPurchases = customers[0];
Customer mostSpent = customers[0];

foreach (Customer customer in customers)
{
    if (customer.PurchaseCount > mostPurchases.PurchaseCount)
    {
        mostPurchases = customer;
    }

    if (customer.TotalSpent > mostSpent.TotalSpent)
    {
        mostSpent = customer;
    }
}

Console.WriteLine("ПІДСУМКИ:");

Console.WriteLine("Прибуток магазину: " + store.Profit);

Console.WriteLine(
    $"Найбільше товарів купила картка: {mostPurchases.CardNumber}");

Console.WriteLine(
    $"Кількість товарів: {mostPurchases.PurchaseCount}");

Console.WriteLine(
    $"Найбільше грошей витратила картка: {mostSpent.CardNumber}");

Console.WriteLine(
    $"Витрачено грошей: {mostSpent.TotalSpent}");
