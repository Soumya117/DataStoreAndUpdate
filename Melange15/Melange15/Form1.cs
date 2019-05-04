using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Threading;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace Melange15
{
    public partial class Form1 : Form
    {
        
        static int sn = 0;
        static int pc = 0;
        static int ra = 0;
        static int nr = 0;
        static int ab = 0;
        static int av = 0;
        static int kl = 0;
        static string filepath;
        string path;
       // private Backup back;
     private   static String genid;
        Image image;
        private Boolean flag = true;

        private Boolean b = true;
        private Boolean isroot = true;
        private static int[] clgarr = new int[100];

        //static String clgnew = null;
        private static String str = "Hello";
        delegate void SetTextCall(String text);
        private Thread demothread = null;

        int i = 0;
        private static String bp;
        private static String gen;
        private  static String id;
        // DataRow dr = new DataRow();
     private   SQLiteConnection m_dbConnection;
        private Backup back;
        DataSet DS = new DataSet();
        DataTable dataTable = new DataTable();
        public Form1()
        {

            InitializeComponent();
            
            enabled_false1();
            fetchcol();
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox5.Enabled = false;
            pictureBox10.Visible = false;
            textBox4.Text = "";
            // textBox7.Text = null;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            textBox2.Enabled = false;
            textBox36.Enabled = false;
            //  button10.Visible = false;
            //  button11.Visible = false;
            //  button9.Visible = false;
            //  button8.Visible = false;
            // textBox24.Text = null;
            // textBox1.Text = null;
            // textBox3.Text = null;
            //  comboBox1.Text = null;
            //  textBox1.Text = hei.ToString();
            // textBox3.Text = wei.ToString();

            //  button2.Visible = false;
            toolTip1.SetToolTip(this.pictureBox3, "Save record");
            toolTip1.SetToolTip(this.pictureBox4, "Reset");
            toolTip1.SetToolTip(this.pictureBox2, "Save to file");
            toolTip1.SetToolTip(this.pictureBox1, "Print");
            toolTip1.SetToolTip(this.pictureBox5, "Search");
            toolTip1.SetToolTip(this.pictureBox7, "Update");
            toolTip1.SetToolTip(this.pictureBox6, "Cancel");
            toolTip1.SetToolTip(this.pictureBox8, "Save to file");
            toolTip1.SetToolTip(this.pictureBox9, "Print");
            toolTip1.SetToolTip(this.pictureBox10, "Delete");

            // comboBox2.Visible = false;
            // button3.Visible = false;
            label34.Visible = false;

            // label10.Text = DateTime.Now.ToString();
            monthCalendar1.Visible = false;




            //clgnew = textBox3.Text;

            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox20.Enabled = false;
            textBox19.Enabled = false;
            // textBox29.Enabled = false;
            textBox28.Enabled = false;
            textBox30.Enabled = false;
            //textBox31.Enabled = false;
            // textBox35.Enabled = false;
            // textBox34.Enabled = false;
            // textBox18.Enabled = false;
            //  textBox23.Enabled = false;
            //  radioButton8.Enabled = false;
            //  radioButton7.Enabled = false;
            //  button2.Visible = false;
            //  button3.Visible = false;

        }
        private void export()
        {
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\Melange\2015-01-13 09_33_11\backup_mel.xlsx';Extended Properties=Excel 8.0;");
            MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
            MyCommand.TableMappings.Add("Table", "Net-informations.com");
            DtSet = new System.Data.DataSet();
            MyCommand.Fill(DtSet);
            //dataGridView2.DataSource = DtSet.Tables[0];
            MyConnection.Close();
        }
        private void genidnew()
        {
            id = "ME15";
            if (genid.Length == 5)
            {

                id = id + "00";

            }
            if (genid.Length == 6)
            {
                id = id + "0";
            }
            if (genid.Length == 7)
            {
                return;
            }
        }
        private void genidpc()
        {
            id = "ME15PC";
            if (genid.Length == 7)
            {

                id = id + "00";

            }
            if (genid.Length == 8)
            {
                id = id + "0";
            }
            if (genid.Length == 9)
            {
                return;
            }
        }
        private void genidpd()
        {
            id = "PD";
            if (genid.Length == 3)
            {

                id = id + "00";

            }
            if (genid.Length == 4)
            {
                id = id + "0";
            }
            if (genid.Length == 5)
            {
                return;
            }
        }
        //private void fetchall()
        //{


        //    try
        //    {






        //        string stm = "select *from patient";
        //        //  MySqlCommand cmd = new MySqlCommand(stm, conn);
        //        SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);



        //        using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
        //        {

        //            da.Fill(dataTable);
        //            da.Fill(DS);

        //        }
        //        if (dataTable.Rows.Count >= 1)
        //        {
        //            dataGridView1.Visible = true;
        //            dataGridView1.DataSource = dataTable;
        //            dataGridView1.DataMember = dataTable.TableName;
        //            //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        else
        //        {

        //            MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("Error: {0}", ex.ToString());
        //        //label3.Text = "Error: " + ex.ToString();
        //        MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {


        //        if (m_dbConnection != null)
        //        {
        //            m_dbConnection.Close();
        //        }
        //    }
        //    //toolStripStatusLabel3.Text = "Done..!!";
        //}
        private void check()
        {

        
        
        }

        void createNewDatabase()
        {


        }
        void enabled_false1()
        {
            textBox25.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox14.Enabled = false;
            textBox13.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox27.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
            textBox4.Enabled = false;
            comboBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

        }
        void enabled_false2()
        {
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox14.Enabled = false;
            textBox13.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox27.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

        }
        void enabled_true2()
        {
            textBox25.Enabled = true;
           // textBox27.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            comboBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            
        }
        void enabled_true1()
        {
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            comboBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox14.Enabled = true;
            textBox13.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            comboBox5.Enabled = true;
            comboBox6.Enabled = true;
        }
        void createTable()
        {
            ///SQLiteConnection.CreateFile("info.sqlite");
            // string sql = "CREATE TABLE IF NOT EXISTS patient(ID INTEGER PRIMARY KEY   AUTOINCREMENT,f_name varchar(30),l_name varchar(30),gender varchar(7),age int(10),Contact_No long,city varchar(30),state varchar(30),height int(20),weight int(20),bp_upper int(30),bp_lower int(30),diabetes varchar(30),created_on Date,entry_time Time)";
            string sql = "CREATE TABLE IF NOT EXISTS melangenew(ID INTEGER PRIMARY KEY   AUTOINCREMENT DEFAULT 5001,name varchar(50),college nvarchar(100),roll nvarchar(20),Contact_No long,email nvarchar(70),created_on Date)";
            //string sqlpd = "CREATE TABLE IF NOT EXISTS pd15(ID INTEGER PRIMARY KEY   AUTOINCREMENT DEFAULT 5001,f_name varchar(50),l_name varchar(50),college nvarchar(100),roll nvarchar(20),Contact_No long,email nvarchar(70),created_on Date)";
            string sqlpd = "CREATE TABLE IF NOT EXISTS pd15n(ID INTEGER PRIMARY KEY   AUTOINCREMENT,name1 varchar(50),name2 varchar(50),name3 varchar(50),college1 nvarchar(100),college2 nvarchar(100),college3 nvarchar(100),roll1 nvarchar(20),roll2 nvarchar(20),roll3 nvarchar(20),Contact1 long,Contact2 long,Contact3 long,email1 nvarchar(70),email2 nvarchar(70),email3 nvarchar(70),created_on Date)";
            string sqlnew = "CREATE TABLE IF NOT EXISTS clgnew(ID INTEGER, college nvarchar(100), PRIMARY KEY(ID))";
            string sqlpc = "CREATE TABLE IF NOT EXISTS pc15(ID INTEGER PRIMARY KEY   AUTOINCREMENT DEFAULT 001,f_name varchar(50),l_name varchar(50),roll nvarchar(20),Contact_No long,email nvarchar(70),created_on Date)";
            SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteCommand compd = new SQLiteCommand(sqlpd, m_dbConnection);
            SQLiteCommand compc = new SQLiteCommand(sqlpc, m_dbConnection);
            command.ExecuteNonQuery();
            com.ExecuteNonQuery();
            compd.ExecuteNonQuery();
            compc.ExecuteNonQuery();
        }
        void fillTable()
        {
            // connectToDatabase();
            comboBox2.Enabled = true;

            string sql = "INSERT INTO melangenew(name,college,roll,Contact_No,email,created_on) VALUES(@name,@col,@roll,@phn,@email,@date)";

            SQLiteDataReader rdr;
            string all = "select *from clgnew";
            string sqlnew = "INSERT INTO clgnew(college) VALUES (@colnew)";

            SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
            SQLiteCommand conn = new SQLiteCommand(all, m_dbConnection);
           // rdr = com.ExecuteReader();

           // int i = 0;
            //while (rdr.Read())
            //{
            //    if (textBox3.Text.Equals(rdr.GetString(1).ToString()))
            //    {
            //        //com.Parameters.AddWithValue("@colnew", textBox3.Text);
            //        //com.ExecuteNonQuery();
            //        flag = false;
            //        break;
            //    }
            //    i++;
            //}
            ////if not matched
            //if (flag == true)
            //{
               com.Parameters.AddWithValue("@colnew", textBox3.Text);
                com.ExecuteNonQuery();
            //}
            //MessageBox.Show("I:" + i);

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            //command.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            // command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm"));


            command.Parameters.AddWithValue("@name", textBox25.Text);
            
            command.Parameters.AddWithValue("@col", textBox3.Text);
            command.Parameters.AddWithValue("@roll", textBox1.Text);

            command.Parameters.AddWithValue("@phn", textBox6.Text);
            command.Parameters.AddWithValue("@email", textBox4.Text);


            command.ExecuteNonQuery();

            toolStripStatusLabel7.Text = "Inserted";
            button12.PerformClick();
            pictureBox3.Enabled = false;
        }

        void filltablepd()
        {
            // connectToDatabase();
            comboBox2.Enabled = true;
           // string sql = "INSERT INTO pd15(f_name,l_name,college,roll,Contact_No,email,created_on) VALUES(@fname,@lname,@col,@roll,@phn,@email,@date)";
            string sql = "INSERT INTO pd15n(name1,name2,name3,college1,college2,college3,roll1,roll2,roll3,Contact1,Contact2,Contact3,email1,email2,email3,created_on) VALUES(@name1,@name2,@name3,@col1,@col2,@col3,@roll1,@roll2,@roll3,@phn1,@phn2,@phn3,@email1,@email2,@email3,@date)";

            SQLiteDataReader rdr;
            string all = "select *from clgnew";
            string sqlnew = "INSERT INTO clgnew(college) VALUES (@colnew)";

            SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
            SQLiteCommand com1 = new SQLiteCommand(sqlnew, m_dbConnection);
            SQLiteCommand com2 = new SQLiteCommand(sqlnew, m_dbConnection);
            SQLiteCommand conn = new SQLiteCommand(all, m_dbConnection);
          

            com.Parameters.AddWithValue("@colnew", textBox3.Text);
            com.ExecuteNonQuery();
                com1.Parameters.AddWithValue("@colnew", textBox9.Text);
                com1.ExecuteNonQuery();
                com2.Parameters.AddWithValue("@colnew", textBox10.Text);
                com2.ExecuteNonQuery();
                
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            //command.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            // command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm"));


            command.Parameters.AddWithValue("@name1", textBox25.Text);
            command.Parameters.AddWithValue("@name2", textBox27.Text);
            command.Parameters.AddWithValue("@name3", textBox8.Text);
            command.Parameters.AddWithValue("@col1", textBox3.Text);
            command.Parameters.AddWithValue("@col2", textBox9.Text);
            command.Parameters.AddWithValue("@col3", textBox10.Text);
            command.Parameters.AddWithValue("@roll1", textBox1.Text);
            command.Parameters.AddWithValue("@roll2", textBox11.Text);
            command.Parameters.AddWithValue("@roll3", textBox12.Text);
            command.Parameters.AddWithValue("@phn1", textBox6.Text);
            command.Parameters.AddWithValue("@phn2", textBox14.Text);
            command.Parameters.AddWithValue("@phn3", textBox13.Text);
            command.Parameters.AddWithValue("@email1", textBox4.Text);
            command.Parameters.AddWithValue("@email2", textBox15.Text);
            command.Parameters.AddWithValue("@email3", textBox16.Text);

            command.ExecuteNonQuery();

            toolStripStatusLabel7.Text = "Inserted";
            button12.PerformClick();
            pictureBox3.Enabled = false;
        }
        void filltablepc()
        {
            // connectToDatabase();
            string sql = "INSERT INTO pc15(f_name,l_name,roll,Contact_No,email,created_on) VALUES(@fname,@lname,@roll,@phn,@email,@date)";




            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            //command.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
            // command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm"));


            command.Parameters.AddWithValue("@fname", textBox25.Text);
            command.Parameters.AddWithValue("@lname", textBox27.Text);
            // command.Parameters.AddWithValue("@col", textBox3.Text);
            command.Parameters.AddWithValue("@roll", textBox1.Text);

            command.Parameters.AddWithValue("@phn", textBox6.Text);
            command.Parameters.AddWithValue("@email", textBox4.Text);


            command.ExecuteNonQuery();

            toolStripStatusLabel7.Text = "Inserted";
            button12.PerformClick();
        }
        // Creates a connection with our database file.
        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=Melange15n.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        private void fetchcol()
        {


            connectToDatabase();
            string sqlnew = "CREATE TABLE IF NOT EXISTS clgnew(ID INTEGER, college nvarchar(100), PRIMARY KEY(ID))";
            SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
            com.ExecuteNonQuery();

            try
            {

                string stm = "select DISTINCT college from clgnew";
                SQLiteDataReader rdr;


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                   comboBox2.Items.Add(rdr.GetString(0).ToString());
                   comboBox5.Items.Add(rdr.GetString(0).ToString());
                   comboBox6.Items.Add(rdr.GetString(0).ToString());
                   
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
        private void fetchcol1()
        {


            connectToDatabase();
            string sqlnew = "CREATE TABLE IF NOT EXISTS clgnew(ID INTEGER, college nvarchar(100), PRIMARY KEY(ID))";
            SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
            com.ExecuteNonQuery();

            try
            {

                string stm = "select DISTINCT college from clgnew";
                SQLiteDataReader rdr;


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                //if (comboBox1.Text == "Name")
                // cmd.Parameters.AddWithValue("@x", "name");
                rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                   
                    comboBox4.Items.Add(rdr.GetString(0).ToString());
                    comboBox7.Items.Add(rdr.GetString(0).ToString());
                    comboBox8.Items.Add(rdr.GetString(0).ToString());
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
        private void reset_insert()
        {
            textBox25.ResetText();
            textBox27.ResetText();
            textBox6.ResetText();
            textBox4.ResetText();
            //  textBox7.ResetText();
            //  textBox24.ResetText();
            textBox1.ResetText();
            textBox3.ResetText();
            //   comboBox1.Text = " ";


            // radioButton1.Checked = false;
            // radioButton2.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox25.Text) || string.IsNullOrEmpty(textBox27.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Asterik* marked fields are mandatory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                saveToDocToolStripMenuItem2.Enabled = true;
                printToolStripMenuItem2.Enabled = true;

                /* this.Enabled = false;
                 this.demothread = new Thread(new ThreadStart(this.ThreadProcSafe));
                 this.demothread.Start();

               

                 // progressBar1.Visible = true;
                 this.backgroundWorker1.RunWorkerAsync();
                 this.button1.Enabled = false;
                 while (backgroundWorker1.IsBusy)
                 {
                     // progressBar1.Increment(1);
                     Application.DoEvents();
                 }
             */
                toolStripStatusLabel1.Text = "Inserting..!!";
                textBox36.Enabled = true;
                // button10.Visible = true;
                // button11.Visible = true;
                textBox25.Enabled = false;
                textBox27.Enabled = false;
                textBox6.Enabled = false;
                textBox4.Enabled = false;
                //textBox7.Enabled = false;
                // textBox24.Enabled = false;
                //  textBox1.Enabled = false;
                textBox3.Enabled = false;
                //  comboBox1.Enabled = false;
                //  textBox32.Enabled = false;
                //  textBox33.Enabled = false;
                //    radioButton1.Enabled = false;
                //     radioButton2.Enabled = false;
                //   button1.Enabled = false;
                //insert();

            }



        }



        private void ThreadProcSafe()
        {


            str = "Inserting.. Please Wait!!";

            // this.SetText(str);
            SetText(str);
        }
        private void SetText(string text)
        {

            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.label34.InvokeRequired)
            {
                SetTextCall d = new SetTextCall(SetText);
                //this.Invoke(d, new object[] { str });
                Invoke(d, new object[] { str });
            }
            else
            {
                // this.label21.Text = str;
                this.label34.Text = str;
                toolStripStatusLabel1.Text = str;
            }
        }
//        private void insert()
//        {

//            string cs = @"server=localhost;userid=root;
//            password=spartan;database=inform";

           

//            try
//            {
//                //   if (radioButton1.Checked)
//                //   {
//                //       gen = "Male";
//                //   }
//                /*   else if (radioButton2.Checked)
//                   {
//                       gen = "Female";
//                   }
//                 */
//                conn = new MySqlConnection(cs);
//                conn.Open();

//                MySqlCommand cmd = new MySqlCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = "INSERT INTO patient(f_name,l_name,gender,age,Contact_No,city,state,height,weight,bp_upper,bp_lower,diabetes,created_on,entry_time) VALUES(@fname,@lname,@gen,@age,@contact,@city,@state,@height,@weight,@bp_u,@bp_l,@db,@date,@time)";
//                // cmd.CommandText = "INSERT INTO patient(f_name,l_name,gender,age,Contact_No,city,state) VALUES(@fname,@lname,@gen,@age,@contact,@city,@state)";
//                cmd.Prepare();
//                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
//                cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));
//                //cmd.Parameters.AddWithValue("@bp_u", textBox32.Text);
//                // cmd.Parameters.AddWithValue("@bp_l", textBox33.Text);
//                // cmd.Parameters.AddWithValue("@height", textBox1.Text);
//                cmd.Parameters.AddWithValue("@weight", textBox3.Text);
//                //cmd.Parameters.AddWithValue("@db", comboBox1.Text);
//                cmd.Parameters.AddWithValue("@fname", textBox25.Text);
//                cmd.Parameters.AddWithValue("@lname", textBox27.Text);
//                cmd.Parameters.AddWithValue("@gen", gen);
//                cmd.Parameters.AddWithValue("@age", textBox4.Text);
//                //  cmd.Parameters.AddWithValue("@gen", textBox2.Text);
//                // cmd.Parameters.AddWithValue("@height", textBox3.Text);
//                cmd.Parameters.AddWithValue("@contact", textBox6.Text);
//                // cmd.Parameters.AddWithValue("@city", textBox7.Text);
//                // cmd.Parameters.AddWithValue("@state", textBox24.Text);
//                //cmd.Parameters.AddWithValue("@info", textBox4.Text);
//                cmd.ExecuteNonQuery();
//                //MessageBox.Show("Inserted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
//                toolStripStatusLabel7.Text = "Inserted";
//                button12.PerformClick();

//            }
//            catch (Exception ex)
//            {
//                //Console.WriteLine("Error: {0}", ex.ToString());
//                // MessageBox.Show("Invalid data. Only Characters in Name and numbers in Height", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }

//            }

//        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                toolStripStatusLabel2.Text = "Fetching data..!!";
                //   button8.Visible = true;
                textBox2.Enabled = true;
                // button9.Visible = true;
                editToolStripMenuItem2.Enabled = true;
                fetch();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //textBox5.ResetText();
        }

        private void fetch()
        {

            connectToDatabase();
            //SQLiteConnection.CreateFile("info.sqlite");
          //  MySqlConnection conn = null;
            //    MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                // conn.Open();

                //  string stm = "select *from patient where id=@id";
                string stm = "select *from melangenew where id=@id";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                command.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    textBox22.Text = rdr.GetString(1).ToString();

                    /*  if (gen == "Male")
                      {
                          radioButton8.Checked = true;
                      }
                      else
                      {
                          radioButton7.Checked = true;
                      }
                      */
                    textBox21.Text = rdr.GetString(2).ToString();
                    textBox20.Text = rdr.GetInt64(4).ToString();
                    textBox28.Text = rdr.GetString(5).ToString();
                    textBox7.Text = rdr.GetString(3).ToString();

                   

                    //  textBox29.Text = rdr.GetString(12).ToString();
                    textBox30.Text = rdr.GetDateTime(6).ToString("yyyy-MM-dd");
                    // textBox31.Text = rdr.GetDateTime(8).ToShortTimeString().ToString();


                    //  textBox34.Text = rdr.GetInt32(11).ToString();
                    genid = "ME15" + rdr.GetInt32(0).ToString();
                    genidnew();
                    sb.Append("ID:" + id + rdr.GetInt32(0).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Name:" + rdr.GetString(1).ToString());

                    sb.Append(Environment.NewLine);
                    
                    sb.Append("College:" + rdr.GetString(2).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(3).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(4).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(5).ToString());
                    sb.Append(Environment.NewLine);

                    sb.Append("Visited on: " + rdr.GetDateTime(6).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    //sb.Append("Time: " + rdr.GetDateTime(8).ToShortTimeString().ToString());
                    textBox2.Text = sb.ToString();

                    toolStripStatusLabel9.Text = "Done..!!";
                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

               
            }
        }
        private void fetchpd15()
        {

            connectToDatabase();
            //SQLiteConnection.CreateFile("info.sqlite");
           // MySqlConnection conn = null;
            //    MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                // conn.Open();

                //  string stm = "select *from patient where id=@id";
               // string stm = "select *from pd15 where id=@id";
                string stm = "select *from pd15n where id=@id";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                command.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    textBox22.Text = rdr.GetString(1).ToString();
                    textBox18.Text = rdr.GetString(2).ToString();
                    textBox17.Text = rdr.GetString(3).ToString();

                    /*  if (gen == "Male")
                      {
                          radioButton8.Checked = true;
                      }
                      else
                      {
                          radioButton7.Checked = true;
                      }
                      */
                    textBox21.Text = rdr.GetString(4).ToString();
                    textBox24.Text = rdr.GetString(5).ToString();
                    textBox23.Text = rdr.GetString(6).ToString();
                    textBox20.Text = rdr.GetInt64(10).ToString();
                    textBox31.Text = rdr.GetInt64(11).ToString();
                    textBox29.Text = rdr.GetInt64(12).ToString();
                    textBox7.Text = rdr.GetString(7).ToString();
                    textBox26.Text = rdr.GetString(8).ToString();
                    textBox19.Text = rdr.GetString(9).ToString();
                    textBox28.Text = rdr.GetString(13).ToString();
                    textBox32.Text = rdr.GetString(14).ToString();
                    textBox33.Text = rdr.GetString(15).ToString();
                    //  textBox29.Text = rdr.GetString(12).ToString();
                    textBox30.Text = rdr.GetDateTime(16).ToString("yyyy-MM-dd");
                    //  textBox31.Text = rdr.GetDateTime(8).ToShortTimeString().ToString();


                    //  textBox34.Text = rdr.GetInt32(11).ToString();
                    genid = "PD" + rdr.GetInt32(0).ToString();
                    genidpd();
                    sb.Append("ID:" + id + rdr.GetInt32(0).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Name:" + rdr.GetString(1).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College:" + rdr.GetString(4).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(7).ToString());
                    sb.Append(Environment.NewLine);
                   sb.Append("Contact No.:" + rdr.GetInt64(10).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(13).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Name:" + rdr.GetString(2).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College:" + rdr.GetString(5).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(8).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(11).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(14).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Name:" + rdr.GetString(3).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College:" + rdr.GetString(6).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(9).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(12).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(15).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Visited on: " + rdr.GetDateTime(16).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    //sb.Append("Time: " + rdr.GetDateTime(8).ToShortTimeString().ToString());
                    textBox2.Text = sb.ToString();

                    toolStripStatusLabel9.Text = "Done..!!";
                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

                //if (conn != null)
                //{
                //    conn.Close();
                //}
            }
        }
        private void fetchpc15()
        {

            connectToDatabase();
            //SQLiteConnection.CreateFile("info.sqlite");
           // MySqlConnection conn = null;
            //    MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                // conn = new MySqlConnection(cs);
                // conn.Open();

                //  string stm = "select *from patient where id=@id";
                string stm = "select *from pc15 where id=@id";
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
                // MySqlCommand cmd = new MySqlCommand(stm, conn);
                command.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    textBox22.Text = rdr.GetString(1).ToString();

                    /*  if (gen == "Male")
                      {
                          radioButton8.Checked = true;
                      }
                      else
                      {
                          radioButton7.Checked = true;
                      }
                      */
                    textBox21.Text = rdr.GetString(2).ToString();
                    textBox20.Text = rdr.GetInt64(4).ToString();
                    textBox19.Text = rdr.GetString(3).ToString();
                    textBox7.Text = "NIT PATNA";

                    textBox28.Text = rdr.GetString(5).ToString();

                    //  textBox29.Text = rdr.GetString(12).ToString();
                    textBox30.Text = rdr.GetDateTime(6).ToString("yyyy-MM-dd");
                    // textBox31.Text = rdr.GetDateTime(8).ToShortTimeString().ToString();


                    //  textBox34.Text = rdr.GetInt32(11).ToString();
                    genid = "ME15PC" + rdr.GetInt32(0).ToString();
                    genidpc();
                    sb.Append("ID:" + id + rdr.GetInt32(0).ToString());
                    

                    sb.Append(Environment.NewLine);
                    sb.Append("First Name:" + rdr.GetString(1).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Last Name:" + rdr.GetString(2).ToString());

                    sb.Append(Environment.NewLine);
                    //  sb.Append("College:" + rdr.GetString(3).ToString());
                    // sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(3).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(4).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(5).ToString());
                    sb.Append(Environment.NewLine);

                    sb.Append("Visited on: " + rdr.GetDateTime(6).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    //sb.Append("Time: " + rdr.GetDateTime(8).ToShortTimeString().ToString());
                    textBox2.Text = sb.ToString();

                    toolStripStatusLabel9.Text = "Done..!!";
                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

            //    if (conn != null)
            //    {
            //        conn.Close();
            //    }
            }
        }


        /* private void button2_Click(object sender, EventArgs e)
         {
             SaveFileDialog sfd = new SaveFileDialog();
             sfd.Filter = "Excel Documents (*.xls)|*.xls";
             sfd.FileName = "export.xls";
             if (sfd.ShowDialog() == DialogResult.OK)
             {
                 //ToCsV(dataGridView1, @"c:\export.xls");
                 ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name 
             }

         }*/
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
            //printDocument1.Print();
            //Assign printPreviewDialog properties 


            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            //  printPreviewDialog1.ShowDialog();


            printDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {



            //Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            //dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            //e.Graphics.DrawImage(bm, 0, 0);


            //  PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics,
            //new Rectangle(new Point(0, 0), this.Size));
            // this.InvokePaint(dataGridView1, myPaintArgs);



            //Bitmap dataGridViewImage = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            // dataGridView1.DrawToBitmap(dataGridViewImage, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            // e.Graphics.DrawImage(dataGridViewImage, 0, 0);
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Advanced ad = new Advanced();
            ad.Show();
        }
        private void onlynum()
        {
            String s;
            s = textBox5.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate values(Numbers)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.ResetText();
                }
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            onlynum();

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }
        /*     private void onlychar()
             {
                 String s;
                // s = textBox1.Text;
                 foreach (char c in s)
                 {
                     if (Char.IsNumber(c))
                     {
                         MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
         */
        /* private void textBox1_TextChanged(object sender, EventArgs e)
         {
             onlychar();
             // textBox1.ResetText();
         }
         */
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox3.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //   textBox1.ResetText();
                }
            }
            //textBox3.ResetText();
        }











        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use Characters for Names and Gender and Digits for Height", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database Handling", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible == false)
            {
                monthCalendar1.Show();
            }
            else
            {
                monthCalendar1.Hide();
            }
            // button6.Show();
        }





        private void Form1_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            this.label10.Text = DateTime.Now.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void saveToDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enabled_true();
        }
        private void enabled_true()
        {
            // button3.Visible = true;
            // button2.Visible = true;
            textBox22.Enabled = true;
            textBox21.Enabled = true;
            textBox20.Enabled = true;
            textBox19.Enabled = true;
            // textBox18.Enabled = true;
            // radioButton8.Enabled = true;
            //  radioButton7.Enabled = true;
            //  textBox23.Enabled = true;
        }
        private void update()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            try
            {
                
                string sqlnew = "INSERT INTO clgnew(college) VALUES (@colnew)";

                SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
                SQLiteCommand com1 = new SQLiteCommand(sqlnew, m_dbConnection);
                SQLiteCommand com2 = new SQLiteCommand(sqlnew, m_dbConnection);
               

                com.Parameters.AddWithValue("@colnew", textBox21.Text);
                com.ExecuteNonQuery();
                

                //cmd.Prepare();
                //String sql = "update melange15 set f_name=@fname,l_name=@lname,college=@col,roll=@roll,Contact_No=@phn,email=@email,created_on=@date where ID=@id";
                String sql = "update melangenew set name=@name,college=@col,roll=@roll,Contact_No=@phn,email=@email,created_on=@date where ID=@id";
                // MySqlConnection conn = null;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@name", textBox22.Text);
                
                command.Parameters.AddWithValue("@col", textBox21.Text);
                command.Parameters.AddWithValue("@roll", textBox7.Text);
                command.Parameters.AddWithValue("@phn", textBox20.Text);
                //   command.Parameters.AddWithValue("@bp_l", textBox34.Text);
                //   command.Parameters.AddWithValue("@db", comboBox2.Text);

                command.Parameters.AddWithValue("@id", textBox5.Text);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));

                command.Parameters.AddWithValue("@email", textBox28.Text);

                //  command.Parameters.AddWithValue("@city", textBox18.Text);
                //  command.Parameters.AddWithValue("@state", textBox23.Text);
                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }


        }
        private void updatepd()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            try
            {
               
                string sqlnew = "INSERT INTO clgnew(college) VALUES (@colnew)";

                SQLiteCommand com = new SQLiteCommand(sqlnew, m_dbConnection);
                SQLiteCommand com1 = new SQLiteCommand(sqlnew, m_dbConnection);
                SQLiteCommand com2 = new SQLiteCommand(sqlnew, m_dbConnection);
               


                com.Parameters.AddWithValue("@colnew", textBox21.Text);
                com.ExecuteNonQuery();
                com1.Parameters.AddWithValue("@colnew", textBox24.Text);
                com1.ExecuteNonQuery();
                com2.Parameters.AddWithValue("@colnew", textBox23.Text);
                com2.ExecuteNonQuery();
                //String sql = "update pd15 set f_name=@fname,l_name=@lname,college=@col,roll=@roll,Contact_No=@phn,email=@email,created_on=@date where ID=@id";
                String sql = "update pd15n set name1=@name1,name2=@name2,name3=@name3,college1=@col1,college2=@col2,college3=@col3,roll1=@roll1,roll2=@roll2,roll3=@roll3,Contact1=@phn1,Contact2=@phn2,Contact3=@phn3,email1=@email1,email2=@email2,email3=@email3,created_on=@date where ID=@id";
                // MySqlConnection conn =ull;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@name1", textBox22.Text);
                command.Parameters.AddWithValue("@name2", textBox18.Text);
                command.Parameters.AddWithValue("@name3", textBox17.Text);

                command.Parameters.AddWithValue("@col1", textBox21.Text);
                command.Parameters.AddWithValue("@col2", textBox24.Text);
                command.Parameters.AddWithValue("@col3", textBox23.Text);
                command.Parameters.AddWithValue("@roll1", textBox7.Text);
                command.Parameters.AddWithValue("@roll2", textBox26.Text);
                command.Parameters.AddWithValue("@roll3", textBox19.Text);

                command.Parameters.AddWithValue("@phn1", textBox20.Text);
                command.Parameters.AddWithValue("@phn2", textBox31.Text);
                command.Parameters.AddWithValue("@phn3", textBox29.Text);
                //   command.Parameters.AddWithValue("@bp_l", textBox34.Text);
                //   command.Parameters.AddWithValue("@db", comboBox2.Text);

                command.Parameters.AddWithValue("@id", textBox5.Text);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));

                command.Parameters.AddWithValue("@email1", textBox28.Text);
                command.Parameters.AddWithValue("@email2", textBox32.Text);
                command.Parameters.AddWithValue("@email3", textBox33.Text);


                //  command.Parameters.AddWithValue("@city", textBox18.Text);
                //  command.Parameters.AddWithValue("@state", textBox23.Text);
                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }


        }
        private void updatepc()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";

            try
            {
                //conn = new MySqlConnection(cs);
                //  conn.Open();

                // MySqlCommand cmd = new MySqlCommand();
                // cmd.Connection = conn;
                // cmd.CommandText = "INSERT INTO human(name,gender,height,info) VALUES(@Name,@gen,@height,@info)";
                // cmd.CommandText = "update patients set Name=@name,Gender=@gen1,Height=@height,Contact_No=@phn,City=@city,State=@state where ID=@id";
                // cmd.CommandText = "update patient set f_name=@fname,l_name=@lname,gender=@gen1,age=@age,Contact_No=@phn,city=@city,state=@state,height=@height,weight=@weight,bp_upper=@bp_u,bp_lower=@bp_l,diabetes=@db,created_on=@date,entry_time=@time where ID=@id";

                //cmd.Prepare();
                String sql = "update pc15 set f_name=@fname,l_name=@lname,roll=@roll,Contact_No=@phn,email=@email,created_on=@date where ID=@id";
                // MySqlConnection conn =ull;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@fname", textBox22.Text);
                command.Parameters.AddWithValue("@lname", textBox21.Text);
                // command.Parameters.AddWithValue("@col", textBox7.Text);
                command.Parameters.AddWithValue("@roll", textBox19.Text);
                command.Parameters.AddWithValue("@phn", textBox20.Text);
                //   command.Parameters.AddWithValue("@bp_l", textBox34.Text);
                //   command.Parameters.AddWithValue("@db", comboBox2.Text);

                command.Parameters.AddWithValue("@id", textBox5.Text);
                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                //command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));

                command.Parameters.AddWithValue("@email", textBox28.Text);

                //  command.Parameters.AddWithValue("@city", textBox18.Text);
                //  command.Parameters.AddWithValue("@state", textBox23.Text);
                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }


        }
        private void deleterec()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            String sql = " ";
           
            try
            {
                
              
                sql = "delete from melangenew where id=@id";
                // MySqlConnection conn = null;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);


                command.Parameters.AddWithValue("@id", textBox5.Text);

                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }

        }
        private void deleterecpd()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            String sql = " ";

            try
            {


                sql = "delete from pd15n where id=@id";
                // MySqlConnection conn = null;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);


                command.Parameters.AddWithValue("@id", textBox5.Text);

                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }

        }
        private void deleterecpc()
        {
            connectToDatabase();
            // string cs = @"server=localhost;userid=root;
            //password=spartan;database=inform";
            String sql = " ";

            try
            {


                sql = "delete from pc15 where id=@id";
                // MySqlConnection conn = null;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);


                command.Parameters.AddWithValue("@id", textBox5.Text);

                command.ExecuteNonQuery();
                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                toolStripStatusLabel4.Text = "Updated Successfully";
                //statusStrip2.Text = "Updated";
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (m_dbConnection != null)
                {
                    m_dbConnection.Close();
                }

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                toolStripStatusLabel3.Text = "Updating...!!";
                update();
                fetch();
                enabled_false();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void enabled_false()
        {
            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox20.Enabled = false;
            textBox19.Enabled = false;
            //  textBox29.Enabled = false;
            textBox28.Enabled = false;
            textBox30.Enabled = false;
            //textBox31.Enabled = false;
            textBox7.Enabled = false;
            //  textBox26.Enabled = false;
            //  comboBox2.Visible = false;
            //  textBox34.Enabled = false;
            //  textBox35.Enabled = false;

            //  textBox18.Enabled = false;
            //  textBox23.Enabled = false;
            //   radioButton8.Enabled = false;
            //   radioButton7.Enabled = false;
            textBox5.ResetText();
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox21.Enabled = false;
            textBox20.Enabled = false;
            textBox28.Enabled = false;
            textBox18.Enabled = false;
            textBox17.Enabled = false;
            textBox24.Enabled = false;
            textBox23.Enabled = false;
            textBox26.Enabled = false;
            textBox33.Enabled = false;
            textBox32.Enabled = false;
            textBox31.Enabled = false;
            //  textBox26.ResetText();
            textBox19.Enabled = false;
            //  textBox18.ResetText();
            textBox21.Enabled = false;
            textBox24.Enabled = false;
            textBox29.Enabled = false;
            textBox30.Enabled = false;
        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            // button3.Visible = false;
            // button2.Visible = false;
            enabled_false();
        }

        /* private void resetToolStripMenuItem_Click(object sender, EventArgs e)
         {
             textBox5.ResetText();
             textBox22.ResetText();
             textBox23.ResetText();
             textBox21.ResetText();
             textBox20.ResetText();
             textBox19.ResetText();
             textBox18.ResetText();
             radioButton8.Checked = false;
             radioButton7.Checked = false;

         }
         */
        private void button4_Click_2(object sender, EventArgs e)
        {
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            reset_insert();
            textBox36.ResetText();
            textBox36.Enabled = false;
            // button10.Visible = false;
            // button11.Visible = false;
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            //  textBox7.Enabled = true;
            //  textBox24.Enabled = true;
            //  textBox1.Enabled = true;
            textBox3.Enabled = true;
            //  comboBox1.Enabled = true;
            //  textBox32.Enabled = true;
            //  textBox33.Enabled = true;
            //   radioButton1.Enabled = true;
            //   radioButton2.Enabled = true;
            // button1.Enabled = true;
            //  textBox1.Text = hei.ToString();

        }






        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox21.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox4.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox6.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // textBox1.ResetText();
                }
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox5.ResetText();
            textBox22.ResetText();
            //   textBox23.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox19.ResetText();
            //   textBox18.ResetText();
            //   radioButton8.Checked = false;
            //   radioButton7.Checked = false;
        }



        private void saveToDocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        private void button8_Click(object sender, EventArgs e)
        {
            //  comboBox2.Visible = true;
            //  button3.Visible = true;
            // button2.Visible = true;
            textBox22.Enabled = true;
            textBox21.Enabled = true;
            textBox20.Enabled = true;
            textBox19.Enabled = true;
            //  textBox18.Enabled = true;
            //  radioButton8.Enabled = true;
            //  radioButton7.Enabled = true;
            //  textBox23.Enabled = true;
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Edit the data";
            //button3.Visible = true;
            // button2.Visible = true;
            textBox22.Enabled = true;
            //   textBox26.Enabled = true;
            //  textBox23.Enabled = true;
            //  textBox23.Enabled = true;

            //  comboBox2.Visible = true;
            textBox28.Enabled = true;
            // textBox29.Enabled = true;
            //  textBox35.Enabled = true;
            //  textBox34.Enabled = true;

            textBox21.Enabled = true;
            textBox20.Enabled = true;
            textBox19.Enabled = true;
            //  textBox18.Enabled = true;
            //  radioButton8.Enabled = true;
            //   radioButton7.Enabled = true;

        }

        private void saveToDocToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void resetToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            textBox2.ResetText();
            textBox2.Enabled = false;
            textBox5.ResetText();
            textBox22.ResetText();
            //   textBox23.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            //   textBox26.ResetText();
            textBox19.ResetText();
            //  textBox18.ResetText();
            //   textBox29.ResetText();
            textBox30.ResetText();
            //textBox31.ResetText();
            //   radioButton8.Checked = false;
            //   radioButton7.Checked = false;
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        /*      private void textBox7_TextChanged(object sender, EventArgs e)
              {
                  String s;
                  //s = textBox7.Text;
                  foreach (char c in s)
                  {
                      if (Char.IsNumber(c))
                      {
                          MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                  }
              }
      */
        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox22.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox19.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        /*    private void textBox18_TextChanged(object sender, EventArgs e)
            {
                String s;
                s = textBox18.Text;
                foreach (char c in s)
                {
                    if (Char.IsNumber(c))
                    {
                        MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
    */
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox20.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripStatusLabel1.Text = "Please Wait..!! Inserting";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // button1.Enabled = true;
            toolStripStatusLabel1.Text = "Inserted";
            this.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /*  private void textBox23_TextChanged(object sender, EventArgs e)
          {
              String s;
              s = textBox23.Text;
              foreach (char c in s)
              {
                  if (Char.IsNumber(c))
                  {
                      MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
          }
          */
        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox28.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // textBox1.ResetText();
                }
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            //  textBox7.Enabled = true;
            //  textBox24.Enabled = true;
            //  textBox1.Enabled = true;
            textBox3.Enabled = true;
            //  comboBox1.Enabled = true;
            //  textBox32.Enabled = true;
            //  textBox33.Enabled = true;
            //   radioButton1.Enabled = true;
            //   radioButton2.Enabled = true;
        }

        //private void button8_Click_1(object sender, EventArgs e)
        //{
        //    updatenew();
        //}
