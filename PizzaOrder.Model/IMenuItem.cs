namespace PizzaOrder.Model
{
    public interface IMenuItem
    {
        PizzaMenu PizzaName { get; }
        int PizzaValue { get; }
    }
}
