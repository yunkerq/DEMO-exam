using Demo.Model;
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
    public partial class CreateShift : Form
    {
        UserController controller;
        ShiftController ctrl;
        private struct AddedInfo
        {
            public string name { get; set; }
            public DateTime time { get; set; }
        }

        List<AddedInfo> history = new List<AddedInfo>(); 
        DataTable dtEmp;

        public CreateShift(UserController controller, ShiftController shiftController)
        {
            InitializeComponent();
            this.controller = controller;
            ctrl = shiftController; 
        }

        private void CreateShift_Load(object sender, EventArgs e)
        {
            List<string> usernames = new List<string>();

            foreach (User user in controller.Users)
            {
                usernames.Add(user.Username);
            }

            comboBox1.DataSource = usernames;
        }

        public void UpdateGrid()
        {
            dtEmp = new DataTable();
            dtEmp.Columns.Add("Пользователь", typeof(string));
            dtEmp.Columns.Add("Дата", typeof(DateTime));

            foreach (AddedInfo info in history)
            {
                dtEmp.Rows.Add(info.name, info.time.Date);
            }

            dataGridView1.DataSource = dtEmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = comboBox1.Text;
            ctrl.AddShift(dateTimePicker1.Value.Date, user);
            history.Add(new AddedInfo { name =user, time = dateTimePicker1.Value });
            UpdateGrid();
        }
    }
}
