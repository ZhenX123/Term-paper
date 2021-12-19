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
    public partial class House1 : Form
    {
        public House1()
        {
            InitializeComponent();
            Table();
        }

        //从数据库读取数据显示在表格控件中 Reading data from the database is displayed in the table control

        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = "select * from t_House";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        public void Tablestructer()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = $"select * from t_House where structure like '%{textBox1.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        public void Tablevalue()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = $"select * from t_House where value like '%{textBox2.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            House11 house = new House11();
            house.ShowDialog();
        }

        private void House1_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Lname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取姓get Lname
                DialogResult dr = MessageBox.Show("Confirm deletion?", "information tips ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_House where Lname='{Lname}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("delete sucessfully");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("delect unsucessfully");
                    }
                    dao.DaoClose();
                }
            }
            catch
            {
                MessageBox.Show("Please select the House information to delete in the form first!", "information tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {//传参
            try
            {
                string Lname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string adress = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string structure = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string value = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                House12 house = new House12(Lname, adress, structure, value);
                house.ShowDialog();
                Table();//刷新数据Fresh

            }
            catch
            {
                MessageBox.Show("Error");
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tablestructer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tablevalue();
        }
    }
}
