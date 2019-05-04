using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Data.SQLite;
using System.Reflection;
using System.Web;

using Excel = Microsoft.Office.Interop.Excel;

namespace Melange15
{
    public partial class Advanced : Form
    {
        public static String x;

        SQLiteConnection m_dbConnection;



        int i = 0;
        Bitmap bm;
        // DataRow dr = new DataRow();
        DataSet DS = new DataSet();
        DataTable dataTable = new DataTable();
        DataSet DS1 = new DataSet();
        DataTable dataTable1 = new DataTable();
        public Advanced()
        {
            InitializeComponent();
            textBox3.Visible = false;
            saveToExcelToolStripMenuItem.Enabled = false;
            fetchcol();
            label1.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            pictureBox2.Visible = false;
            label2.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
           // label3.Visible = false;
            textBox1.Visible = false;
            comboBox1.Enabled = false;
            textBox2.Visible = false;
            //button2.Visible = false;
            comboBox2.Visible = false;
            // button1.Visible = false;
            pictureBox1.Visible = false;
            // button3.Visible = false;
            toolTip1.SetToolTip(this.pictureBox1, "Search");
            toolTip1.SetToolTip(this.pictureBox2, "Delete");
        }





        void createTable()
        {
            ///SQLiteConnection.CreateFile("info.sqlite");
            string sql = "CREATE TABLE IF NOT EXISTS patient(ID INTEGER PRIMARY KEY   AUTOINCREMENT,f_name varchar(30),l_name varchar(30),gender varchar(7),age int(10),Contact_No long,city varchar(30),state varchar(30),height int(20),weight int(20),bp_upper int(30),bp_lower int(30),diabetes varchar(30),created_on Date,entry_time Time)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }


        // Writes the highscores to the console sorted on score in descending order.

        // Creates a connection with our database file.
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=Melange15n.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        private void fname()
        {
            int j = 0;
            toolStripStatusLabel3.Text = "Searching..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from melangenew where name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = command.ExecuteReader();

                /*  while (rdr.Read())
                  {
                      j++;
                  }
                 */
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        i++;
                    }
                    //textBox3.Text = i.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";
                textBox3.Text = j.ToString();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fnamepd()
        {
            int j = 0;
            toolStripStatusLabel3.Text = "Searching..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15 where f_name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    j++;
                }
                command.Parameters.AddWithValue("@name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);
                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        i++;
                    }
                    textBox3.Text = i.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";
                textBox3.Text = j.ToString();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fnamepc()
        {
            int j = 0;
            toolStripStatusLabel3.Text = "Searching..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where f_name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                command.Parameters.AddWithValue("@name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);
                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        i++;
                    }
                    textBox3.Text = i.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";
                textBox3.Text = j.ToString();
            }

            catch ( Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfname()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melangenew where name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);



                command.Parameters.AddWithValue("@name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);
                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfnamepd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where f_name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);



