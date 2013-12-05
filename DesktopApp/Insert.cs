using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace DesktopApp
{
    public partial class Insert : Form
    {
        private string myConnection = "datasource=localhost;port=3306;username=root;password=mysql";

        public Insert()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox6.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string Query = "insert into desktopapp.app (app_id,app_name,app_ver,app_des,app_comp,app_logo) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "',@IMG);";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                cmdDataBase.Parameters.Add(new MySqlParameter("@IMG",imageBt));
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Application Details Inserted");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.Close();
        
           }

        private void button4_Click(object sender, EventArgs e)
        {
            var myConn = new MySqlConnection(myConnection);
            var cmd = new MySqlCommand("select * from desktopapp.app;", myConn);
            myConn.Open();
            try
            {
                var sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;

                var dbtable = new DataTable();
                sda.Fill(dbtable);

                var bsource = new BindingSource();
                bsource.DataSource = dbtable;
                dataGridView1.DataSource = bsource;
                sda.Update(dbtable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(this.textBox6.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string query = "update desktopapp.app set app_id='" + this.textBox1.Text + "',app_name='" + this.textBox2.Text + "',app_ver='" + this.textBox3.Text + "',app_des='" + this.textBox4.Text + "',app_comp='" + this.textBox5.Text + "',app_logo='" +pictureBox1.Image+ "' where app_id='" + this.textBox1.Text + "'";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                cmd.Parameters.Add(new MySqlParameter("@IMG", imageBt));
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Application Details Updated");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "delete from desktopapp.app where app_id='" + this.textBox1.Text + "'";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmd = new MySqlCommand(query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Applicaton Details Deleted");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string picpath = ofd.FileName.ToString();
                textBox6.Text = picpath;
                pictureBox1.ImageLocation = picpath;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.label7.Text = dt.ToString();
        }
    }
}
