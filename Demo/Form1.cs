using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Demo.User;

namespace Demo
{
    public partial class Form1 : Form
    {
        UserController control;
        ShiftController shiftController;
        OrderController orderController;

        public Form1()
        {
            InitializeComponent();
            control = new UserController();
            shiftController = new ShiftController();
            orderController = new OrderController();
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginIntoProgram();
        }

        private void LoginIntoProgram()
        {
            Login login = new Login(control);
            login.ShowDialog();
            if (!login.isLoggined)
            {
                this.Close();
                return;
            }

            User u = UserController.GetCurrentUser();
            switch (u.Role)
            {
                case UserRole.Administrator:
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    break;
                case UserRole.Waiter:
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    break;
                case UserRole.Chef:
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    break;
            }

            Text = $"{u.Username} - {u.Role}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders(orderController, control, shiftController);
            orders.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users users = new Users(control);
            users.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;

            LoginIntoProgram();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shifts shifts = new Shifts(control, shiftController);
            shifts.ShowDialog();
        }
    }
}
