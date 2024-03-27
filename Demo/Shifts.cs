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
using static Demo.User;

namespace Demo
{
    public partial class Shifts : Form
    {
        private UserController controller;
        private ShiftController shiftController;
        DataTable dtEmp = new DataTable();

        public Shifts(UserController controller, ShiftController shiftController)
        {
            InitializeComponent();
            this.controller=controller;
            this.shiftController=shiftController;
        }

        private void Shifts_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        void UpdateGrid()
        {
            dtEmp = new DataTable();
            dtEmp.Columns.Add("Пользователи", typeof(string));
            dtEmp.Columns.Add("Дата", typeof(DateTime));

            foreach (Shift s in shiftController.Shifts)
            {
                dtEmp.Rows.Add(s.Users, s.DateTime.Date);
            }

            dataGridView1.DataSource = dtEmp;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CreateShift createShift = new CreateShift(controller, shiftController);
            createShift.ShowDialog();
            UpdateGrid();
        }
    }
}
