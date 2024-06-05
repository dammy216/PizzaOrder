using PizzaOrder.Model;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class OrderView : Form
    {
        private OrderManager _orderManager = new OrderManager();
        private Order _order;

        public OrderView()
        {
            InitializeComponent();
        }

        private void UpdateOrderListView()
        {
            orderListView.Items.Clear();
            foreach (var order in _orderManager.Orders)
            {
                //リストビューの項目数とstring配列の長さが同じであればそのまま表示できる
                ListViewItem item = new ListViewItem(_orderManager.GetOrderListViewItem(order));  //表示用のリストでリストビューを作成
                orderListView.Items.Add(item);
            }
        }

        private void orderButton_Click(object sender, System.EventArgs e)
        {
            OrderListView orderList = new OrderListView();
            if (orderList.ShowDialog() == DialogResult.OK)
            {
                _orderManager.AddOrder(orderList.ResultPizza, orderList.ResultToppings); //本当のモデルに追加
                UpdateOrderListView();
            }
        }
    }
}
