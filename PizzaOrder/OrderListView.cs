using PizzaOrder.Model;
using System;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class OrderListView : Form
    {
        public PizzaBase ResultPizza { get; private set; }

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

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //listView2.ItemCheck -= listView1_ItemCheck; // イベントを一時的に解除
            //listView2.Items[0].Checked = true; // Item 2をチェック状態にする
            //listView2.ItemCheck += listView1_ItemCheck; // イベントを再度追加
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //特定のアイテムのチェック状態変更を無効にする
            //if (e.Index == 0 && listView2.Items[e.Index].Checked)
            //{
            //    e.NewValue = CheckState.Checked; // チェック状態を維持
            //}
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // イベントを一時的に解除
            listView2.ItemChecked -= listView2_ItemChecked;

            // Item 2を常にチェック状態にする
            if (e.Item.Checked && e.Item.Index == 0)
            {
                listView2.Items[0].Checked = true;
                listView2.Items[1].Checked = false;

            }
            else if (e.Item.Index == 1 && e.Item.Checked)
            {
                listView2.Items[1].Checked = true;
                listView2.Items[0].Checked = false;

            }
            else
            {
                listView2.Items[0].Checked = false;
                listView2.Items[1].Checked = false;
            }

            // イベントを再度追加
            listView2.ItemChecked += listView2_ItemChecked;
        }

        private void listView2_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // 特定のアイテムのチェック状態変更を無効にする
            if (e.Item.Index == 0 && !e.Item.Checked)
            {
                e.Item.Checked = true; // チェック状態を維持
            }
            else if (e.Item.Index == 1 && !e.Item.Checked)
                e.Item.Checked = true;
        }
    }
}
