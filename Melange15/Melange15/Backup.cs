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
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Melange15
{
    public partial class Backup : Form
    {
        int[] array;
        string[] strarr;
     private   SQLiteConnection m_dbConnection;
        int row;

        DataSet DS = new DataSet();
        DataTable dataTable = new DataTable();
        DataSet DS1 = new DataSet();
        DataTable dataTable1 = new DataTable();
        DataSet DS2= new DataSet();
        DataTable dataTable2 = new DataTable();
       private static string filepath;
        string path;
        Image image;
        int b = 1;
        string newpath;
        int isroot = 1;
        private static String str = "Hello";
        delegate void SetTextCall(String text);

        private Form1 form;
        string p;
        public Backup(Form1 f)
        {

            InitializeComponent();
            pictureBox1.Enabled = false;
            linkLabel3.Enabled = false;
            pictureBox6.Enabled = false;
            linkLabel5.Enabled = false;
            pictureBox8.Enabled = false;
            linkLabel4.Enabled = false;
            //  connectToDatabase();
            checkedListBox1.Visible = false;
            checkedListBox2.Visible = false;
            // linkLabel10.Visible = false;
            //  linkLabel9.Visible = false;
            //button1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            form = f;
            linkLabel2.Visible = false;
            // linkLabel6.Visible = false;
            //linkLabel7.Visible = false;
            // linkLabel8.Visible = false;
            toolTip1.SetToolTip(this.pictureBox4, "Select");
            toolTip1.SetToolTip(this.pictureBox3, "Cancel");
            toolTip1.SetToolTip(this.pictureBox5, "Go to the folder");
            toolTip1.SetToolTip(this.pictureBox2, "Delete Selected");
            toolTip1.SetToolTip(this.pictureBox7, "Cancel");
        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                b = 0;
                filepath = folderBrowserDialog1.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(filepath);
                if (d.Parent == null)
                {

                    MessageBox.Show("Path is:" + filepath, "Info", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Path is:" + filepath, "Info", MessageBoxButtons.OK);
                    isroot = 0;
                }
                label2.Visible = true;
                label3.Text = filepath;
            }
            else return;
            //button5.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path;

            if (b == 0 && isroot == 1)
            {
                path = @filepath + "Backup";
            }
            else if (b == 0 && isroot == 0)
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

        private void button3_Click(object sender, EventArgs e)
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            dataGridView1.Visible = false;

            toolStripStatusLabel1.Text = "Please Wait..Creating Backup!!";
            fetchall();
            savetoexcel();

            // progressBar1.Visible = true;
            MessageBox.Show("Backup successfully created", "Information", MessageBoxButtons.OK);
            toolStripStatusLabel1.Text = "Backup Successful";
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_ENABLED);
            // button1.Visible = true;
        }

        void connectToDatabase()
        {
            m_dbConnection = new SQLiteConnection("Data Source=Melange15n.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        void createTable()
        {
            connectToDatabase();
            ///SQLiteConnection.CreateFile("info.sqlite");
            string sql = "CREATE TABLE IF NOT EXISTS url1(ID INTEGER PRIMARY KEY  AUTOINCREMENT,Path nvarchar(100),filePath nvarchar(100),isb INTEGER,isRoot INTEGER,created_on Date,entry_time Time)";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            //m_dbConnection.Close();
        }
        private void fetchall()
        {
            connectToDatabase();
            DS1.Clear();
            dataTable1.Clear();
            DS.Clear();
            dataTable.Clear();
            try
            {


               



                string stm1 = "select *from melangenew";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm1, m_dbConnection);



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
                    savetoexcel();
                }
                else
                {

                    MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            catch (Exception ex)
            {
                
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
        }
        private void fetchallpd()
        {

            connectToDatabase();
            try
            {
                DS.Clear();
                dataTable.Clear();

                DS2.Clear();
                dataTable2.Clear();



                string stm = "select *from pd15n";
                //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);



                using (SQLiteDataAdapter da = new SQLiteDataAdapter(command))
                {

                    da.Fill(dataTable2);
                    da.Fill(DS2);

                }
                if (dataTable2.Rows.Count >= 1)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = dataTable2;
                    dataGridView1.DataMember = dataTable2.TableName;
                    //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    savetoexcelpd();
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
        }
        private void fetchallpc()
        {


            try
            {






                string stm = "select *from pc15";
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
                    savetoexcel();
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
        }
        private void insertpath()
        {

            //connectToDatabase();
            string sql = "insert into url1(Path,filePath,isb,isRoot,created_on,entry_time) values(@path,@filepath,@b,@root,@date,@time)";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm"));
            command.Parameters.AddWithValue("@path", path
                );
            command.Parameters.AddWithValue("@filepath", filepath
                );
            command.Parameters.AddWithValue("@root", isroot);
            command.Parameters.AddWithValue("@b", b);
            command.ExecuteNonQuery();
        }
        private void savetoexcel()
        {
            toolStripStatusLabel1.Text = "Please Wait..Creating Backup!!";
            string folderdate = DateTime.Now.ToString("yyyy-MM-dd hh_mm_ss");
            //if (comboBox3.Text == "Cutlural Events")
            //{
            //    if (b == 0 && isroot == 1)
            //    {
            //        path = @filepath + "Melange\\" + folderdate;
            //    }
            //    else if (b == 0 && isroot == 0)
            //    {
            //        path = @filepath + "\\Melange\\" + folderdate;
            //    }
            //    else
            //    {
            //        path = @"C:\Melange\" + folderdate;
            //    }
            //}
            //if (comboBox3.Text == "Parliamentary Debate")
            //{
            //    if (b == 0 && isroot == 1)
            //    {
            //        path = @filepath + "PD\\" + folderdate;
            //    }
            //    else if (b == 0 && isroot == 0)
            //    {
            //        path = @filepath + "\\PD\\" + folderdate;
            //    }
            //    else
            //    {
            //        path = @"C:\PD\" + folderdate;
            //    }
            //}


            if (b == 0 && isroot == 1)
            {
                path = @filepath + "Melange\\" + folderdate;
            }
            else if (b == 0 && isroot == 0)
            {
                path = @filepath + "\\Melange\\" + folderdate;
            }
            else
            {
                path = @"C:\Melange\" + folderdate;
            }
            if (!Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);

            }
            insertpath();

            
               string filename = @path + "\\backup_mel.xlsx";
           
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
                workbook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // save the application
                /* string fileName = String.Empty;
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
                     return;*/
                MessageBox.Show("Backup successfully created", "Information", MessageBoxButtons.OK);
                toolStripStatusLabel1.Text = "Backup Successful";
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
        private void savetoexcelpd()
        {
            toolStripStatusLabel1.Text = "Please Wait..Creating Backup!!";
            string folderdate = DateTime.Now.ToString("yyyy-MM-dd hh_mm_ss");
            //if (comboBox3.Text == "Cutlural Events")
            //{
            //    if (b == 0 && isroot == 1)
            //    {
            //        path = @filepath + "Melange\\" + folderdate;
            //    }
            //    else if (b == 0 && isroot == 0)
            //    {
            //        path = @filepath + "\\Melange\\" + folderdate;
            //    }
            //    else
            //    {
            //        path = @"C:\Melange\" + folderdate;
            //    }
            //}
            //if (comboBox3.Text == "Parliamentary Debate")
            //{
            //    if (b == 0 && isroot == 1)
            //    {
            //        path = @filepath + "PD\\" + folderdate;
            //    }
            //    else if (b == 0 && isroot == 0)
            //    {
            //        path = @filepath + "\\PD\\" + folderdate;
            //    }
            //    else
            //    {
            //        path = @"C:\PD\" + folderdate;
            //    }
            //}


            if (b == 0 && isroot == 1)
            {
                path = @filepath + "PD\\" + folderdate;
            }
            else if (b == 0 && isroot == 0)
            {
                path = @filepath + "\\PD\\" + folderdate;
            }
            else
            {
                path = @"C:\PD\" + folderdate;
            }
            if (!Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);

            }
            insertpath();


            string filename = @path + "\\backup_pd.xlsx";

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
                workbook.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // save the application
                /* string fileName = String.Empty;
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
                     return;*/
                MessageBox.Show("Backup successfully created", "Information", MessageBoxButtons.OK);
                toolStripStatusLabel1.Text = "Backup Successful";
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        /*   private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
           {
               button3.Enabled = true;
               Backup back = new Backup();
               back.Hide();
               this.Enabled = true;
               MessageBox.Show("Backup successfully created", "Information", MessageBoxButtons.OK);
           }
           */
        private void Backup_Load(object sender, EventArgs e)
        {
            // connectToDatabase();
            createTable();
            form = new Form1();
            form.Enabled = false;

            label2.Visible = false;
            dataGridView1.Visible = false;
            // EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
        }
        #region Globals

        internal const int SC_CLOSE = 0xF060;           //close button's code in windows api
        internal const int MF_GRAYED = 0x1;             //disabled button status (enabled = false)
        internal const int MF_ENABLED = 0x00000000;     //enabled button status
        internal const int MF_DISABLED = 0x00000002;    //disabled button status

        [DllImport("user32.dll")] //Importing user32.dll for calling required function
        private static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool Revert);

        /// HWND: An IntPtr typed handler of the related form
        /// It is used from the Win API "user32.dll"

        [DllImport("user32.dll")] //Importing user32.dll for calling required function again
        private static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);

        #endregion
        public void EnableCloseButton() //A standard void function to invoke EnableMenuItem()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_ENABLED);
        }

        public void DisableCloseButton() //A standard void function to invoke EnableMenuItem()
        {
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
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

        private void button4_Click(object sender, EventArgs e)
        {

            checkedListBox2.Visible = false;
            checkedListBox1.Visible = true;
            // pictureBox1.ResetText();
            //   releaseObject(image);

            // pictureBox1.Image = null;
            /*  if (b == 0 && isroot==1)
              {
                  path = @filepath + "Backup";
              }
              else if (b==0 && isroot == 0)
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
             */

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Backup saves all the records in the database in a Excel sheet.\nBackup is created in the default folder location('C:\\Backup').\nPress change location button to save the backup at different location.\nBackup can be deleted by deleting the folder.\nBackup creates a new folder Backup and save the file in it automatically", "Backup Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Backup_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Default folder is set to C:", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            b = 1;
            isroot = 1;
        }
        void print()
        {

            string sql = "select * from url1";
            SQLiteDataReader rdr;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection))
            {

                da.Fill(dataTable1);
                da.Update(dataTable1);
                da.Fill(DS1);
            }
            row = dataGridView2.Rows.Count;
            //label4.Text = i.ToString();
            if (dataTable1.Rows.Count >= 1)
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = dataTable1;
                dataGridView2.DataMember = dataTable.TableName;
                //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        void printHighscores()
        {
            connectToDatabase();
            int i = 0;
            string sql = "select * from url1";
            SQLiteDataReader rdr;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                i++;
            }
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection))
            {

                da.Fill(dataTable1);
                da.Update(dataTable1);
                da.Fill(DS1);
            }
            //label4.Text = i.ToString();
            if (dataTable1.Rows.Count >= 1)
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = dataTable1;
                dataGridView2.DataMember = dataTable.TableName;
                //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox7.Visible = true;
            }

            else
            {
                checkedListBox1.Visible = false;
                checkedListBox2.Visible = false;
                MessageBox.Show("No backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkLabel3.Enabled = true;
                pictureBox1.Enabled = true;
                pictureBox7.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            m_dbConnection.Close();
        }
        void printHighscores1()
        {
            connectToDatabase();
            int i = 0;
            string sql = "select * from url1";
            SQLiteDataReader rdr;
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                i++;
            }
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, m_dbConnection))
            {

                da.Fill(dataTable1);
                da.Update(dataTable1);
                da.Fill(DS1);
            }
            //label4.Text = i.ToString();
            if (dataTable1.Rows.Count >= 1)
            {
                dataGridView2.Visible = true;
                dataGridView2.DataSource = dataTable1;
                dataGridView2.DataMember = dataTable.TableName;
                //MessageBox.Show("No value in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox7.Visible = true;
                checkedListBox1.Visible = true;
                // pictureBox4.Visible = true;
                pictureBox3.Visible = true;
                linkLabel3.Enabled = true;
                pictureBox1.Enabled = true;
            }

            else
            {
                checkedListBox1.Visible = false;
                checkedListBox2.Visible = false;
                MessageBox.Show("No backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                linkLabel3.Enabled = true;
                pictureBox1.Enabled = true;
                pictureBox7.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            m_dbConnection.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            printHighscores();
            display();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = checkedListBox1.SelectedIndex;
            if (select != -1)
            {
                label5.Text = checkedListBox1.Items[select].ToString();
            }
            //linkLabel6.Visible = true;
            //linkLabel9.Visible = true;
            checkedListBox2.Visible = false;
            pictureBox4.Visible = true;
            pictureBox7.Visible = false;
            pictureBox3.Visible = true;
        }
        private void lastdel()
        {
            delete();
            deletefromdb();
            printHighscores();
            //refresh();
        }
        private void selectdel()
        {
            connectToDatabase();
            string sql = "select * from url1 where path=@path";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@path", label4.Text);
            SQLiteDataReader rdr;
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                label6.Text = rdr.GetString(1).ToString();

            }
            String newpath1 = label6.Text;
            DirectoryInfo dir = new DirectoryInfo(newpath1);

            if (Directory.Exists(newpath1))
            {

                DeleteDirectory(newpath1);
                MessageBox.Show("Directory successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Folder Doesnt Exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //refresh();

            m_dbConnection.Close();
        }
        private void clear()
        {
            row = dataGridView2.Rows.Count;
            array = new int[row];
            strarr = new string[row];
            StringBuilder sb = new StringBuilder();
            StringBuilder arr = new StringBuilder();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                // sb.Append(dataGridView1.Rows[i].Cells[1].Value.ToString());
                //sb.Append(Environment.NewLine);
                array[i] = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                strarr[i] = dataGridView2.Rows[i].Cells[1].Value.ToString();


                arr.Append(array[i]);
                arr.Append(Environment.NewLine);
                sb.Append(dataGridView2.Rows[i].Cells[1].Value.ToString());
                sb.Append(Environment.NewLine);
            }
        }
        private void display()
        {
            connectToDatabase();
            refresh();
            checkedListBox2.ResetText();
            dataTable1.Clear();
            printHighscores();

            row = dataGridView2.Rows.Count;
            array = new int[row];
            strarr = new string[row];
            StringBuilder sb = new StringBuilder();
            StringBuilder arr = new StringBuilder();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                // sb.Append(dataGridView1.Rows[i].Cells[1].Value.ToString());
                //sb.Append(Environment.NewLine);
                array[i] = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                strarr[i] = dataGridView2.Rows[i].Cells[1].Value.ToString();
                checkedListBox2.Items.Add(strarr[i]);

                arr.Append(array[i]);
                arr.Append(Environment.NewLine);
                sb.Append(dataGridView2.Rows[i].Cells[1].Value.ToString());
                sb.Append(Environment.NewLine);
            }
            m_dbConnection.Close();
        }
        private void delall()
        {
            connectToDatabase();
            for (int i = 0; i < row - 1; i++)
            {
                string sql = "select * from url1 where id=@num";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@num", array[i]);
                SQLiteDataReader rdr;
                rdr = command.ExecuteReader();
                if (rdr.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    // f = rdr.GetString(2).ToString();
                    //p = rdr.GetString(1).ToString();
                    sb.Append(rdr.GetString(1).ToString());
                    //  textBox1.Text = sb.ToString();
                    newpath = sb.ToString();

                }



                if (Directory.Exists(newpath))
                {

                    DeleteDirectory(newpath);
                    //  MessageBox.Show("Directory Exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    SQLiteDataReader rd;
                    string stm = "delete FROM url1 WHERE ID=@num";
                    SQLiteCommand com = new SQLiteCommand(stm, m_dbConnection);
                    com.Parameters.AddWithValue("@num", array[i]);

                    //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                    // cmd.Parameters.AddWithValue("@id", textBox5.Text);
                    com.ExecuteNonQuery();

                }
                else
                {


                    MessageBox.Show("Backup Doesnt exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            m_dbConnection.Close();
            printHighscores1();

            refresh();
        }
        private void delete()
        {
            connectToDatabase();
            SQLiteDataReader rdr = null;
            string stm = "SELECT * FROM url1 WHERE ID = ( SELECT MAX(ID) FROM url1)";
            SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

            //  MySqlCommand cmd = new MySqlCommand(stm, conn);
            // cmd.Parameters.AddWithValue("@id", textBox5.Text);
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                StringBuilder sb = new StringBuilder();
                // f = rdr.GetString(2).ToString();
                p = rdr.GetString(1).ToString();

                // textBox1.Text = sb.ToString();
                // filepathdb = sb.ToString();
            }




            // string folderdate = DateTime.Now.ToFileTime().ToString();

            //pictureBox1.Refresh();




            if (Directory.Exists(p))
            {

                DeleteDirectory(p);
                MessageBox.Show("Directory successfully deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Folder Doesnt Exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            m_dbConnection.Close();
            refresh();

        }
        private void deletefromdb()
        {
            connectToDatabase();
            SQLiteDataReader rdr = null;
            string stm = "delete FROM url1 WHERE ID = ( SELECT MAX(ID) FROM url1 )";
            SQLiteCommand command = new SQLiteCommand(stm, m_dbConnection);

            //  MySqlCommand cmd = new MySqlCommand(stm, conn);
            // cmd.Parameters.AddWithValue("@id", textBox5.Text);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
            //refresh();
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox1.SetItemChecked(ix, false);
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = checkedListBox2.SelectedIndex;
            if (select != -1)
            {
                label4.Text = checkedListBox2.Items[select].ToString();
            }
            //  linkLabel7.Visible = true;
            //  linkLabel8.Visible= true;
            // linkLabel10.Visible = true;
            pictureBox2.Visible = true;
            pictureBox5.Visible = true;
            pictureBox7.Visible = true;
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label5.Text == "Last Backup")
            {
                MessageBox.Show("Last del", "info", MessageBoxButtons.OK);
                lastdel();
            }
            if (label5.Text == "All Backups")
            {
                MessageBox.Show("All", "info", MessageBoxButtons.OK);
                delall();
            }

            if (label5.Text == "Choose from the list")
            {
                MessageBox.Show("select", "info", MessageBoxButtons.OK);
                checkedListBox2.Visible = true;
                display();
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            display();
        }

        private void checkedListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int select = checkedListBox2.SelectedIndex;
            if (select != -1)
            {
                label4.Text = checkedListBox2.Items[select].ToString();
            }
            //  linkLabel7.Visible = true;
            //  linkLabel8.Visible= true;
            // linkLabel10.Visible = true;
            pictureBox2.Visible = true;
            pictureBox5.Visible = true;
            pictureBox7.Visible = true;
        }

        private void checkedListBox2_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectdel();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataTable1.Clear();
            DS1.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            refresh();

        }
        private void refresh()
        {
            connectToDatabase();
            checkedListBox2.Items.Clear();
            dataTable1.Clear();
            DS1.Clear();
            for (int i = 0; i < row - 1; i++)
            {
                string sql = "select * from url1 where id=@num";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.Parameters.AddWithValue("@num", array[i]);
                SQLiteDataReader rdr1;
                rdr1 = command.ExecuteReader();
                if (rdr1.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    // f = rdr.GetString(2).ToString();
                    //p = rdr.GetString(1).ToString();
                    sb.Append(rdr1.GetString(1).ToString());
                    //  textBox1.Text = sb.ToString();
                    newpath = sb.ToString();



                    if (Directory.Exists(newpath))
                    {

                        //DeleteDirectory(p);
                        //MessageBox.Show("Directory Exists", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        SQLiteDataReader rd1;
                        string stm = "delete FROM url1 WHERE ID=@num";
                        SQLiteCommand com = new SQLiteCommand(stm, m_dbConnection);
                        com.Parameters.AddWithValue("@num", array[i]);

                        //  MySqlCommand cmd = new MySqlCommand(stm, conn);
                        // cmd.Parameters.AddWithValue("@id", textBox5.Text);
                        com.ExecuteNonQuery();

                        // MessageBox.Show("Deleted from db", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                }
            }
            m_dbConnection.Close();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            dataTable1.Clear();
            printHighscores();
            checkedListBox2.Visible = true;
            display();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sql = "select * from url1 where path=@path";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@path", label4.Text);
            SQLiteDataReader rdr;
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                label6.Text = rdr.GetString(1).ToString();

            }
            String newpath1 = label6.Text;
            DirectoryInfo dir = new DirectoryInfo(newpath1);

            if (Directory.Exists(newpath1))
            {
                System.Diagnostics.Process.Start("explorer.exe", newpath1);
            }
            else
            {
                MessageBox.Show("Directory doesnt exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                b = 0;
                filepath = folderBrowserDialog1.SelectedPath;
                DirectoryInfo d = new DirectoryInfo(filepath);
                if (d.Parent == null)
                {

                    MessageBox.Show("Path is:" + filepath, "Info", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Path is:" + filepath, "Info", MessageBoxButtons.OK);
                    isroot = 0;
                }
                label2.Visible = true;
                label3.Text = filepath;
            }
            else return;
            linkLabel2.Visible = true;
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Default folder is set to C:", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            b = 1;
            isroot = 1;
            label2.Visible = false;
            label3.Visible = false;
            linkLabel2.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DS.Clear();
            dataTable.Clear();
            //connectToDatabase();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            dataGridView1.Visible = false;

            checkedListBox2.Visible = false;
            pictureBox7.Visible = false;

            if (comboBox3.Text == "Cultural Events")
                fetchall();
            if (comboBox3.Text == "Pratibimb")
                fetchallpc();
            if (comboBox3.Text == "Parliamentary Debate")
                fetchallpd();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkedListBox2.Items.Clear();
            dataTable1.Clear();
            // printHighscores();
            checkedListBox2.Visible = true;
            display();
            // pictureBox7.Visible = true;
            // linkLabel10.Visible = true;
            checkedListBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            linkLabel3.Enabled = true;
            // pictureBox7.Visible = true;
            pictureBox1.Enabled = true;

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (label5.Text == "Last Backup")
            {

                lastdel();
            }
            if (label5.Text == "All Backups")
            {

                delall();
            }

            if (label5.Text == "Choose from the list")
            {

                checkedListBox2.Visible = true;
                display();
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sql = "select * from url1 where path=@path";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@path", label4.Text);
            SQLiteDataReader rdr;
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                label6.Text = rdr.GetString(1).ToString();

            }
            String newpath1 = label6.Text;
            DirectoryInfo dir = new DirectoryInfo(newpath1);

            if (Directory.Exists(newpath1))
            {
                System.Diagnostics.Process.Start("explorer.exe", newpath1);
            }
            else
            {
                MessageBox.Show("Directory doesnt exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectdel();
            display();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel3.Enabled = false;
            pictureBox1.Enabled = false;
            connectToDatabase();
            /// display();
            printHighscores1();
            checkedListBox2.Visible = false;
            refresh();
            // checkedListBox1.Visible = true;
            // linkLabel9.Visible = true;
            // pictureBox3.Visible = true;
            pictureBox2.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            m_dbConnection.Close();
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //  linkLabel8.Visible = false;
            //  linkLabel7.Visible = false;
            //  linkLabel10.Visible = false;
            checkedListBox2.Items.Clear();
            checkedListBox2.Visible = false;
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //linkLabel6.Visible = false;
            checkedListBox1.Visible = false;
            // linkLabel9.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DS.Clear();
            dataTable.Clear();
            DS2.Clear();
            dataTable2.Clear();
            //connectToDatabase();
            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_GRAYED);
            dataGridView1.Visible = false;

            checkedListBox2.Visible = false;
            pictureBox7.Visible = false;

            if (comboBox3.Text == "Cultural Events")
                fetchall();
            if (comboBox3.Text == "Pratibimb")
                fetchallpc();
            if (comboBox3.Text == "Parliamentary Debate")
                fetchallpd();

            //savetoexcel();

            // progressBar1.Visible = true;

            EnableMenuItem(GetSystemMenu(this.Handle, false), SC_CLOSE, MF_ENABLED);
            // button1.Visible = true;
            m_dbConnection.Close();
            // button1.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            if (label5.Text == "All Backups")
            {

                if (MessageBox.Show("Delete all the files?", "Manage Space", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    display();

                    delall();
                    checkedListBox1.Visible = false;
                    checkedListBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                    pictureBox7.Visible = false;
                    pictureBox1.Enabled = true;

                    linkLabel3.Enabled = true;
                }
                else
                    return;

            }

            if (label5.Text == "Choose from the list")
            {


                checkedListBox2.Visible = true;
                pictureBox7.Visible = true;
                display();


            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //linkLabel6.Visible = false;
            checkedListBox1.Visible = false;
            // checkedListBox1.ClearSelected();
            while (checkedListBox1.CheckedIndices.Count > 0)
            {
                checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            }
            // linkLabel9.Visible = false;
            pictureBox1.Enabled = true;
            pictureBox7.Visible = false;
            pictureBox5.Visible = false;
            pictureBox2.Visible = false;
            checkedListBox2.Visible = false;
            linkLabel3.Enabled = true;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            connectToDatabase();
            string sql = "select * from url1 where path=@path";

            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.Parameters.AddWithValue("@path", label4.Text);
            SQLiteDataReader rdr;
            rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                label6.Text = rdr.GetString(1).ToString();

            }
            String newpath1 = label6.Text;
            DirectoryInfo dir = new DirectoryInfo(newpath1);

            if (Directory.Exists(newpath1))
            {
                System.Diagnostics.Process.Start("explorer.exe", newpath1);
            }
            else
            {
                MessageBox.Show("Directory doesnt exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            m_dbConnection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all the files?", "Manage Space", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                selectdel();
                display();
            }
            else
                return;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // linkLabel8.Visible = false;
            // linkLabel7.Visible = false;
            // linkLabel10.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox2.Visible = false;
            checkedListBox2.Items.Clear();
            checkedListBox2.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            dataTable1.Clear();
            // printHighscores();
            checkedListBox2.Visible = true;
            display();
            // pictureBox7.Visible = true;
            // linkLabel10.Visible = true;
            checkedListBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            linkLabel3.Enabled = true;
            // pictureBox7.Visible = true;
            pictureBox1.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            linkLabel3.Enabled = false;
            pictureBox1.Enabled = false;
            connectToDatabase();
            /// display();
            printHighscores1();
            checkedListBox2.Visible = false;
            refresh();
            // checkedListBox1.Visible = true;
            // linkLabel9.Visible = true;
            // pictureBox3.Visible = true;
            pictureBox2.Visible = false;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            m_dbConnection.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
            linkLabel3.Enabled = true;
            pictureBox6.Enabled = true;
            linkLabel5.Enabled = true;
            pictureBox8.Enabled = true;
            linkLabel4.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DS.Clear();
            dataTable.Clear();
            pictureBox1.Enabled = true;
            linkLabel3.Enabled = true;
            pictureBox6.Enabled = true;
            linkLabel5.Enabled = true;
            pictureBox8.Enabled = true;
            linkLabel4.Enabled = true;
        }

        private void checkedListBox2_ItemCheck_2(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
                for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                    if (e.Index != ix) checkedListBox2.SetItemChecked(ix, false);
        }
    }
}
