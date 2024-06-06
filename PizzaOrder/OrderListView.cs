using PizzaOrder.Model;
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
                toppingItem.BackColor = SystemColors.Window;

                if (pizza.DefaultToppings.Any(topping => topping.Name == toppingItem.Text))
                {
                    toppingItem.Checked = true;

                    toppingItem.BackColor = SystemColors.ControlDark;

                    _defaultToppings.Add(toppingItem.Text);
                }
            }
        }

        //トッピングにチェックが入った時の処理 
        private void toppingList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var selectedToppings = new List<string>();

            if (_defaultToppings.Contains(e.Item.Text))
            {
                e.Item.Checked = true;
            }

            foreach (ListViewItem toppingItem in toppingList.CheckedItems)
            {
                selectedToppings.Add(toppingItem.Text);
            }

            _addedToppings = selectedToppings.Except(_defaultToppings).ToList();
            CheckAndAutoSelectPizza(_orderManager.ReturnPizza_FromSelectedTopping(selectedToppings));
        }

        //トッピングチェック時にトッピングの内容からピザの変更をする処理 
        private void CheckAndAutoSelectPizza(PizzaBase pizza)
        {
            if (pizza == null)
                return;

            if (pizzaList.CheckedItems[0].Text == pizza.Name)
                return;

            var currentSubtotal = 0;

            if (int.TryParse(pizzaList.CheckedItems[0].Tag.ToString(), out int pizzaPrice))
                currentSubtotal = pizzaPrice;

            foreach (ListViewItem topping in toppingList.CheckedItems)

            {
                if (int.TryParse(topping.Tag.ToString(), out int toppingPrice))

                {
                    currentSubtotal += toppingPrice;
                }
            }

            int newSubtotal = pizza.Price;
            foreach (var toppingName in _addedToppings)
            {
                var toppingItem = toppingList.Items.Cast<ListViewItem>().FirstOrDefault(t => t.Text == toppingName);
                if (toppingItem != null && int.TryParse(toppingItem.Tag.ToString(), out int toppingPrice))
                {
                    newSubtotal += toppingPrice;
                }
            }

            if (currentSubtotal < newSubtotal)
                return;


            pizzaList.ItemChecked -= pizzaList_ItemChecked;

            foreach (ListViewItem item in pizzaList.Items)
            {
                item.Checked = false;
            }

            foreach (ListViewItem item in pizzaList.Items)
            {
                if (item.Text == pizza.Name)
                {
                    item.Checked = true;
                    ToppingList_CheckChanged(pizza);
                }
            }
            pizzaList.ItemChecked += pizzaList_ItemChecked;

            return;


        }
    }
}