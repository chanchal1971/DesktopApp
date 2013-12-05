using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class HomeDesktop : Form
    {
        public HomeDesktop()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert add=new Insert();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert add = new Insert();
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert add = new Insert();
            add.Show();
        }
    }
}
