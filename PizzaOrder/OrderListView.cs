using PizzaOrder.Model;
using PizzaOrder.Model.Pizzas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PizzaOrder
{
    public partial class OrderListView : Form
    {
        private OrderManager _orderManager = new OrderManager();
        private List<string> _defaultToppings = new List<string>();
        private List<string> _addedToppings = new List<string>();
        public PizzaBase ResultPizza { get; set; }
        public List<ToppingBase> ResultToppings { get; set; } = new List<ToppingBase>();

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
            foreach (ListViewItem item in pizzaList.CheckedItems)
            {
                ResultPizza = _orderManager.CreatePizza(item.Text);
            }
            foreach (ListViewItem item in toppingList.CheckedItems)
            {
                ResultToppings.AddRange(_orderManager.CreateTopping(item.Text));
            }
            DialogResult = DialogResult.OK;
        }

        private void pizzaList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                toppingList.Enabled = true;
                _defaultToppings.Clear();

                foreach (ListViewItem item in pizzaList.Items)
                {
                    if (item.Index != e.Item.Index)
                    {
                        item.Checked = false;
                    }
                }

                ToppingList_CheckChanged(_orderManager.CreatePizza(e.Item.Text));

                okButton.Enabled = true;
                toppingList.Enabled = true;
            }
            else
            {
                ToppingList_false();
            }
        }

        private void ToppingList_false()
        {
            okButton.Enabled = false;
            _defaultToppings.Clear();
            toppingList.Enabled = false;

            foreach (ListViewItem toppingItem in toppingList.Items)
            {
                toppingItem.Checked = false;
                toppingItem.BackColor = SystemColors.Window;
            }
        }

        private void ToppingList_CheckChanged(PizzaBase pizza)
        {
            foreach (ListViewItem toppingItem in toppingList.Items)
            {
                toppingItem.Checked = false;
                toppingItem.BackColor = SystemColors.Window;

                if (_addedToppings.Any(topping => topping == toppingItem.Text))
                {
                    toppingItem.Checked = true;
                }

                if (pizza.DefaultToppings.Any(topping => topping.Name == toppingItem.Text))
                {
                    toppingItem.Checked = true;
                    toppingItem.BackColor = SystemColors.ControlDark;
                    _defaultToppings.Add(toppingItem.Text);
                }
            }
        }

        private void toppingList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_defaultToppings.Contains(e.Item.Text))
            {
                e.Item.Checked = true;
            }

            var selectedTopping = new List<string>();
            foreach (ListViewItem toppingItem in toppingList.CheckedItems)
            {
                selectedTopping.Add(toppingItem.Text);
            }

            _addedToppings = selectedTopping.Except(_defaultToppings).ToList();

            CheckAndAutoSelectPizza(selectedTopping);
        }

        private void CheckAndAutoSelectPizza(List<string> selectedToppings)
        {
            List<PizzaBase> allPizzas = new List<PizzaBase> { new Margherita() /* 他のピザも同様に追加 */ };

            foreach (var pizza in allPizzas)
            {
                if (pizza.DefaultToppings.Select(t => t.Name).OrderBy(t => t).SequenceEqual(selectedToppings.OrderBy(t => t)))
                {
                    MessageBox.Show($"選択されたトッピングにより、注文内容が {pizza.Name} に変更されました。");

                    // 現在のピザの選択をリセット
                    foreach (ListViewItem item in pizzaList.Items)
                    {
                        item.Checked = false;
                    }

                    // 新しいピザを選択状態に
                    foreach (ListViewItem item in pizzaList.Items)
                    {
                        if (item.Text == pizza.Name)
                        {
                            item.Checked = true;
                            break;
                        }
                    }

                    // 新しいピザのデフォルトトッピングを含むリストを生成
                    var newPizzaToppings = pizza.DefaultToppings.Select(t => t.Name).ToList();
                    var allSelectedToppings = newPizzaToppings.Union(_addedToppings).ToList();

                    // トッピングリストをリセットし、保持している追加トッピングをチェック
                    ToppingList_CheckChanged(pizza);

                    // 追加トッピングを再チェック
                    foreach (ListViewItem toppingItem in toppingList.Items)
                    {
                        if (allSelectedToppings.Contains(toppingItem.Text))
                        {
                            toppingItem.Checked = true;
                        }
                    }

                    return;
                }
            }
        }
    }
}