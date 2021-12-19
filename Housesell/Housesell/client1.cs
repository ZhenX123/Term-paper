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
    public partial class client1 : Form
    {
        public client1()
        {
            InitializeComponent();
            Table();
        }
        //从数据库读取数据显示在表格控件中 Reading data from the database is displayed in the table control

        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = "select * from t_customer";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        //根据名显示数据according Fname to show data
        public void TableFname()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = $"select * from t_customer where Fname='{textBox1.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        //根据姓显示数据according Lname to show data
        public void TableLname()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = $"select * from t_customer where Lname like '%{textBox2.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        //根据卡号显示数据according Fname to show data
        public void TableBCnumber()
        {
            dataGridView1.Rows.Clear();//清空旧数据Clearing old data
            Dao dao = new Dao();
            string sql = $"select * from t_customer where BCnumber li'%{textBox3.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void client_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();;//获取书号get id
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client2 clienta = new client2();
            clienta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //传参
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string Fname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string Lname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string BCnumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                
                client3 client = new client3(id,Fname,Lname,BCnumber);
                client.ShowDialog();
                Table();//刷新数据Fresh

            }
            catch
            {
                MessageBox.Show("Error");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号get id
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult dr=MessageBox.Show("Confirm deletion?","information tips ",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if(dr==DialogResult.OK)
                {
                    string sql = $"delete from t_customer where id='{id}'";
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
                MessageBox.Show("Please select the customer information to delete in the form first!","information tips",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号get id
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableFname();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableLname();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TableBCnumber();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
  
