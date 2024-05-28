using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Order
    {
        public PizzaBase Pizza { get; private set; }
        public List<ToppingBase> AdditionalToppings { get; private set; }
        public HashSet<IMenuItem> MenuItems { get; private set; }

        public Order(PizzaBase pizza, List<ToppingBase> additionalToppings)
        {
            Pizza = pizza;
            AdditionalToppings = additionalToppings;
            UnionToppings();
        }

        public void UpdateToppings(List<ToppingBase> newToppings)
        {
            AdditionalToppings = newToppings;
            UnionToppings();
        }

        public void UpdatePizza(PizzaBase newPizza)
        {
            Pizza = newPizza;
            AdditionalToppings.Clear(); // ピザが変更された場合、追加トッピングをリセット
            UnionToppings();
        }

        public void UnionToppings()
        {
            MenuItems.Clear();
            MenuItems.Add(Pizza);
            foreach (var topping in Pizza.DefaultToppings)
            {
                MenuItems.Add(topping);
            }

            foreach (var topping in AdditionalToppings)
            {
                MenuItems.Add(topping);
            }
        }

        public int CalculateSubTotalPrice()
        {
            int price = 0;
            foreach (var item in MenuItems)
            {
                price += item.Price;
            }

            return price;
        }
    }
}
