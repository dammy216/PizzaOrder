using System.Collections.Generic;

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

        public List<Order> GetOrders()
        {
            return _orders;
        }

        // 追加課題の機能
        public void ModifyOrder(Order order, List<ToppingBase> newToppings)
        {
            order.UpdateToppings(newToppings);
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
        public string[,] GetListViewItems(Pizza pizza)
        {
            var names = (pizza as IMenuItem).DetailNameList();
            var price = (pizza as IMenuItem).DetailValueList();

            string[,] menuItem = new string[names.Count, 2]; // namesの数だけ行を持ち、2列を持つ2次元配列
            for (int i = 0; i < names.Count; i++)
            {
                menuItem[i, 0] = names[i]; // 1列目にはnamesを設定
                menuItem[i, 1] = price[i].ToString(); // 2列目にはvaluesを設定
            }
            return menuItem;
        }

        //public void CheckAndAutoCorrectOrder(Order order)
        //{
        //    // シーフードピザにホタテとバジルを追加した場合のチェック
        //    if (order.Pizza.Name == "シーフード" && order.AdditionalToppings.Exists(t => t.Name == "ホタテ") && order.AdditionalToppings.Exists(t => t.Name == "バジル"))
        //    {
        //        var newPizza = _pizzasList.First(p => p.Name == "ペスカトーレ");
        //        order.UpdatePizza(newPizza);
        //    }
        //}
    }
}
