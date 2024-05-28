namespace PizzaOrder.Model
{
    public class Tuna : ToppingBase
    {
        public override string Name => ToppingNames.ツナ.ToString();

        public override int Price => 250;
    }
}
