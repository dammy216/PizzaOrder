using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Order
    {
        public Pizza Pizza { get; private set; }
        public List<Topping> AdditionalToppings { get; private set; }

        public Order(Pizza pizza, List<Topping> additionalToppings)
        {
            Pizza = pizza;
            AdditionalToppings = additionalToppings;
        }

        public void UpdateToppings(List<Topping> newToppings)
        {
            AdditionalToppings = newToppings;
        }

        public void UpdatePizza(Pizza newPizza)
        {
            Pizza = newPizza;
            AdditionalToppings.Clear(); // ピザが変更された場合、追加トッピングをリセット
        }

        public int CalculateTotalPrice()
        {
            int price = Pizza.Price;
            foreach (var topping in Pizza.DefaultToppings)
            {
                price += topping.Price;
            }

            foreach (var topping in AdditionalToppings)
            {
                price += topping.Price;
            }

            return price;
        }
    }
}
