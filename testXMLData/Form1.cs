using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testXMLData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static DataSet dset = new DataSet();
        public static DataTable table = new DataTable();
        public static string selectedID = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            dset.DataSetName = "catalog";
            this.button4.Enabled = false;
            this.button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dset.Tables.Clear();
                dataGridView1.DataSource = null;
                dset.ReadXml(Application.StartupPath + @"\Data\Books.xml");
                if (dset != null && dset.HasChanges())
                {
                    dataGridView1.DataSource = dset.Tables[0];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddBook addBook = new frmAddBook(this);
            addBook.Show();
        }

        public void loadData(DataSet ds)
        {
            dset.Tables.Clear();
            dataGridView1.DataSource = null;
            ds.ReadXml(Application.StartupPath + @"\Data\Books.xml");
            if (ds != null && ds.HasChanges())
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                selectedID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                this.button4.Enabled = true;
                this.button5.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmModifyBook modifyBook = new frmModifyBook(this);
            modifyBook.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    var tempRow = dset.Tables[0].Rows[i];
                    for (int j = 0; j < dset.Tables[0].Rows.Count; j++)
                    {
                        DataRow rows = dset.Tables[0].Rows[j];
                        if (selectedID.ToString() == rows[0].ToString())
                        {
                            dset.Tables[0].Rows.Remove(rows);
                            break;
                        }
                    }
                }

                dset.WriteXml(Application.StartupPath + @"\Data\Books.xml");
                loadData(dset);
                MessageBox.Show("Row has been deleted!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                selectedID = dataGridView1.Rows[index].Cells[0].Value.ToString();
                this.button4.Enabled = true;
                this.button5.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
