namespace PizzaOrder.Model
{
    public class Tomato : ToppingBase
    {
        public override string Name => ToppingNames.トマト.ToString();

        public override int Price => 250;
    }
}