//        private void updatenew()
//        {
//            string cs = @"server=localhost;userid=root;
//            password=spartan;database=inform";

//            MySqlConnection conn = null;

//            try
//            {
//                conn = new MySqlConnection(cs);
//                conn.Open();

//                MySqlCommand cmd = new MySqlCommand();
//                cmd.Connection = conn;
//                // cmd.CommandText = "INSERT INTO human(name,gender,height,info) VALUES(@Name,@gen,@height,@info)";
//                // cmd.CommandText = "update patients set Name=@name,Gender=@gen1,Height=@height,Contact_No=@phn,City=@city,State=@state where ID=@id";
//                cmd.CommandText = "update patient set f_name=@fname,l_name=@lname,gender=@gen1,age=@age,Contact_No=@phn,city=@city,state=@state,height=@height,weight=@weight,bp_upper=@bp_u,bp_lower=@bp_l,diabetes=@db,created_on=@date,entry_time=@time where ID=@id";

//                cmd.Prepare();

//                cmd.Parameters.AddWithValue("@fname", textBox22.Text);
//                cmd.Parameters.AddWithValue("@lname", textBox21.Text);
//                cmd.Parameters.AddWithValue("@age", textBox19.Text);
//                //    cmd.Parameters.AddWithValue("@weight", textBox26.Text);
//                //    cmd.Parameters.AddWithValue("@bp_u", textBox35.Text);
//                //    cmd.Parameters.AddWithValue("@bp_l", textBox34.Text);
//                //    cmd.Parameters.AddWithValue("@db", comboBox2.Text);

