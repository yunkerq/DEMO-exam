using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Model
{
    public partial class RegisterUser : Form
    {
        UserController userController = null;

        public RegisterUser(UserController userController)
        {
            InitializeComponent();
            this.userController=userController;
            comboBox1.DataSource = Enum.GetValues(typeof(User.UserRole));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!userController.RegisterUser(textBox1.Text, textBox2.Text, (User.UserRole)comboBox1.SelectedValue))
            {
                MessageBox.Show("Пользователь с таким именем уже существует!");
            }
        }
    }
}
