namespace CSharpLab_4_Task1
{
    internal class Customer
    {
        public int CardNumber { get; set; }
        public int Money { get; set; }
        public int PurchaseCount { get; set; }
        public int TotalSpent { get; set; }

        public Customer(int cardNumber, int money)
        {
            CardNumber = cardNumber;
            Money = money;
            PurchaseCount = 0;
            TotalSpent = 0;
        }

        public void Buy(Product product)
        {
            Money -= product.Price;
            TotalSpent += product.Price;
            PurchaseCount++;

            product.Quantity--;
        }
    }
}