//                cmd.Parameters.AddWithValue("@id", textBox5.Text);
//                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
//                cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));
//                cmd.Parameters.AddWithValue("@gen1", gen);
//                cmd.Parameters.AddWithValue("@height", textBox28.Text);
//                cmd.Parameters.AddWithValue("@phn", textBox20.Text);
//                //   cmd.Parameters.AddWithValue("@city", textBox18.Text);
//                //   cmd.Parameters.AddWithValue("@state", textBox23.Text);
//                cmd.ExecuteNonQuery();
//                //MessageBox.Show("Updated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
//                toolStripStatusLabel3.Text = "Updated Successfully";
//                //statusStrip2.Text = "Updated";
//            }
//            catch (Exception ex)
//            {
//                //Console.WriteLine("Error: {0}", ex.ToString());
//                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

//            }
//            finally
//            {
//                if (conn != null)
//                {
//                    conn.Close();
//                }

//            }

//        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox36.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox36.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

//        private void button12_Click(object sender, EventArgs e)
//        {

//            string cs = @"server=localhost;userid=root;
//            password=spartan;database=inform";

//            MySqlConnection conn = null;
//            MySqlDataReader rdr = null;

//            try
//            {
//                conn = new MySqlConnection(cs);
//                conn.Open();

//                string stm = "SELECT * FROM patient WHERE id = ( SELECT MAX(id) FROM patient )";

