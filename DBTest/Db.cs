using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBTest
{
    public partial class Db : Form
    {
        public Db()
        {
            InitializeComponent();
        }

        DataAccess db = new DataAccess();
        BindingSource bsUser = new BindingSource();

        private void Db_Load(object sender, EventArgs e)
        {
            List<User> userList = db.GetAllUsers();
            bsUser.DataSource = userList;
            dgDB.DataSource = bsUser;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAge.Text != "")
            {
                db.InsertUser(tbName.Text, int.Parse(tbAge.Text));
                tbName.Clear();
                tbAge.Clear();
                Db_Load(sender, e);
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbAge.Text != "")
            {
                db.UpdateUser(tbName.Text, int.Parse(tbAge.Text), int.Parse(dgDB.CurrentRow.Cells[0].Value.ToString()));
                Db_Load(sender, e);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DeleteUser(int.Parse(dgDB.CurrentRow.Cells[0].Value.ToString()));
            Db_Load(sender, e);
        }
    }
}
