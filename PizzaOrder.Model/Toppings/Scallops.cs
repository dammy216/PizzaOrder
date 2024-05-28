namespace PizzaOrder.Model
{
    public class Scallops : ToppingBase
    {
        public override string Name => ToppingNames.ホタテ.ToString();

        public override int Price => 500;
    }
}
