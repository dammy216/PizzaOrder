namespace PizzaOrder.Model.Toppings
{
    public class Basil : ToppingBase
    {
        public override string Name => ToppingNames.バジル.ToString();

        public override int Price => 100;
    }
}
