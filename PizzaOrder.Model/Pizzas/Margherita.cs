using System.Collections.Generic;

namespace PizzaOrder.Model.Pizzas
{
    public class Margherita : PizzaBase
    {
        public override string Name => PizzaNames.マルゲリータ.ToString();

        public override int Price => 1500;

        public override List<DefaultTopping> DefaultToppings { get; } = new List<DefaultTopping> { new DefaultTopping("トマト"), new DefaultTopping("チーズ"), new DefaultTopping("モッツァレラチーズ"), new DefaultTopping("バジル") };
    }
}
