using Demo.Model;
using Demo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Demo
{
    public partial class Orders : Form
    {
        private UserController controller;
        private ShiftController shiftController;
        private OrderController orderController;

        public Orders(OrderController orderController, UserController controller, ShiftController shiftController)
        {
            InitializeComponent();
            this.orderController=orderController;
            this.controller=controller;
            this.shiftController=shiftController;
        }

        void LoadOrdersForWaiter(string username)
        {

            List<Order> orders = orderController.GetAllOrders();
            foreach(Order order in orders)
            {
                if (shiftController.IsUserOnShiftToday(username))
                {
                    dataGridView1.Rows.Add(order.OrderId.ToString(), order.OrderTime.ToString(), order.Status);
                }
            }

            dataGridView1.Columns[0].Visible = false;
        }


        void LoadOrdersAll()
        {
            List<Order> orders = orderController.GetAllOrders();
            foreach (Order order in orders)
            {
                dataGridView1.Rows.Add(order.OrderId.ToString(), order.OrderTime.ToString(), order.Status);
            }

            dataGridView1.Columns[0].Visible = false;
        }


        void LoadOrders()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var column = new DataGridViewTextBoxColumn();
            column.Name = "Id";
            column.Visible = false;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Дата";
            dataGridView1.Columns.Add(column);

            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Name = "Статус";
            col.DataSource = Enum.GetValues(typeof(OrderStatus));
            col.ValueType = typeof(OrderStatus);
            dataGridView1.Columns.Add(col);

            DataGridViewButtonColumn buttonColumn =
            new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Name = "Блюда";
            buttonColumn.Text = "Блюда";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            User currentUser = UserController.GetCurrentUser(); 
            switch(currentUser.Role)
            {
                case User.UserRole.Waiter:
                    LoadOrdersForWaiter(currentUser.Username);
                    break;
                default:
                    LoadOrdersAll();
                    break;
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderCreate orderCreate = new OrderCreate(orderController);
            orderCreate.ShowDialog();
            LoadOrders();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            OrderStatus s = (OrderStatus)dataGridView1.Rows[i].Cells[2].Value;
            orderController.UpdateOrderStatus(id, s);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.RowIndex < 0 || e.ColumnIndex !=
            dataGridView1.Columns["Блюда"].Index) return;

            Int32 orderId = (Int32)Convert.ToInt32(dataGridView1[0, e.RowIndex].Value);

            OrderCreate orderCreate = new OrderCreate(orderId, orderController);
            orderCreate.ShowDialog();
            LoadOrders();

        }
    }
}
