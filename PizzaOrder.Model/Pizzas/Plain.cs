using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Plain : PizzaBase
    {
        public override string Name => PizzaNames.プレーン.ToString();

        public override int Price => 1200;

        public override List<DefaultTopping> DefaultToppings { get; } = new List<DefaultTopping> { new DefaultTopping("トマト"), new DefaultTopping("チーズ") };
    }
}

