namespace PizzaOrder.Model
{
    public abstract class ToppingBase : IMenuItem
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
    }
}
