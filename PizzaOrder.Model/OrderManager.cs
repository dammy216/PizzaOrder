using PizzaOrder.Model.Pizzas;
using PizzaOrder.Model.Toppings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrder.Model
{
    public class OrderManager
    {
        private List<Order> _orders = new List<Order>();

        public List<Order> Orders { get { return _orders; } }


        public void AddOrder(PizzaBase pizza, List<ToppingBase> additionalToppings)
        {
            var order = new Order(pizza, additionalToppings);
            _orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
        }

        //public List<Order> GetOrders()
        //{
        //    return _orders;
        //}

        //// 追加課題の機能
        //public void ModifyOrder(Order order, List<ToppingBase> newToppings)
        //{
        //    order.UpdateToppings(newToppings);
        //}

        public PizzaBase CreatePizza(string name)
        {
            if (!Enum.TryParse(name, out PizzaNames pizzaNames))
                throw new Exception();

            switch (pizzaNames)
            {
                case PizzaNames.プレーン:
                    return new Plain();
                case PizzaNames.シーフード:
                    return new SeaFood();
                case PizzaNames.マルゲリータ:
                    return new Margherita();
                default:
                    throw new ArgumentException();
            }
        }

        public List<ToppingBase> CreateTopping(string name)
        {
            var toppings = new List<ToppingBase>();

            if (!Enum.TryParse(name, out ToppingNames toppingNames))
                throw new Exception();

            switch (toppingNames)
            {
                case ToppingNames.チーズ:
                    toppings.Add(new Cheese());
                    break;
                case ToppingNames.シーフードミックス:
                    toppings.Add(new SeaFoodMix());
                    break;
                case ToppingNames.ホタテ:
                    toppings.Add(new Scallops());
                    break;
                case ToppingNames.トマト:
                    toppings.Add(new Tomato());
                    break;
                case ToppingNames.ツナ:
                    toppings.Add(new Tuna());
                    break;
                case ToppingNames.モッツァレラチーズ:
                    toppings.Add(new MozzarellaCheese());
                    break;
                case ToppingNames.バジル:
                    toppings.Add(new Basil());
                    break;
                default:
                    throw new ArgumentException();
            }
            return toppings;
        }

        public string[] GetOrderListViewItem(Order order)
        {
            string[] orders = { order.Pizza.Name, order.CalculateSubTotalPrice().ToString() };
            return orders;
        }

        public string[] GetDetailListViewItem(IMenuItem menu)
        {
            string[] menus = { menu.Name, menu.Price.ToString() };
            return menus;
        }

        public PizzaBase ReturnPizza_FromSelectedTopping(List<string> selectedToppings)
        {
            List<PizzaBase> allPizzas = new List<PizzaBase> { new Plain(), new SeaFood(), new Margherita() };

            foreach (var pizza in allPizzas)
            {
                if (pizza.DefaultToppings.All(topping => selectedToppings.Contains(topping.Name)))
                {
                    return pizza;
                }
            }
            return null;
        }
    }
}
