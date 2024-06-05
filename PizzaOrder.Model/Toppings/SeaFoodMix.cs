namespace PizzaOrder.Model.Toppings
{
    public class SeaFoodMix : ToppingBase
    {
        public override string Name => ToppingNames.シーフードミックス.ToString();

        public override int Price => 500;
    }
}
