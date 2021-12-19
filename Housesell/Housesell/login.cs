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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    Login();
                }
                else
                {
                    MessageBox.Show("Enter empty items, please enter again");
                }
            }

            //登录方法，验证是否允许登录，允许返回真Login method, verify whether login is allowed, allow return true

            void Login()
            {
                if (textBox2.Text != "" && textBox3.Text != "" == true)
                {
                    Dao dao = new Dao();
                    string sql = $"select * from t_login where id='{textBox2.Text}' and psw='{textBox3.Text} '";
                    IDataReader dc = dao.read(sql);
                    if (dc.Read()) ; 
                    {
                        

                        MessageBox.Show("login successfully");

                       
                       

                        user1 user = new user1();//移动到下一个窗口Move to the next window
                        this.Hide();
                        user.ShowDialog();
                        this.Show();

                    }
                    
                }
                else
                { MessageBox.Show("login unsuccessfully"); 
         
                }
                
            }
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
   
}
