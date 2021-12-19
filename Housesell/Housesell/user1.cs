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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 客户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client1 client = new client1();
            client.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 房源管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            House1 house = new House1();
            house.ShowDialog();
        }
    }
}