                command.Parameters.AddWithValue("@name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);
                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfnamepc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //  string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();

            //   MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where f_name=@name";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);



                command.Parameters.AddWithValue("@name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {
                    da.Fill(dataTable);
                    // da.Update(dataTable);
                    da.Fill(DS);
                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void lname()
        {
            int j = 0;
            connectToDatabase();
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;
                SQLiteDataReader rdr;



                //string stm = "select *from human where x=@name";
                string stm = "select *from melange15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void lnamepd()
        {
            int j = 0;
            connectToDatabase();
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;
                SQLiteDataReader rdr;



                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void lnamepc()
        {
            int j = 0;
            connectToDatabase();
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;
                SQLiteDataReader rdr;



                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}

                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dlname()
        {
            connectToDatabase();
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melange15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dlnamepd()
        {
            connectToDatabase();
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dlnamepc()
        {
            connectToDatabase();
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //   MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where l_name=@name";
                ///  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fetchphn()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;

                SQLiteDataReader rdr;


                //string stm = "select *from human where x=@name";
                string stm = "select *from melangenew where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fetchphnpd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;

                SQLiteDataReader rdr;


                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15n where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fetchphnpc()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;

                SQLiteDataReader rdr;


                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfetchphn()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melangenew where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfetchphnpd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dfetchphnpc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //   conn = new MySqlConnection(cs);
                // conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where Contact_No=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void flname()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;



                SQLiteDataReader rdr;
                //string stm = "select *from human where x=@name";
                string stm = "select *from melange15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void flnamepd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;



                SQLiteDataReader rdr;
                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void flnamepc()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;



                SQLiteDataReader rdr;
                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dflname()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melange15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dflnamepd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void dflnamepc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            //MySqlDataReader rdr = null;

            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where f_name=@fname and l_name=@lname";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("fname", textBox2.Text);
                command.Parameters.AddWithValue("lname", textBox1.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                toolStripStatusLabel3.Text = "Done..!!";

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
        }
        private void fetchcollege()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            int j = 0;
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "select *from melangenew where college=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                command.Parameters.AddWithValue("name", comboBox2.Text);



                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void fetchcollegepd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            int j = 0;
            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15 where college=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", comboBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchcollege()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melange15new where college=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", comboBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchcollegepd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            // MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where college=@name";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);


                command.Parameters.AddWithValue("name", comboBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void fetchroll()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "select *from melangenew where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void fetchrollpd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15 where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void dfetchrollpd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15 where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void fetchrollpc()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void dfetchrollpc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void dfetchroll()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;
            int j = 0;
            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;


                SQLiteDataReader rdr;

                //string stm = "select *from human where x=@name";
                string stm = "delete from melangenew where roll=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void dfetchcity()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            connectToDatabase();
            //  MySqlConnection conn = null;
            // MySqlDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "deleting from patient where City=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void fetchdate()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            int j = 0;
            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from melangenew where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteDataReader rdr;
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void fetchdatepd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            int j = 0;
            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from pd15n where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteDataReader rdr;
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable1);
                    da.Fill(DS1);

                }
                if (dataTable1.Rows.Count >= 1)
                {
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dataTable1;
                    dataGridView2.DataMember = dataTable1.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void fetchdatepc()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            int j = 0;
            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "select *from pc15 where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteDataReader rdr;
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);

                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        j++;
                    }
                    textBox3.Text = j.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";

        }
        private void dfetchdate()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from melangenew where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchdatepd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pd15n where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable1);
                    da.Fill(DS1);

                }
                if (dataTable1.Rows.Count >= 1)
                {
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dataTable1;
                    dataGridView2.DataMember = dataTable1.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchdatepc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            /// string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            //MySqlConnection conn = null;
            //MySqlDataReader rdr = null;
            connectToDatabase();
            try
            {
                //conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where x=@name";
                string stm = "delete from pc15 where created_on=@name";
                // MySqlCommand cmd = new MySqlCommand(stm, conn);

                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                command.Parameters.AddWithValue("name", textBox2.Text);
                //rdr = cmd.ExecuteReader();

                // while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                //}
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }

        private void fetchall()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "select *from melangenew";
                SQLiteDataReader rdr1;

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");

                //while (rdr.Read())
                //{
                //    comboBox2.Items.Add(rdr.GetString(1).ToString());
                //}
                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr1 = command.ExecuteReader();
                    while (rdr1.Read())
                    {
                        i++;
                    }
                    textBox3.Text = i.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void fetchallpd()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "select *from pd15n";
                SQLiteDataReader rdr1;

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");

                //while (rdr.Read())
                //{
                //    comboBox2.Items.Add(rdr.GetString(1).ToString());
                //}
                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable1);
                    da.Fill(DS1);

                }
                if (dataTable1.Rows.Count >= 1)
                {
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dataTable1;
                    dataGridView2.DataMember = dataTable1.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void fetchallpc()
        {
            toolStripStatusLabel3.Text = "Searching..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "select *from pc15";
                SQLiteDataReader rdr1;

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");

                //while (rdr.Read())
                //{
                //    comboBox2.Items.Add(rdr.GetString(1).ToString());
                //}
                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rdr1 = command.ExecuteReader();
                    while (rdr1.Read())
                    {
                        i++;
                    }
                    textBox3.Text = i.ToString();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchall()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "delete from melange15";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");


                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchallpd()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "delete from pd15n";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");


                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable1);
                    da.Fill(DS1);

                }
                if (dataTable1.Rows.Count >= 1)
                {
                    dataGridView2.Visible = true;
                    dataGridView2.DataSource = dataTable1;
                    dataGridView2.DataMember = dataTable1.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }
        private void dfetchallpc()
        {
            toolStripStatusLabel3.Text = "Deleting..!!";
            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";
            connectToDatabase();


            try
            {
                // conn = new MySqlConnection(cs);
                //conn.Open();
                //string stm=null;




                //string stm = "select *from human where @n=@name";
                string stm = "delete from pc";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");


                //if (comboBox1.Text == "Gender")
                // cmd.Parameters.AddWithValue("@x", "gender");

                //if (comboBox1.Text == "Height")
                // cmd.Parameters.AddWithValue("@x", "height");

                // command.Parameters.AddWithValue("@name", textBox2.Text);
                // rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                //  label3.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();

                //}


                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable);
                    da.Fill(DS);

                }
                if (dataTable.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable;
                    dataGridView1.DataMember = dataTable.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }
            toolStripStatusLabel3.Text = "Done..!!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;

            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = false;
            try
            {
                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                string fileName = String.Empty;
                SaveFileDialog saveFileExcel = new SaveFileDialog();

                saveFileExcel.Filter = "Excel files |*.xls|All files (*.*)|*.*";
                saveFileExcel.FilterIndex = 2;
                saveFileExcel.RestoreDirectory = true;

                if (saveFileExcel.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileExcel.FileName;
                    //Fixed-old code :11 para->add 1:Type.Missing
                    workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                app.Quit();
                workbook = null;
                app = null;
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Male";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Text = "Female";
        }

        private void saveToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            object misValue = System.Reflection.Missing.Value;

            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = false;
            try
            {
                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                string fileName = String.Empty;
                SaveFileDialog saveFileExcel = new SaveFileDialog();

                saveFileExcel.Filter = "Excel files |*.xls|All files (*.*)|*.*";
                saveFileExcel.FilterIndex = 2;
                saveFileExcel.RestoreDirectory = true;

                if (saveFileExcel.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileExcel.FileName;
                    //Fixed-old code :11 para->add 1:Type.Missing
                    workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                app.Quit();
                workbook = null;
                app = null;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Advanced ad = new Advanced();
            this.Close();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            DS.Clear();
            comboBox1.ResetText();
            //button1.Hide();
            label2.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            dataTable.Clear();
            DS.Clear();
        }

        private void printToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            /* printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
             {
                 printDocument1.Print();
             }
              */
            //printPreviewDialog1.ShowDialog();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.Print();
            }
        }




        private void saveToExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;

            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = false;
            try
            {
                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                string fileName = String.Empty;
                SaveFileDialog saveFileExcel = new SaveFileDialog();

                saveFileExcel.Filter = "Microsoft Excel Worksheet |*.xlsx|All files (*.*)|*.*";
                saveFileExcel.FilterIndex = 2;
                saveFileExcel.RestoreDirectory = true;

                if (saveFileExcel.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileExcel.FileName;
                    //Fixed-old code :11 para->add 1:Type.Missing
                    workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                app.Quit();
                workbook = null;
                app = null;
            }
        }
        void printHighscores()
        {
            string sql = "select * from patient";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection))
            {
                da.Fill(dataTable);
                da.Update(dataTable);
                da.Fill(DS);
            }
            if (dataTable.Rows.Count >= 1)
            {
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void resetToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataTable.Clear();
            DS.Clear();
            comboBox1.ResetText();
            // button1.Hide();
            pictureBox1.Hide();
            pictureBox2.Visible = false;
            label2.Visible = false;
           // label3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;

        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Advanced ad = new Advanced();
            this.Close();
        }