//                MySqlCommand cmd = new MySqlCommand(stm, conn);
//                // cmd.Parameters.AddWithValue("@id", textBox5.Text);
//                rdr = cmd.ExecuteReader();


//                if (rdr.Read())
//                {

//                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
//                    StringBuilder sb = new StringBuilder();

//                    sb.Append("ID:" + rdr.GetInt32(0).ToString());

//                    sb.Append(Environment.NewLine);
//                    sb.Append("First Name:" + rdr.GetString(1).ToString());

//                    sb.Append(Environment.NewLine);
//                    sb.Append("Last Name:" + rdr.GetString(2).ToString());

//                    sb.Append(Environment.NewLine);
//                    sb.Append("Gender:" + rdr.GetString(3).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Age:" + rdr.GetInt32(4).ToString());

//                    sb.Append(Environment.NewLine);
//                    sb.Append("Contact No.:" + rdr.GetString(5).ToString());

//                    sb.Append(Environment.NewLine);

//                    sb.Append("Height:" + rdr.GetInt32(8).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Weight:" + rdr.GetInt32(9).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("BP:" + rdr.GetInt32(10).ToString() + "/" + rdr.GetInt32(11).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Contact No: " + rdr.GetInt64(4).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("City:" + rdr.GetString(6).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("State:" + rdr.GetString(7).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Diabetes:" + rdr.GetString(12).ToString());
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Visited on: " + rdr.GetDateTime(13).ToString("yyyy-MM-dd"));
//                    sb.Append(Environment.NewLine);
//                    sb.Append("Time: " + rdr.GetTimeSpan(14).ToString());
//                    textBox36.Text = sb.ToString();


