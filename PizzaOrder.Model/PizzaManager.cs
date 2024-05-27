using System.Collections.Generic;
using System.Linq;

namespace PizzaOrder.Model
{
    public class PizzaManager
    {
        private List<Pizza> _pizzasList;
        private List<Topping> _toppingsList;
        private List<Order> _orders;

        public PizzaManager()
        {
            // メニューを初期化
            _pizzasList = new List<Pizza>
            {
                new Pizza("マルゲリータ", 800, new List<Topping> { new Topping("トマトソース", 0), new Topping("モッツァレラ", 0), new Topping("バジル", 0) }),
                new Pizza("シーフード", 1200, new List<Topping> { new Topping("エビ", 0), new Topping("イカ", 0), new Topping("ホタテ", 0) })
            };

            _toppingsList = new List<Topping>
            {
                new Topping("バジル", 100),
                new Topping("ホタテ", 150)
            };

            _orders = new List<Order>();
        }

        public void AddOrder(Pizza pizza, List<Topping> additionalToppings)
        {
            var order = new Order(pizza, additionalToppings);
            _orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        // 追加課題の機能
        public void ModifyOrder(Order order, List<Topping> newToppings)
        {
            order.UpdateToppings(newToppings);
        }

        public void CheckAndAutoCorrectOrder(Order order)
        {
            // シーフードピザにホタテとバジルを追加した場合のチェック
            if (order.Pizza.Name == "シーフード" && order.AdditionalToppings.Exists(t => t.Name == "ホタテ") && order.AdditionalToppings.Exists(t => t.Name == "バジル"))
            {
                var newPizza = _pizzasList.First(p => p.Name == "ペスカトーレ");
                order.UpdatePizza(newPizza);
            }
        }
    }
}
