using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Pizza : IMenuItem
    {
        public string Name { get; }
        public int Price { get; }
        public List<Topping> DefaultToppings { get; }

        public Pizza(string name, int price, List<Topping> defaultToppings)
        {
            Name = name;
            Price = price;
            DefaultToppings = defaultToppings;
        }
    }
}
