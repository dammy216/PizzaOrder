namespace PizzaOrder.Model.Toppings
{
    public class MozzarellaCheese : ToppingBase
    {
        public override string Name => ToppingNames.モッツァレラチーズ.ToString();

        public override int Price => 300;
    }
}
