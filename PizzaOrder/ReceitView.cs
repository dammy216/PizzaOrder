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
    }
}
