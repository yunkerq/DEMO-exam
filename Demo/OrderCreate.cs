using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class OrderCreate : Form
    {
        OrderController controller;
        public List<string> items =new List<string>();

        public OrderCreate(OrderController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }


        int? orderId = null;

        public OrderCreate(int orderId, OrderController controller)
        {
            InitializeComponent();
            this.controller = controller;
            this.orderId = orderId;

            controller.GetAllOrders
                ().ForEach(o =>
                {
                    if(o.OrderId == orderId)
                    {
                        items = o.Items;
                        listBox1.DataSource = null;
                        listBox1.DataSource = items;
                    }
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.CreateOrder(items);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            items.Add(textBox1.Text);
            listBox1.DataSource = null;
            listBox1.DataSource = items;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            items.RemoveAt(listBox1.SelectedIndex);
            
            listBox1.DataSource = null;
            listBox1.DataSource = items;
        }
    }
}
