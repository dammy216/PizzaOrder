namespace PizzaOrder.Model
{
    public class DefaultTopping : ToppingBase
    {
        private string _name;

        public override string Name => _name;

        public override int Price => 0;

        public DefaultTopping(string name)
        {
            _name = name;
        }
    }
}
