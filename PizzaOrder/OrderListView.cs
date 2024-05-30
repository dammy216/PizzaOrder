using System;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class OrderListView : Form
    {
        public OrderListView()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
        }

        public void UpdateListView()
        {
            listView.Items.Clear();
            foreach (var pizza in _pizzaManager.PizzaList)
            {
                var items = _pizzaManager.GetListViewItems(pizza); // GetListViewItems() メソッドを呼び出す
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    ListViewItem listViewItem = new ListViewItem(new[] { items[i, 0], items[i, 1] }); // 2次元配列の各要素を1行としてリストビューに追加
                    listView.Items.Add(listViewItem);
                }
            }
            totalLabel.Text = $"TotalArea:{AreaCalculator.CalculateTotalArea(listView).ToString()}";
        }
    }
}