        private void exitApplicationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //button1.Visible = true;
            comboBox2.ResetText();
            textBox3.ResetText();
            pictureBox1.Visible = true;
            pictureBox2.Enabled = false;
            textBox2.ResetText();
            // button2.Visible = true;
            DS.Clear();
            dataTable.Clear();
            // button3.Visible = true;
            if (comboBox1.Text == "First Name")
            {
               // label3.Visible = false;
                label2.Visible = true;
                textBox2.Show();
                DS.Clear();
                dataTable.Clear();
                label2.Text = "First name: ";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "All")
            {
               // label3.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;
                DS.Clear();
                dataTable.Clear();
                // label2.Text = "Enter the first name: ";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "Last Name")
            {
                textBox1.Visible = false;
                label2.Visible = true;
                textBox2.Show();
                DS.Clear();
                // label3.Visible = true;
                dataTable.Clear();
                label2.Text = "Last name: ";
               // label3.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "First Name and Last Name")
            {

                label2.Visible = true;
                //label3.Visible = true;
                textBox2.Show();
                textBox1.Show();
                DS.Clear();
                dataTable.Clear();
                label2.Text = "First Name: ";
                comboBox2.Visible = false;

            }
            if (comboBox1.Text == "Contact No.")
            {
                label2.Show();
              //  label3.Visible = false;
                DS.Clear();
                textBox2.Visible = true;
                dataTable.Clear();
                label2.Text = "Enter the number";
                textBox1.Hide();
                comboBox2.Visible = false;

            }
            if (comboBox1.Text == "College Registration Number")
            {
                label2.Show();
                DS.Clear();
                //label3.Visible = false;
                textBox1.Visible = false;
                dataTable.Clear();
                label2.Text = "College Reg. No.";
                textBox2.Show();
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "College")
            {
                label2.Show();
                textBox1.Visible = false;
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Enter the college";
              //  label3.Visible = false;
                textBox2.Hide();
                comboBox2.Visible = true;

            }

            if (comboBox1.Text == "Date")
            {
                label2.Show();
                textBox1.Visible = false;
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Date(yyyy-MM-dd):";
                textBox2.Show();
                comboBox2.Visible = false;
               // label3.Visible = false;

            }
            label4.Visible = true;
            textBox3.Visible = true;
        }
        private void fetchcol()
        {


            connectToDatabase();


            try
            {

                string stm = "select *from clgnew";
                SQLiteDataReader rdr;


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    comboBox2.Items.Add(rdr.GetString(1).ToString());
                }




                if (dataTable.Rows.Count >= 1)
                {

                }
                else
                {

                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                //label3.Text = "Error: " + ex.ToString();
                //MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No records", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {


                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }
            }


        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Male";
            DS.Clear();
            dataTable.Clear();
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = "Female";
            DS.Clear();
            dataTable.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
            DS.Clear();
            dataTable.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
            DS.Clear();
            dataTable.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //InitializeComponent();
            DS.Clear();
            dataTable.Clear();
            DS1.Clear();
            dataTable1.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            toolStripStatusLabel3.Text = "Searching..";
            
            if (comboBox3.Text == "Cultural Events")
            {
                // comboBox1.Items.Add("College");
                if (comboBox1.Text == "Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    //x = "Name";
                    // textBox2.Text = "Na;
                    else
                        fname();
                    // textBox2.ResetText();
                    //fetch();
                }
                if (comboBox1.Text == "Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // x = "Gender";
                    // textBox2.Text = "Gender";
                    //fetchgen();
                    else
                        lname();

                    //textBox2.ResetText();
                }
                if (comboBox1.Text == "First Name and Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        flname();
                    // textBox2.ResetText();
                }

                if (comboBox1.Text == "Contact No.")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchphn();
                }
                if (comboBox1.Text == "College Registration Number")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else

                        fetchroll();
                }
                if (comboBox1.Text == "College")
                {


                    fetchcollege();
                }

