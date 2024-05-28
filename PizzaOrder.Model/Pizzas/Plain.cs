using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Plain : PizzaBase
    {
        public override string Name => PizzaNames.プレーン.ToString();

        public override int Price => 1200;

        public override List<ToppingBase> DefaultToppings { get; } = new List<ToppingBase> { new Tomato(), new Cheese() };
    }
}

