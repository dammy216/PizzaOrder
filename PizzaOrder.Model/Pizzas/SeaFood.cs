using System.Collections.Generic;

namespace PizzaOrder.Model.Pizzas
{
    public class SeaFood : PizzaBase
    {
        public override string Name => PizzaNames.シーフード.ToString();

        public override int Price => 1400;

        public override List<DefaultTopping> DefaultToppings { get; } = new List<DefaultTopping> { new DefaultTopping("チーズ"), new DefaultTopping("シーフードミックス") };
    }
}
