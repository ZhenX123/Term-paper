using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Housesell
{
    public partial class client3 : Form
    {
        string ID = "";
        public client3()
        {
            InitializeComponent();
        }
        public client3(string id, string Fname, string Lname, string BCnumber)
        {
            InitializeComponent();
            ID=textBox1.Text = id;
            textBox2.Text = Fname;
            textBox3.Text = Lname;
            textBox4.Text = BCnumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_customer set id='{textBox1.Text}',Fname='{textBox2.Text}',Lname='{textBox3.Text}',BCnumber='{textBox4.Text}' where id='{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("Change sucessfully");
                this.Close();
            }
        }
    }
}
