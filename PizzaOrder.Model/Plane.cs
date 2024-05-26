using System.Collections.Generic;

namespace PizzaOrder.Model
{
    public class Plane : Pizza, IMenuItem
    {
        private List<Topping> _toppings;

        // コンストラクタでトッピングを受け取る
        public Plane(List<Topping> toppings)
        {
            _toppings = toppings;
        }



        //------------------------------------注文リスト用--------------------------------------
        public override PizzaMenu OrderedName => PizzaMenu.プレーン;

        public override int GetTotalValue()
        {
            int totalValue = PizzaManager.GetPizzaPrice(PizzaMenu.プレーン);
            foreach (var topping in _toppings)
            {
                // チーズはプレーンピザに含まれているため、加算しない
                if (topping != Topping.チーズ && topping != Topping.トマト)
                {
                    totalValue += PizzaManager.GetToppingPrice(topping);
                }
            }
            return totalValue;
        }


        //-------------------------------------詳細用---------------------------------------------

        public List<string> DetailNameList()
        {
            var list = new List<string>();

            list.Add(PizzaMenu.プレーン.ToString());
            foreach (Topping topping in _toppings)
            {
                list.Add(topping.ToString());
            }
            return list;
        }

        public List<int> DetailValueList()
        {
            var values = new List<int>();

            values.Add(PizzaManager.GetPizzaPrice(PizzaMenu.プレーン));
            foreach (var topping in _toppings)
            {
                if (topping != Topping.チーズ && topping != Topping.トマト)
                {
                    values.Add(PizzaManager.GetToppingPrice(topping));
                }
                else
                {
                    values.Add(0);
                }
            }

            return values;
        }


    }
}
