using Demo.Model;
using Microsoft.Win32.SafeHandles;
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
    public partial class Users : Form
    {
        UserController userController;
        public Users(UserController userController)
        {
            this.userController = userController;
            InitializeComponent();
        }
        DataTable dtEmp = new DataTable();

        private void LoadUsers()
        {
            // add column to datatable  
            dtEmp.Columns.Add("IsFired", typeof(bool));
            dtEmp.Columns.Add("EmpName", typeof(string));
            dtEmp.Columns.Add("EmpRole", typeof(UserRole));

            dtEmp.Columns[0].ColumnName = "Уволен";
            dtEmp.Columns[1].ColumnName = "Имя пользователя";
            dtEmp.Columns[2].ColumnName = "Должность";

            foreach (User user in userController.Users)
            {
                dtEmp.Rows.Add(user.isFired, user.Username, user.Role);
            }

            dataGridView1.DataSource = dtEmp;

            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            //MessageBox.Show($"{i} - {dtEmp.Rows[i]["Уволен"]} - {dtEmp.Rows[i]["Имя пользователя"]}");
            userController.FireEmployee(Convert.ToString(dtEmp.Rows[i]["Имя пользователя"]), Convert.ToBoolean(dtEmp.Rows[i]["Уволен"]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterUser reg = new RegisterUser(userController);
            reg.ShowDialog();
            LoadUsers();
        }
    }
}