//                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
//                }
//                else
//                {
//                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
//                {
//                    da.Fill(dataTable);
//                    da.Fill(DS);
//                }
//                dataGridView1.Visible = true;
//                dataGridView1.DataSource = dataTable;
//                dataGridView1.DataMember = dataTable.TableName;
//                */
//            }
//            catch (Exception ex)
//            {
//                //Console.WriteLine("Error: {0}", ex.ToString());
//                //label3.Text = "Error: " + ex.ToString();
//                MessageBox.Show(string.Format("An error occurred {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            finally
//            {
//                if (rdr != null)
//                {
//                    rdr.Close();
//                }

//                if (conn != null)
//                {
//                    conn.Close();
//                }
//            }
//        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox25.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox27.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /*   private void textBox7_TextChanged_1(object sender, EventArgs e)
           {
               String s;
              // s = textBox7.Text;
               foreach (char c in s)
               {
                   if (Char.IsNumber(c))
                   {
                       MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
           }
   */
        /*     private void textBox24_TextChanged(object sender, EventArgs e)
             {
                 String s;
                // s = textBox24.Text;
                 foreach (char c in s)
                 {
                     if (Char.IsNumber(c))
                     {
                         MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
             */
        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox6.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox4.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        /*   private void textBox1_TextChanged_1(object sender, EventArgs e)
           {
               String s;
             //  s = textBox1.Text;
               foreach (char c in s)
               {
                   if (Char.IsLetter(c))
                   {
                       MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
               }
           }
           */
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox3.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        /*     private void textBox32_TextChanged(object sender, EventArgs e)
             {
                 String s;
               //  s = textBox32.Text;
                 foreach (char c in s)
                 {
                     if (Char.IsLetter(c))
                     {
                         MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                 }
             }
             */
        /*      private void textBox33_TextChanged(object sender, EventArgs e)
              {
                  String s;
                 // s = textBox33.Text;
                  foreach (char c in s)
                  {
                      if (Char.IsLetter(c))
                      {
                          MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                      }
                  }
              }
              */
        private void saveToDocToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Advanced ad = new Advanced();
            ad.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                toolStripStatusLabel9.Text = "Fetching data..!!";
                //button8.Visible = true;
                textBox2.Enabled = true;
                //  button9.Visible = true;
                toolStripMenuItem2.Enabled = true;
                fetch();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox25.Text) || string.IsNullOrEmpty(textBox27.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Asterisk* marked fields are mandatory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                toolStripMenuItem6.Enabled = true;
                toolStripMenuItem7.Enabled = true;

                /* this.Enabled = false;
                 this.demothread = new Thread(new ThreadStart(this.ThreadProcSafe));
                 this.demothread.Start();

               

                 // progressBar1.Visible = true;
                 this.backgroundWorker1.RunWorkerAsync();
                 this.button1.Enabled = false;
                 while (backgroundWorker1.IsBusy)
                 {
                     // progressBar1.Increment(1);
                     Application.DoEvents();
                 }
             */
                toolStripStatusLabel7.Text = "Inserting..!!";
                textBox36.Enabled = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                // button10.Visible = true;
                // button11.Visible = true;
                textBox25.Enabled = false;
                textBox27.Enabled = false;
                textBox6.Enabled = false;
                textBox4.Enabled = false;
                //    textBox7.Enabled = false;
                //   textBox24.Enabled = false;
                //   textBox1.Enabled = false;
                textBox3.Enabled = false;
                //   comboBox1.Enabled = false;
                //   textBox32.Enabled = false;
                //   textBox33.Enabled = false;
                //   radioButton1.Enabled = false;
                //   radioButton2.Enabled = false;
                // button1.Enabled = false;
                //insert();
                createNewDatabase();
                connectToDatabase();
                createTable();
                fillTable();
            }

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            reset_insert();
            textBox36.ResetText();
            textBox36.Enabled = false;
            // button10.Visible = false;
            // button11.Visible = false;
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            // textBox7.Enabled = true;
            // textBox24.Enabled = true;
            // textBox1.Enabled = true;
            textBox3.Enabled = true;
            // comboBox1.Enabled = true;
            // textBox32.Enabled = true;
            // textBox33.Enabled = true;
            //  radioButton1.Enabled = true;
            //  radioButton2.Enabled = true;
            //button1.Enabled = true;
            // textBox1.Text = hei.ToString();

        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible == false)
            {
                monthCalendar1.Show();
            }
            else
            {
                monthCalendar1.Hide();
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox36.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                toolStripStatusLabel4.Text = "Updating...!!";
                update();
                fetch();
                enabled_false();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            // button3.Visible = false;
            // button2.Visible = false;
            enabled_false();
            pictureBox6.Visible = false;
            pictureBox6.Visible = false;
        }

        private void button8_Click_3(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox10.Visible = true;
            toolStripStatusLabel1.Text = "Edit the data";
            /// button3.Visible = true;
            // button2.Visible = true;
            textBox22.Enabled = true;
            // textBox26.Enabled = true;
            //  textBox23.Enabled = true;
            //  textBox23.Enabled = true;
            textBox7.Enabled = true;
            //  comboBox2.Visible = true;
            textBox28.Enabled = true;
            // textBox29.Enabled = true;
            // textBox35.Enabled = true;
            // textBox34.Enabled = true;

            textBox21.Enabled = true;
            textBox20.Enabled = true;
            textBox19.Enabled = true;
            //  textBox18.Enabled = true;
            //  radioButton8.Enabled = true;
            //   radioButton7.Enabled = true;

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            textBox2.ResetText();
            textBox7.ResetText();
            textBox2.Enabled = false;
            pictureBox10.Visible = false;
            textBox5.ResetText();
            textBox22.ResetText();
            //   textBox23.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            //  textBox26.ResetText();
            textBox19.ResetText();
            //  textBox18.ResetText();
            //  textBox29.ResetText();
            textBox30.ResetText();
            //textBox31.ResetText();
            //  radioButton8.Checked = false;
            //  radioButton7.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string copyright = "\u00a9 Copyright 2014.";
            MessageBox.Show("Software Version:1.0.0.0\nRecord Maintainence and Backup System\n\n\n" + copyright, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpContentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Use Characters for Names and Gender and Digits for Height", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox25_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox25.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox27_TextChanged_1(object sender, EventArgs e)
        {

            String s;
            s = textBox27.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox6_TextChanged_2(object sender, EventArgs e)
        {
            String s;
            s = textBox6.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void textBox4_TextChanged_2(object sender, EventArgs e)
        {
            /*String s;
            s = textBox4.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }*/
        }

        /*     private void textBox7_TextChanged_2(object sender, EventArgs e)
             {
                 String s;
               //  s = textBox7.Text;
                 foreach (char c in s)
                 {
                     if (Char.IsNumber(c))
                     {
                         MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
         */

        /*  private void textBox24_TextChanged_1(object sender, EventArgs e)
          {
              String s;
            //  s = textBox24.Text;
              foreach (char c in s)
              {
                  if (Char.IsNumber(c))
                  {
                      MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
          }
  */
        /*   private void textBox1_TextChanged_2(object sender, EventArgs e)
           {
               String s;
            //   s = textBox1.Text;
               foreach (char c in s)
               {
                   if (Char.IsLetter(c))
                   {
                       MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
               }
           }
           */
        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {
            /*String s;
            s = textBox3.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }*/
        }

        /*    private void textBox32_TextChanged_1(object sender, EventArgs e)
            {
                String s;
              //  s = textBox32.Text;
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                    {
                        MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
    */
        /*  private void textBox33_TextChanged_1(object sender, EventArgs e)
          {
              String s;
             // s = textBox33.Text;
              foreach (char c in s)
              {
                  if (Char.IsLetter(c))
                  {
                      MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                  }
              }
          }
          */
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            onlynum();
        }

        private void textBox22_TextChanged_1(object sender, EventArgs e)
        {


            String s;
            s = textBox22.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox21_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox21.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox20_TextChanged_1(object sender, EventArgs e)
        {
            String s;
            s = textBox20.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void textBox19_TextChanged_1(object sender, EventArgs e)
        {
            /*String s;
            s = textBox19.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
             */
        }

        /*   private void textBox18_TextChanged_1(object sender, EventArgs e)
           {
               String s;
               s = textBox18.Text;
               foreach (char c in s)
               {
                   if (Char.IsNumber(c))
                   {
                       MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }
           }
           */
        /*  private void textBox23_TextChanged_1(object sender, EventArgs e)
          {
              String s;
              s = textBox23.Text;
              foreach (char c in s)
              {
                  if (Char.IsNumber(c))
                  {
                      MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
              }
          }
  */
        private void textBox28_TextChanged_1(object sender, EventArgs e)
        {
            /* String s;
             s = textBox28.Text;
             foreach (char c in s)
             {
                 if (Char.IsLetter(c))
                 {
                     MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   //  textBox1.ResetText();
                 }
             } */
        }

        /*     private void textBox26_TextChanged_1(object sender, EventArgs e)
             {

                 String s;
                 s = textBox26.Text;
                 foreach (char c in s)
                 {
                     if (Char.IsLetter(c))
                     {
                         MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                 }
             }
     */
        /*    private void textBox35_TextChanged(object sender, EventArgs e)
            {
                String s;
                s = textBox35.Text;
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                    {
                        MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
    */
        /*   private void textBox34_TextChanged(object sender, EventArgs e)
           {
               String s;
               s = textBox34.Text;
               foreach (char c in s)
               {
                   if (Char.IsLetter(c))
                   {
                       MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
               }
           }
         */

        private void fetchmel()
        {
            // connectToDatabase();


          
            // MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                string stm = null;




                stm = "SELECT * FROM melangenew WHERE id = ( SELECT MAX(id) FROM melangenew )";


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                // cmd.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    genid = "ME15" + rdr.GetInt32(0).ToString();
                    genidnew();

                    sb.Append("ID:" + id+rdr.GetInt32(0).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Name:" + rdr.GetString(1).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("College:" + rdr.GetString(2).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(3).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(4).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(5).ToString());

                    
                   
                    sb.Append(Environment.NewLine);
                    sb.Append("Visited on: " + rdr.GetDateTime(6).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    //sb.Append("Time: " + rdr.GetDateTime(8).ToShortTimeString().ToString());

                    textBox36.Text = sb.ToString();

                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

                //if (conn != null)
                //{
                //    conn.Close();
                //}
            }
        }
        private void fetchpc()
        {
            //connectToDatabase();


          
            // MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                string stm = null;




                stm = "SELECT * FROM pc15 WHERE id = ( SELECT MAX(id) FROM pc15 )";


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                // cmd.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    genid = "ME15PC" + rdr.GetInt32(0).ToString();
                    genidpc();
                    sb.Append("ID:" + id+rdr.GetInt32(0).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("First Name:" + rdr.GetString(1).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Last Name:" + rdr.GetString(2).ToString());

                    sb.Append(Environment.NewLine);
                    // sb.Append("College:" + rdr.GetString(3).ToString());
                    //  sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(3).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(4).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(5).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Visited on: " + rdr.GetDateTime(6).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    //    sb.Append("Time: " + rdr.GetDateTime(7).ToShortTimeString().ToString());

                    textBox36.Text = sb.ToString();

                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

                //if (conn != null)
                //{
                //    conn.Close();
                //}
            }
        }
        private void fetchpd()
        {
            //connectToDatabase();


         
            // MySqlDataReader rdr = null;
            SQLiteDataReader rdr = null;

            try
            {
                string stm = null;




                stm = "SELECT * FROM pd15n WHERE id = ( SELECT MAX(id) FROM pd15n )";


                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                // cmd.Parameters.AddWithValue("@id", textBox5.Text);
                rdr = command.ExecuteReader();


                if (rdr.Read())
                {

                    //Console.WriteLine(rdr.GetString(0) + ": " + rdr.GetString(1));
                    StringBuilder sb = new StringBuilder();
                    genid = "PD" + rdr.GetInt32(0).ToString();
                    genidpd();
                    sb.Append("ID:" + id+rdr.GetInt32(0).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Team Details: ");
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Name: "+rdr.GetString(1).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College: "+rdr.GetString(4).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.: "+rdr.GetString(7).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Contact Number: "+ rdr.GetInt64(10).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + rdr.GetString(13).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);

                    sb.Append("Name:" + rdr.GetString(2).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College: " + rdr.GetString(5).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(8).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt32(11).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(14).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);

                    sb.Append("Name:" + rdr.GetString(3).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College: " + rdr.GetString(6).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append("College Reg. No.:" + rdr.GetString(9).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Contact No.:" + rdr.GetInt64(12).ToString());

                    sb.Append(Environment.NewLine);
                    sb.Append("Email:" + rdr.GetString(15).ToString());
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append("Visited on: " + rdr.GetDateTime(16).ToString("yyyy-MM-dd"));
                    //sb.Append("Visited on: " + rdr.GetDateTime(rdr.GetOrdinal("created_on")).ToString("YYYY-MM-DD"));
                    sb.Append(Environment.NewLine);
                    // sb.Append("Time: " + rdr.GetDateTime(8).ToShortTimeString().ToString());

                    textBox36.Text = sb.ToString();

                    //textBox2.Text = "ID: " + rdr.GetInt32(0).ToString() + "\nName:" + rdr.GetString(1).ToString() + "\nGender:" + rdr.GetString(2).ToString() + "\nHeight:" + rdr.GetInt32(3).ToString();
                }
                else
                {
                    MessageBox.Show("No data in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                /*using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                    da.Fill(DS);
                }
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataTable;
                dataGridView1.DataMember = dataTable.TableName;
                */
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

                //if (conn != null)
                //{
                //    conn.Close();
                //}
            }
        }
        private void button12_Click_1(object sender, EventArgs e)
        {
            connectToDatabase();
            if (comboBox1.Text == "Cultural Events")
                fetchmel();
            if (comboBox1.Text == "Pratibimb")
                fetchpc();
            if (comboBox1.Text == "Parliamentary Debate")
                fetchpd();
        }

        private void printDocument2_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox36.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void printDocument1_PrintPage_2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }

        private void splitter2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void backupRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;


            // pictureBox1.ResetText();
            //   releaseObject(image);

            // pictureBox1.Image = null;
            if (b == false)
            {
                path = @filepath + "Backup";
            }
            else if (isroot == false)
            {
                path = @filepath + "\\Backup";
            }
            else
            {
                path = "C:\\Backup";
            }

            if (MessageBox.Show("Delete all the files?", "Manage Space", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {



                // string folderdate = DateTime.Now.ToFileTime().ToString();

                //pictureBox1.Refresh();


                DirectoryInfo dir = new DirectoryInfo(path);

                if (Directory.Exists(path))
                {

                    DeleteDirectory(path);
                    MessageBox.Show("Directory successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Folder Doesnt Exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            else
                return;
        }

        private void DeleteDirectory(string path)
        {


            // Delete all files from the Directory
            foreach (string filename in Directory.GetFiles(path))
            {
                File.Delete(filename);
            }
            // Check all child Directories and delete files
            foreach (string subfolder in Directory.GetDirectories(path))
            {
                DeleteDirectory(subfolder);
            }
            Directory.Delete(path);

        }

        private void newBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // Backup back = new Backup(this);
            //back.Show();
        }

        private void goToTheFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String path;

            if (b == false)
            {
                path = @filepath + "Backup";
            }
            else if (isroot == false)
            {
                path = @filepath + "\\Backup";
            }
            else
            {
                path = "C:\\Backup";
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start("explorer.exe", path);
            }
            else
            {
                MessageBox.Show("Directory doesnt exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            connectToDatabase();
            createTable();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox36.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        private void reset_all()
        {
           // textBox25.ResetText();
            textBox27.ResetText();
            textBox8.ResetText();
           // textBox3.ResetText();
            textBox9.ResetText();
            textBox10.ResetText();
          //  textBox1.ResetText();
            textBox11.ResetText();
            textBox12.ResetText();
           // textBox6.ResetText();
            textBox14.ResetText();
            textBox13.ResetText();
           // textBox4.ResetText();
            textBox15.ResetText();
            textBox16.ResetText();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBox25.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox4.Text))
            //{
            //    MessageBox.Show("Asterisk* marked fields are mandatory", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //else
            //{
                toolStripMenuItem6.Enabled = true;
                toolStripMenuItem7.Enabled = true;

                /* this.Enabled = false;
                 this.demothread = new Thread(new ThreadStart(this.ThreadProcSafe));
                 this.demothread.Start();

               

                 // progressBar1.Visible = true;
                 this.backgroundWorker1.RunWorkerAsync();
                 this.button1.Enabled = false;
                 while (backgroundWorker1.IsBusy)
                 {
                     // progressBar1.Increment(1);
                     Application.DoEvents();
                 }
             */
                toolStripStatusLabel7.Text = "Inserting..!!";
                textBox36.Enabled = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;

                textBox25.Enabled = false;
                textBox27.Enabled = false;
                textBox8.Enabled = false;
                textBox3.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox1.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox6.Enabled = false;
                textBox14.Enabled = false;
                textBox13.Enabled = false;
                textBox4.Enabled = false;
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                createNewDatabase();
                connectToDatabase();
                createTable();
                if (comboBox1.Text == "Cultural Events")
                    fillTable();
                if (comboBox1.Text == "Pratibimb")
                    filltablepc();
                if (comboBox1.Text == "Parliamentary Debate")
                    filltablepd();

            //}

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            fetchcol();
            toolStripMenuItem6.Enabled = false;
            toolStripMenuItem7.Enabled = false;
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            reset_insert();
            textBox36.ResetText();
            textBox36.Enabled = false;
            //  button10.Visible = false;
            //  button11.Visible = false;
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Enabled = true;
            // textBox24.Enabled = true;
            // textBox1.Enabled = true;
            textBox3.Enabled = true;
            // comboBox1.Enabled = true;
            // textBox32.Enabled = true;
            // textBox33.Enabled = true;
            //   radioButton1.Enabled = true;
            //   radioButton2.Enabled = true;
            //  button1.Enabled = true;
            // textBox1.Text = hei.ToString();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                toolStripStatusLabel9.Text = "Fetching data..!!";
                //   button8.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                textBox2.Enabled = true;
                //   button9.Visible = true;
                toolStripMenuItem2.Enabled = true;
                if (comboBox3.Text == "Cultural Events")
                {

                    fetch();
                }
                if (comboBox3.Text == "Pratibimb")
                {

                    fetchpc15();
                }
                if (comboBox3.Text == "Parliamentary Debate")
                {

                    fetchpd15();
                }

            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox2.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            connectToDatabase();
            if (textBox5.Text != "")
            {
                toolStripStatusLabel4.Text = "Updating...!!";
                if (comboBox3.Text == "Cultural Events")
                {
                    update();
                    fetch();
                }
                if (comboBox3.Text == "Pratibimb")
                {
                    updatepc();
                    fetchpc15();
                }
                if (comboBox3.Text == "Parliamentary Debate")
                {
                    updatepd();
                    fetchpd15();
                }

                enabled_false();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //  button3.Visible = false;
            // button2.Visible = false;
            enabled_false();
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox10.Visible = false;
        }

        private void deleteAllRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectToDatabase();



            try
            {
                string stm = "select *from patient";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);
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
                    deleterecords();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
            //toolStripStatusLabel3.Text = "Done..!!";

            //string cs = @"server=localhost;userid=root;
            // password=spartan;database=inform";







        }
        private void deleterecords()
        {
            string stm1 = "delete from patient";
            //  MySqlCommand cmd = new MySqlCommand(stm, conn);
            SQLiteCommand command1 = new SQLiteCommand(stm1, m_dbConnection);

            command1.ExecuteNonQuery();
            MessageBox.Show("All records deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            toolStripMenuItem6.Enabled = false;
            toolStripMenuItem7.Enabled = false;
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            reset_insert();
            textBox36.ResetText();
            textBox36.Enabled = false;
            //  button10.Visible = false;
            //  button11.Visible = false;
            textBox25.Enabled = true;
            textBox27.Enabled = true;
            textBox6.Enabled = true;
            textBox4.Enabled = true;
            // textBox7.Enabled = true;
            // textBox24.Enabled = true;
            // textBox1.Enabled = true;
            textBox3.Enabled = true;
            //  comboBox1.Enabled = true;
            //  textBox32.Enabled = true;
            //  textBox33.Enabled = true;
            //  radioButton1.Enabled = true;
            //  radioButton2.Enabled = true;
            //  button1.Enabled = true;
            //  textBox1.Text = hei.ToString();


            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            textBox2.ResetText();
            textBox2.Enabled = false;
            pictureBox10.Visible = false;
            textBox5.ResetText();
            textBox22.ResetText();
            //   textBox23.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            //   textBox26.ResetText();
            textBox19.ResetText();
            //   textBox18.ResetText();
            //   textBox29.ResetText();
            textBox30.ResetText();
            //textBox31.ResetText();
            //  radioButton8.Checked = false;
            //   radioButton7.Checked = false;

        }
        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            deleterec();
            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox10.Visible = false;
            pictureBox9.Visible = false;
            textBox2.ResetText();
            textBox2.Enabled = false;
            textBox5.ResetText();
            textBox22.ResetText();
            textBox7.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            //  textBox26.ResetText();
            textBox19.ResetText();
            //  textBox18.ResetText();
            //  textBox29.ResetText();
            textBox30.ResetText();
            //textBox31.ResetText();
            //  radioButton8.Checked = false;
            //  radioButton7.Checked = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String s;
            s = textBox7.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox3.Text = comboBox2.Text;
        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            comboBox2.ResetText();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enabled_true1();
            if (comboBox1.Text == "Pratibimb")
            {
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox3.Text = "NIT PATNA";
            }
            if (comboBox1.Text == "Cultural Event")
            {
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.ResetText();
            }
            if (comboBox1.Text == "Parliamentary Debate")
            {
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.ResetText();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label10.Text = DateTime.Now.ToString();
        }

        private void textBox4_TextChanged_3(object sender, System.EventArgs e)
        {

        }

        private void tabPage1_Click_2(object sender, System.EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            reset_all();
            comboBox2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            fetchcol();
            toolStripMenuItem6.Enabled = false;
            toolStripMenuItem7.Enabled = false;
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            reset_insert();
            textBox36.ResetText();
            textBox36.Enabled = false;
           
            //enabled_true1();
            if (comboBox1.Text == "Pratibimb")
            {
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox3.Text = "NIT PATNA";
            }
            if (comboBox1.Text == "Cultural Events")
            {
                enabled_false2();
                enabled_true2();
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.ResetText();
            }
            if (comboBox1.Text == "Parliamentary Debate")
            {
                enabled_true1();
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.ResetText();
            }
            pictureBox3.Enabled = true;
        }

        private void textBox25_TextChanged_2(object sender, System.EventArgs e)
        {
            String s;
            s = textBox25.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox27_TextChanged_2(object sender, System.EventArgs e)
        {
            String s;
            s = textBox27.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox6_TextChanged_3(object sender, System.EventArgs e)
        {
            String s;
            s = textBox6.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            textBox3.Text = comboBox2.Text;
        }

        private void pictureBox4_Click_1(object sender, System.EventArgs e)
        {
            reset_all();
            comboBox2.Items.Clear();
            comboBox6.Items.Clear();
            comboBox5.Items.Clear();
            fetchcol();
            fetchcol1();
            toolStripMenuItem6.Enabled = false;
            toolStripMenuItem7.Enabled = false;
            saveToDocToolStripMenuItem2.Enabled = false;
            printToolStripMenuItem2.Enabled = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            
            textBox36.ResetText();
            textBox36.Enabled = false;


            if (comboBox1.Text == "Cultural Events")
            {
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox14.Enabled = false;
                textBox13.Enabled = false;
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                textBox27.Enabled = false;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox25.Enabled = true;
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.ResetText();
                textBox6.ResetText();
                textBox25.ResetText();
                textBox1.ResetText();
                textBox3.ResetText();
            }
            if (comboBox1.Text == "Parliamentary Debate")
            {
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                textBox14.Enabled = true;
                textBox13.Enabled = true;
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                textBox27.Enabled = true;
                textBox4.Enabled = true;
                textBox6.Enabled = true;
                textBox25.Enabled = true;
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.ResetText();
                textBox6.ResetText();
                textBox25.ResetText();
                textBox1.ResetText();
                textBox3.ResetText();
                textBox8.ResetText();
                textBox9.ResetText();
                textBox10.ResetText();
                textBox11.ResetText();
                textBox12.ResetText();
                textBox14.ResetText();
                textBox13.ResetText();
                textBox15.ResetText();
                textBox16.ResetText();
                textBox27.ResetText();
            }
              pictureBox3.Enabled = true;
        }

        private void label10_Click_2(object sender, System.EventArgs e)
        {

            if (monthCalendar1.Visible == false)
            {
                monthCalendar1.Show();
            }
            else
            {
                monthCalendar1.Hide();
            }
        }

        private void pictureBox2_Click_1(object sender, System.EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox36.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void pictureBox1_Click_1(object sender, System.EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void toolStripMenuItem14_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Specify the extensions allowed
            saveFileDialog1.Filter = "Microfost Word Document|.doc";
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //Set default extension as .txt
            saveFileDialog1.DefaultExt = ".doc";

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();

            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                //Create a file stream using the file name
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);

                //Create a writer that will write to the stream
                StreamWriter writer = new StreamWriter(fs);
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox36.Text);
                //Write the contents of the text box to the stream
                writer.Write(sb.ToString());
                //Close the writer and the stream
                writer.Close();
            }
        }

        private void toolStripMenuItem15_Click(object sender, System.EventArgs e)
        {
            printPreviewDialog2.Document = printDocument2;
            if (printPreviewDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void toolStripMenuItem16_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox7.Items.Clear(); comboBox8.Items.Clear();
                       fetchcol1();

            textBox5.Enabled = true;
            textBox5.ResetText();
            textBox7.ResetText();
            textBox22.ResetText();
            textBox23.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            textBox18.ResetText();
            textBox17.ResetText();
            textBox24.ResetText();
            textBox23.ResetText();
            textBox26.ResetText();
            textBox33.ResetText();
            textBox32.ResetText();
            textBox31.ResetText();
            //  textBox26.ResetText();
            textBox19.ResetText();
            //  textBox18.ResetText();
            textBox21.ResetText();
            textBox24.ResetText();
            textBox29.ResetText();
            textBox30.ResetText();
        }

        private void textBox5_TextChanged_2(object sender, System.EventArgs e)
        {
            onlynum();
        }

        private void pictureBox5_Click_1(object sender, System.EventArgs e)
        {
            textBox2.ResetText();
            textBox22.Enabled = false;
            textBox21.Enabled = false;
            textBox7.Enabled = false;
            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox28.Enabled = false;
            if (textBox5.Text != "")
            {
                toolStripStatusLabel9.Text = "Fetching data..!!";
                //   button8.Visible = true;
                pictureBox8.Visible = true;
                pictureBox9.Visible = true;
                textBox2.Enabled = true;
                //   button9.Visible = true;
                toolStripMenuItem2.Enabled = true;
                if (comboBox3.Text == "Cultural Events")
                {

                    fetch();
                }
                if (comboBox3.Text == "Pratibimb")
                {

                    fetchpc15();
                }
                if (comboBox3.Text == "Parliamentary Debate")
                {

                    fetchpd15();
                }

            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Advanced ad = new Advanced();
            ad.Show();
        }

        private void textBox22_TextChanged_2(object sender, System.EventArgs e)
        {

            String s;
            s = textBox22.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox21_TextChanged_2(object sender, System.EventArgs e)
        {
           
        }

        private void textBox7_TextChanged_1(object sender, System.EventArgs e)
        {
            
        }

        private void textBox20_TextChanged_2(object sender, System.EventArgs e)
        {
            String s;
            s = textBox20.Text;
            foreach (char c in s)
            {
                if (Char.IsLetter(c))
                {
                    MessageBox.Show("Enter appropriate value(Only digits)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void pictureBox7_Click_1(object sender, System.EventArgs e)
        {
            connectToDatabase();
            if (textBox5.Text != "")
            {
                toolStripStatusLabel4.Text = "Updating...!!";
                if (comboBox3.Text == "Cultural Events")
                {
                    update();
                    fetch();
                }
                if (comboBox3.Text == "Pratibimb")
                {
                    updatepc();
                    fetchpc15();
                }
                if (comboBox3.Text == "Parliamentary Debate")
                {
                    updatepd();
                    fetchpd15();
                }

                enabled_false();
            }
            else
            {
                MessageBox.Show("Enter the ID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pictureBox6_Click_1(object sender, System.EventArgs e)
        {
            //  button3.Visible = false;
            // button2.Visible = false;
            enabled_false();
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox10.Visible = false;
        }

        private void pictureBox10_Click_1(object sender, System.EventArgs e)
        {
            if(comboBox3.Text=="Cultural Events")
            deleterec();
            if (comboBox3.Text == "Pratibimb")
                deleterecpc();
            if (comboBox3.Text == "Parliamentary Debate")
                deleterecpd();
            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox10.Visible = false;
            pictureBox9.Visible = false;
            textBox2.ResetText();
            textBox2.Enabled = false;
            textBox5.ResetText();
            textBox22.ResetText();
            textBox7.ResetText();
            textBox21.ResetText();
            textBox20.ResetText();
            textBox28.ResetText();
            //  textBox26.ResetText();
            textBox19.ResetText();
            //  textBox18.ResetText();
            //  textBox29.ResetText();
            textBox30.ResetText();
            //textBox31.ResetText();
            //  radioButton8.Checked = false;
            //  radioButton7.Checked = false;
        }

        private void toolStripMenuItem2_Click_1(object sender, System.EventArgs e)
        {
            fetchcol();
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;
            pictureBox10.Visible = true;
            toolStripStatusLabel1.Text = "Edit the data";
            if (comboBox3.Text == "Cultural Events")
                ena_tm();
            if (comboBox3.Text == "Parliamentary Debate")
                ena_t();
        }

        private void toolStripMenuItem3_Click_1(object sender, System.EventArgs e)
        {
            editToolStripMenuItem2.Enabled = false;
            // button9.Visible = false;
            // button8.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            textBox2.ResetText();
            textBox7.ResetText();
            textBox2.Enabled = false;
            pictureBox10.Visible = false;
            textBox5.ResetText();
            textBox22.ResetText();
            textBox22.Enabled = false;
              textBox23.ResetText();
              textBox23.Enabled = false;
            textBox21.ResetText();
            textBox21.Enabled = false;
            textBox20.ResetText();
            textBox20.Enabled = false;
            textBox28.ResetText();
            textBox28.Enabled = false;
            textBox18.ResetText();
            textBox18.Enabled = false;
            textBox17.ResetText();
            textBox17.Enabled = false;
            textBox24.ResetText();
            textBox24.Enabled = false;
            textBox23.ResetText();
            textBox23.Enabled = false;
            textBox26.ResetText();
            textBox26.Enabled = false;
            textBox33.ResetText();
            textBox33.Enabled = false;
            textBox32.ResetText();
            textBox32.Enabled = false;
            textBox31.ResetText();
            textBox31.Enabled = false;
            //  textBox26.ResetText();
            textBox19.ResetText();
            textBox19.Enabled = false;
            //  textBox18.ResetText();
            textBox21.ResetText();
            textBox21.Enabled = false;
            textBox24.ResetText();
            textBox24.Enabled = false;
             textBox29.ResetText();
             textBox29.Enabled = false;
             textBox30.Enabled = false;
            textBox30.ResetText();
            //textBox31.ResetText();
            //  radioButton8.Checked = false;
            //  radioButton7.Checked = false;

        }

        private void toolStripMenuItem4_Click_1(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click_2(object sender, System.EventArgs e)
        {
            connectToDatabase();
            if (comboBox1.Text == "Cultural Events")
                fetchmel();
            if (comboBox1.Text == "Pratibimb")
                fetchpc();
            if (comboBox1.Text == "Parliamentary Debate")
                fetchpd();
        }

        private void menuStrip10_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load_2(object sender, System.EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            connectToDatabase();
            createTable();
        }

        private void textBox18_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox26_TextChanged_1(object sender, System.EventArgs e)
        {

        }

        private void textBox31_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox29_TextChanged_1(object sender, System.EventArgs e)
        {

        }

        private void textBox28_TextChanged_2(object sender, System.EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, System.EventArgs e)
        {

        }
        private void ena_t()
        {
            textBox22.Enabled = true;
            textBox18.Enabled = true;
            textBox17.Enabled = true;
            textBox21.Enabled = true;
            textBox24.Enabled = true;
            textBox23.Enabled = true;
            textBox7.Enabled = true;
            textBox26.Enabled = true;
            textBox19.Enabled = true;
            textBox20.Enabled = true;
            textBox31.Enabled = true;
            textBox29.Enabled = true;
            textBox28.Enabled = true;
            textBox32.Enabled = true;
            textBox33.Enabled = true;
            textBox30.Enabled = true;
            comboBox4.Enabled = true;
            comboBox7.Enabled = true;
            comboBox8.Enabled = true;
        }
        private void ena_tm()
        {
            textBox22.Enabled = true;
            
            textBox21.Enabled = true;
          
            textBox7.Enabled = true;
           
            textBox20.Enabled = true;
           
            textBox28.Enabled = true;
           
            textBox30.Enabled = true;
            comboBox4.Enabled = true;
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox9.Text = comboBox5.Text;
        }

        private void comboBox6_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox10.Text = comboBox6.Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox21.Text = comboBox4.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox24.Text = comboBox7.Text;
        }

        private void tabPage2_Click_2(object sender, System.EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBox23.Text = comboBox8.Text;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            back = new Backup(this);
            back.Show();
        }

        private void button1_Click_3(object sender, System.EventArgs e)
        {
            export();
        }
        /* private void button1_Click(object sender, EventArgs e)
         {
             Fetch form1 = neString s;
            s = textBox1.Text;
            foreach (char c in s)
            {
                if (Char.IsNumber(c))
                {
                    MessageBox.Show("Enter appropriate values(Alphabets)", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }w Fetch();
             //form1.MdiParent = this;
             form1.Show();


         }

         private void button2_Click(object sender, EventArgs e)
         {
             Insert form2 = new Insert();
            // form2.MdiParent = this;
             form2.Show();
         }

        

       
     }*/
    }
}