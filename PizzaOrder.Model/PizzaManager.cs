using System;
using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class PizzaManager
    {
        private List<Pizza> _pizzaList = new List<Pizza>();
        public List<Pizza> PizzaList { get { return _pizzaList; } }
        private Pizza _resultPizza;

        //ピザの値段を返す
        public static int GetPizzaPrice(PizzaMenu pizza)
        {
            switch (pizza)
            {
                case PizzaMenu.プレーン:
                    return 1200;
                case PizzaMenu.マルゲリータ:
                    return 1500;
                case PizzaMenu.シーフード:
                    return 1400;
                case PizzaMenu.ペスカトーレ:
                    return 1800;
                case PizzaMenu.パンピーノ:
                    return 1600;
                default:
                    throw new NotImplementedException();
            }
        }

        //トッピングの値段を返す
        public static int GetToppingPrice(Topping topping)
        {
            switch (topping)
            {
                case Topping.チーズ:
                    return 100;
                case Topping.フライドガーリック:
                    return 150;
                case Topping.モッツァレラチーズ:
                    return 300;
                case Topping.シーフードミックス:
                    return 500;
                case Topping.ホタテ:
                    return 500;
                case Topping.バジル:
                    return 100;
                case Topping.トマト:
                    return 250;
                case Topping.ツナ:
                    return 250;
                case Topping.コーン:
                    return 250;
                case Topping.ベーコン:
                    return 250;
                default:
                    throw new NotImplementedException();
            }
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

    }
}
