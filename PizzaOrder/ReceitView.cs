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

        private void orderButton_Click(object sender, System.EventArgs e)
        {
            OrderListView orderList = new OrderListView();
            if (orderList.ShowDialog() == DialogResult.OK)
            {
                //var area = orderList.ResultArea;
                //_orderManager.AddOrder(area); //本当のモデルに追加
                //UpdateListView();
            }
        }

        public void UpdateListView()
        {
            orderListView.Items.Clear();
            foreach (var order in _orderManager.Orders)
            {
                //注文メニュー用
                ListViewItem orderItem = new ListViewItem(_orderManager.GetOrderListViewItem(order));
                orderListView.Items.Add(orderItem);

                //詳細用
                foreach (var menu in order.MenuItems)
                {
                    ListViewItem menuItem = new ListViewItem(_orderManager.GetDetailListViewItem(menu));
                    detailListView.Items.Add(menuItem);
                }
            }
            totalLabel.Text = $"TotalArea:{AreaCalculator.CalculateTotalArea(listView).ToString()}";
        }
    }
}
