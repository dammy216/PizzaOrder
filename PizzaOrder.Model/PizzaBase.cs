using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public abstract class PizzaBase : IMenuItem
    {
        public abstract string Name { get; }
        public abstract int Price { get; }
        public abstract List<DefaultTopping> DefaultToppings { get; }
    }
}
