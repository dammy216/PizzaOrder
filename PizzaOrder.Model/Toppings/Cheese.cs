namespace PizzaOrder.Model
{
    public class Cheese : ToppingBase
    {
        public override string Name => ToppingNames.チーズ.ToString();

        public override int Price => 100;
    }
}
