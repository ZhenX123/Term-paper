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
    
    public partial class House12 : Form
    {
        string Client = "";
        public House12()
        {
            InitializeComponent();
        }

        public House12(string Lname, string adress, string structure, string value)
        {
            InitializeComponent();
            Client = textBox1.Text = Lname;
            textBox2.Text = adress;
            textBox3.Text = structure;
            textBox4.Text = value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_House set Lname='{textBox1.Text}',adress='{textBox2.Text}',structure='{textBox3.Text}',value='{textBox4.Text}' where Lname='{Client}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("Change sucessfully");
                this.Close();
            }
        }
    }
}
