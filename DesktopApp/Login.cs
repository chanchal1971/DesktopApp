using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DesktopApp
{
    public partial class Login : Form
    {
        string myConnection = "datasource=localhost;port=3306;username=root;password=mysql";

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validate_Login();
        }

        public void Validate_Login()
        {
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlDataAdapter mda = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("select * from desktopapp.login where user_id='" + textBox1.Text + "'", myConn);
            
            myConn.Open();
            // string a1, b1;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();
            int count = 0;
            while (myReader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Login Successfull!");
                //connect to 2nd form
                this.Hide();
                HomeDesktop stu = new HomeDesktop();
                stu.ShowDialog();
            }
            else if (count > 1)
            {
                MessageBox.Show("Please Enter correct Username and Password");
            }
            else
                MessageBox.Show("Please Enter correct Username and Password");
            myConn.Close();
            
        }
        }
    }
