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
                ResultToppings = _orderManager.CreateTopping(item.Text);
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

            if (new Margherita().DefaultToppings.All(topping => selectedTopping.Contains(topping.Name)))
            {
                foreach (ListViewItem item in pizzaList.Items)
                {
                    if (item.Text == new Margherita().Name)
                    {
                        item.Checked = true;
                        break;
                    }
                }
            }
        }
    }
}
