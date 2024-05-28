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
    }
}