                if (comboBox1.Text == "Date")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchdate();
                    // textBox2.ResetText();
                }
                if (comboBox1.Text == "All")
                {
                    fetchall();
                }
            }





            if (comboBox3.Text == "Pratibimb")
            {
                // comboBox1.Items.Remove("College");
                if (comboBox1.Text == "First Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    //x = "Name";
                    // textBox2.Text = "Na;
                    else
                        fnamepc();
                    // textBox2.ResetText();
                    //fetch();
                }
                if (comboBox1.Text == "Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // x = "Gender";
                    // textBox2.Text = "Gender";
                    //fetchgen();
                    else
                        lnamepc();

                    //textBox2.ResetText();
                }
                if (comboBox1.Text == "First Name and Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        flnamepc();
                    // textBox2.ResetText();
                }

                if (comboBox1.Text == "Contact No.")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchphnpc();
                }
                if (comboBox1.Text == "College Registration Number")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else

                        fetchrollpc();
                }


                if (comboBox1.Text == "Date")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchdatepc();
                    // textBox2.ResetText();
                }
                if (comboBox1.Text == "All")
                {
                    fetchallpc();
                }
            }
            if (comboBox3.Text == "Parliamentary Debate")
            {
                // comboBox1.Items.Add("College");
                if (comboBox1.Text == "First Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    //x = "Name";
                    // textBox2.Text = "Na;
                    else
                        fnamepd();
                    // textBox2.ResetText();
                    //fetch();
                }
                if (comboBox1.Text == "Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // x = "Gender";
                    // textBox2.Text = "Gender";
                    //fetchgen();
                    else
                        lnamepd();

                    //textBox2.ResetText();
                }
                if (comboBox1.Text == "First Name and Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        flnamepd();
                    // textBox2.ResetText();
                }

                if (comboBox1.Text == "Contact No.")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchphnpd();
                }
                if (comboBox1.Text == "College Registration Number")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else

                        fetchrollpd();
                }
                if (comboBox1.Text == "College")
                {


                    fetchcollegepd();
                }

                if (comboBox4.Text == "Date")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        fetchdatepd();
                    // textBox2.ResetText();
                }
                if (comboBox4.Text == "All")
                {
                    fetchallpd();
                }
            }

            pictureBox2.Enabled = true;
            pictureBox2.Visible = true;
            saveToExcelToolStripMenuItem.Enabled = true;

        }
        //deleting records
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Values will be deleted permanently", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                toolStripStatusLabel3.Text = "Deleting..";

                if (comboBox1.Text == "First Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        dfname();

                        DS.Clear();
                        dataTable.Clear();
                    }
                }
                if (comboBox1.Text == "Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // x = "Gender";
                    // textBox2.Text = "Gender";
                    //fetchgen();
                    else
                    {
                        dlname();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    //textBox2.ResetText();
                }
                if (comboBox1.Text == "First Name and Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dflname();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    // textBox2.ResetText();
                }

                if (comboBox1.Text == "Contact No.")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchphn();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                if (comboBox1.Text == "City")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchcity();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                if (comboBox1.Text == "State")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {

                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                if (comboBox1.Text == "Age")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //dfage();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    // textBox2.ResetText();
                }
                if (comboBox1.Text == "Date")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchdate();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    // textBox2.ResetText();
                }
                if (comboBox1.Text == "All")
                {
                    dfetchall();
                    dataTable.Clear();
                    DS.Clear();
                }
            }
            else
                return;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.ResetText();
            DS.Clear();
            dataTable.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DS.Clear();
            dataTable.Clear();
            textBox3.ResetText();
            comboBox1.Enabled = true;
            comboBox1.ResetText();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label1.Visible = true;
            DS.Clear();
            dataTable.Clear();
           
            textBox3.ResetText();
            if (comboBox3.Text == "Cultural Events")
            {
                dataGridView2.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Enabled = true;
                comboBox1.ResetText();
                comboBox4.ResetText();
                comboBox4.Visible = false;
                comboBox4.Enabled = false;
            }
            if (comboBox3.Text == "Parliamentary Debate")
            {
                dataGridView1.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                comboBox1.Enabled = false;
                comboBox1.ResetText();
                comboBox4.ResetText();
                comboBox4.Visible = true;
                comboBox4.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //button1.Visible = true;
            comboBox2.ResetText();
            textBox3.ResetText();
            pictureBox1.Visible = true;
            pictureBox2.Enabled = false;
            textBox2.ResetText();
            // button2.Visible = true;
            dataGridView1.DataSource = null;
            DS.Clear();
            dataTable.Clear();
            DS1.Clear();
            dataTable1.Clear();
            dataGridView1.DataSource = null;
            // button3.Visible = true;
            if (comboBox1.Text == "Name")
            {
               // label3.Visible = false;
                label2.Visible = true;
                textBox2.Show();
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Name: ";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "All")
            {
               // label3.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;
                DS.Clear();
                dataTable.Clear();
                // label2.Text = "Enter the first name: ";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "Last Name")
            {
                textBox1.Visible = false;
                label2.Visible = true;
                textBox2.Show();
                DS.Clear();
                // label3.Visible = true;
                dataTable.Clear();
                label2.Text = "Last name: ";
               // label3.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "First Name and Last Name")
            {

                label2.Visible = true;
              //  label3.Visible = true;
                textBox2.Show();
                textBox1.Show();
                DS.Clear();
                dataTable.Clear();
                label2.Text = "First Name: ";
                comboBox2.Visible = false;

            }
            if (comboBox1.Text == "Contact No.")
            {
                label2.Show();
               // label3.Visible = false;
                DS.Clear();
                textBox2.Visible = true;
                dataTable.Clear();
                label2.Text = "Enter the number";
                textBox1.Hide();
                comboBox2.Visible = false;

            }
            if (comboBox1.Text == "College Registration Number")
            {
                label2.Show();
                DS.Clear();
              //  label3.Visible = false;
                textBox1.Visible = false;
                dataTable.Clear();
                label2.Text = "College Reg. No.";
                textBox2.Show();
                comboBox2.Visible = false;
            }
            if (comboBox1.Text == "College")
            {
                label2.Show();
                textBox1.Visible = false;
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Enter the college";
               // label3.Visible = false;
                textBox2.Hide();
                comboBox2.Visible = true;

            }

            if (comboBox1.Text == "Date")
            {
                label2.Show();
                textBox1.Visible = false;
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Date(yyyy-MM-dd):";
                textBox2.Show();
                comboBox2.Visible = false;
              //  label3.Visible = false;

            }
            label4.Visible = true;
            //textBox3.Visible = true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Values will be deleted permanently", "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DS1.Clear();
                dataTable1.Clear();
                toolStripStatusLabel3.Text = "Deleting..";
                if (comboBox3.Text == "Cultural Events")
                {
                    if (comboBox1.Text == "First Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        else
                        {
                            dfname();

                            DS.Clear();
                            dataTable.Clear();
                            DS1.Clear();
                            dataTable1.Clear();
                        }
                    }
                    if (comboBox1.Text == "Last Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        // x = "Gender";
                        // textBox2.Text = "Gender";
                        //fetchgen();
                        else
                        {
                            dlname();
                            dataTable.Clear();
                            DS.Clear();
                            DS1.Clear();
                            dataTable1.Clear();
                        }
                        //textBox2.ResetText();
                    }
                    if (comboBox1.Text == "First Name and Last Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dflname();
                            dataTable.Clear();
                            DS.Clear();
                        }
                        // textBox2.ResetText();
                    }

                    if (comboBox1.Text == "Contact No.")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchphn();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }
                    if (comboBox1.Text == "College")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchcollege();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }
                    if (comboBox1.Text == "College Registration Number")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchroll();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }

                    if (comboBox1.Text == "Date")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchdate();
                            dataTable.Clear();
                            DS.Clear();
                        }
                        // textBox2.ResetText();
                    }
                    if (comboBox1.Text == "All")
                    {
                        dfetchall();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
              
                






                if (comboBox3.Text == "Pratibimb")
                {
                     if (comboBox1.Text == "First Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    else
                    {
                        dfnamepc();

                        DS.Clear();
                        dataTable.Clear();
                    }
                }
                if (comboBox1.Text == "Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // x = "Gender";
                    // textBox2.Text = "Gender";
                    //fetchgen();
                    else
                    {
                        dlnamepc();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    //textBox2.ResetText();
                }
                if (comboBox1.Text == "First Name and Last Name")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dflnamepc();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    // textBox2.ResetText();
                }

                if (comboBox1.Text == "Contact No.")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchphnpc();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                if (comboBox1.Text == "College")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        //
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                if (comboBox1.Text == "College Registration Number")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchrollpc();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                
                if (comboBox1.Text == "Date")
                {
                    if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        dfetchdatepc();
                        dataTable.Clear();
                        DS.Clear();
                    }
                    // textBox2.ResetText();
                }
                if (comboBox1.Text == "All")
                {
                    dfetchallpc();
                    dataTable.Clear();
                    DS.Clear();
                }
            }
                
               

                if (comboBox3.Text == "Parliamentary Debate")
                {
                    if (comboBox1.Text == "First Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        else
                        {
                            dfnamepd();

                            DS.Clear();
                            dataTable.Clear();
                        }
                    }
                    if (comboBox1.Text == "Last Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        // x = "Gender";
                        // textBox2.Text = "Gender";
                        //fetchgen();
                        else
                        {
                            dlnamepd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                        //textBox2.ResetText();
                    }
                    if (comboBox1.Text == "First Name and Last Name")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dflnamepd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                        // textBox2.ResetText();
                    }

                    if (comboBox1.Text == "Contact No.")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchphnpd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }
                    if (comboBox1.Text == "College")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchcollegepd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }
                    if (comboBox1.Text == "College Registration Number")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchrollpd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                    }

                    if (comboBox1.Text == "Date")
                    {
                        if (string.IsNullOrEmpty(textBox2.Text))
                        {
                            MessageBox.Show("Enter the search parameter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dfetchdatepd();
                            dataTable.Clear();
                            DS.Clear();
                        }
                        // textBox2.ResetText();
                    }
                    if (comboBox1.Text == "All")
                    {
                        dfetchallpd();
                        dataTable.Clear();
                        DS.Clear();
                    }
                }
                
        }
    }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox3.ResetText();
            DS.Clear();
            dataTable.Clear();
            DS1.Clear();
            dataTable1.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
            DS.Clear();
            dataTable.Clear();
        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {
            pictureBox2.Enabled = false;
            DS.Clear();
            dataTable.Clear();
        }

        private void saveToExcelToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            object misValue = System.Reflection.Missing.Value;

            // creating Excel Application
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // creating new WorkBook within Excel application
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            // creating new Excelsheet in workbook
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            // see the excel sheet behind the program
            app.Visible = false;
            try
            {
                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

                // changing the name of active sheet
                worksheet.Name = "Exported from gridview";


                // storing header part in Excel
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }



                // storing Each row and column value to excel sheet
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application
                string fileName = String.Empty;
                SaveFileDialog saveFileExcel = new SaveFileDialog();

                saveFileExcel.Filter = "Microsoft Excel Worksheet |*.xlsx|All files (*.*)|*.*";
                saveFileExcel.FilterIndex = 2;
                saveFileExcel.RestoreDirectory = true;

                if (saveFileExcel.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileExcel.FileName;
                    //Fixed-old code :11 para->add 1:Type.Missing
                    workbook.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                app.Quit();
                workbook = null;
                app = null;
            }
        }

        private void resetToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            dataTable.Clear();
            DS.Clear();
            comboBox1.ResetText();
            comboBox2.ResetText();
            // button1.Hide();
            pictureBox1.Hide();
            pictureBox2.Visible = false;
            label2.Visible = false;
          //  label3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
        }

        private void closeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Advanced ad = new Advanced();
            this.Close();
        }

        private void exitApplicationToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DS.Clear();
            dataTable.Clear();
            DS1.Clear();
            dataTable1.Clear();
            textBox3.ResetText();
            pictureBox1.Visible = true;
            pictureBox2.Enabled = false;
            textBox2.Visible = false;
            textBox2.ResetText();
            if (comboBox4.Text == "Date")
            {
              //  label3.Visible = false;
                label2.Visible = true;
                textBox2.Show();
                DS.Clear();
                dataTable.Clear();
                label2.Text = "Date (yyyy-mm-dd)";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
            if (comboBox4.Text == "All")
            {
                //label3.Visible = false;
                label2.Visible = false;
                textBox2.Visible = false;
                DS.Clear();
                dataTable.Clear();
                // label2.Text = "Enter the first name: ";
                textBox1.Visible = false;
                comboBox2.Visible = false;
            }
        }




        /*    private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                try
                {
                    //Set the left margin
                    int iLeftMargin = e.MarginBounds.Left;
                    //Set the top margin
                    int iTopMargin = e.MarginBounds.Top;
                    //Whether more pages have to print or not
                    bool bMorePagesToPrint = false;
                    int iTmpWidth = 0;

                    //For the first page to print set the cell width and header height
                    if (bFirstPage)
                    {
                        foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                        {
                            iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                (double)iTotalWidth * (double)iTotalWidth *
                                ((double)e.MarginBounds.Width / (doble)iTotalWidth))));

                            iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                            // Save width and height of headers
                            arrColumnLefts.Add(iLeftMargin);
                            arrColumnWidths.Add(iTmpWidth);
                            iLeftMargin += iTmpWidth;
                        }
                    }
                    //Loop till all the grid rows not get printed
                    while (iRow <= dataGridView1.Rows.Count - 1)
                    {
                        DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                        //Set the cell height
                        iCellHeight = GridRow.Height + 5;
                        int iCount = 0;
                        //Check whether the current page settings allows more rows to print
                        if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                        {
                            bNewPage = true;
                            bFirstPage = false;
                            bMorePagesToPrint = true;
                            break;
                        }
                        else
                        {
                            if (bNewPage)
                            {
                                //Draw Header
                                e.Graphics.DrawString("Customer Summary",
                                    new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left,
                                    e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                    new Font(dataGridView1.Font, FontStyle.Bold),
                                    e.MarginBounds.Width).Height - 13);

                                String strDate = DateTime.Now.ToLongDateString() + " " +
                                    DateTime.Now.ToShortTimeString();
                                //Draw Date
                                e.Graphics.DrawString(strDate,
                                    new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                    e.MarginBounds.Left +
                                    (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                    new Font(dataGridView1.Font, FontStyle.Bold),
                                    e.MarginBounds.Width).Width),
                                    e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary",
                                    new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                                //Draw Columns                 
                                iTopMargin = e.MarginBounds.Top;
                                foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                                {
                                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawRectangle(Pens.Black,
                                        new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight));

                                    e.Graphics.DrawString(GridCol.HeaderText,
                                        GridCol.InheritedStyle.Font,
                                        new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                        new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                        (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                    iCount++;
                                }
                                bNewPage = false;
                                iTopMargin += iHeaderHeight;
                            }
                            iCount = 0;
                            //Draw Columns Contents                
                            foreach (DataGridViewCell Cel in GridRow.Cells)
                            {
                                if (Cel.Value != null)
                                {
                                    e.Graphics.DrawString(Cel.Value.ToString(),
                                        Cel.InheritedStyle.Font,
                                        new SolidBrush(Cel.InheritedStyle.ForeColor),
                                        new RectangleF((int)arrColumnLefts[iCount],
                                        (float)iTopMargin,
                                        (int)arrColumnWidths[iCount], (float)iCellHeight),
                                        strFormat);
                                }
                                //Drawing Cells Borders 
                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iCellHeight));
                                iCount++;
                            }
                        }
                        iRow++;
                        iTopMargin += iCellHeight;
                    }
                    //If more lines exist, print another page.
                    if (bMorePagesToPrint)
                        e.HasMorePages = true;
                    else
                        e.HasMorePages = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
            }
            */
        /*    private void button4_Click(object sender, EventArgs e)
            {
                bm = new Bitmap(dataGridView1.ClientRectangle.Width, dataGridView1.ClientRectangle.Height);
                dataGridView1.DrawToBitmap(bm, dataGridView1.ClientRectangle);
                bm.Save(@"C:\datagrid", System.Drawing.Imaging.ImageFormat.Jpeg);
                bm = null;
                bm = new Bitmap(button1.ClientRectangle.Width, button1.ClientRectangle.Height);
                button1.DrawToBitmap(bm, button1.ClientRectangle);
            }
            */
        /*    private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
            {
                try
                {
                   strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Near;
                    strFormat.LineAlignment = StringAlignment.Center;
                    strFormat.Trimming = StringTrimming.EllipsisCharacter;

                    arrColumnLefts.Clear();
                    arrColumnWidths.Clear();
                    iCellHeight = 0;
                    iCount = 0;
                    bFirstPage = true;
                    bNewPage = true;

                    // Calculating Total Widths
                    iTotalWidth = 0;
                    foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                    {
                        iTotalWidth += dgvGridCol.Width;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        
    */

    }
}
