namespace PizzaOrder.Model
{
    public class Topping : IMenuItem
    {
        public string Name { get; }
        public int Price { get; }

        public Topping(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
