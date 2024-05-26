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
                    return totalValue = PizzaManager.GetToppingPrice(topping);
                }
            }
        }

        //-------------------------------------詳細用---------------------------------------------


        public string DetaillName => throw new System.NotImplementedException();

        public int DetaillValue => throw new System.NotImplementedException();
    }
}
