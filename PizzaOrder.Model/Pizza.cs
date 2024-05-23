namespace PizzaOrder.Model
{
    public abstract class Pizza
    {
        public abstract PizzaMenu OrderedName { get; }
        public abstract int GetTotalValue();
    }
}
