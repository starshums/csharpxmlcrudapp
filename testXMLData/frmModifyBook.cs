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
    public partial class frmModifyBook : Form
    {
        private Form1 HandledForm;
        public frmModifyBook(Form1 frm1)
        {
            InitializeComponent();
            HandledForm = frm1;
        }

        private void frmModifyBook_Load(object sender, EventArgs e)
        {
            try
            {
                string bookName = "";
                foreach (DataRow row in Form1.dset.Tables[0].Rows)
                {
                    if (Form1.selectedID.ToString() == row[0].ToString())
                    {
                        bookName = row[2].ToString();
                        this.txtBkId.Text = row[0].ToString();
                        this.txtAuthor.Text = row[1].ToString();
                        this.txtTitle.Text = row[2].ToString();
                        this.txtGenre.Text = row[3].ToString();
                        this.txtPrice.Text = row[4].ToString();
                        this.dtpPublishDate.Value = Convert.ToDateTime(row[5].ToString());
                        this.txtDescription.Text = row[6].ToString();
                    }
                }
                this.Text += " " + bookName;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Form1.dset.Tables[0].Rows.Count; i++)
                {
                    var tempRow = Form1.dset.Tables[0].Rows[i];
                    for (int j = 0; j < Form1.dset.Tables[0].Rows.Count; j++)
                    {
                        DataRow rows = Form1.dset.Tables[0].Rows[j];
                        if (Form1.selectedID.ToString() == rows[0].ToString())
                        {
                            rows[0] = txtBkId.Text;
                            rows[1] = txtAuthor.Text;
                            rows[2] = txtTitle.Text;
                            rows[3] = txtGenre.Text;
                            rows[4] = Convert.ToDecimal(txtPrice.Text);
                            rows[5] = dtpPublishDate.Value;
                            rows[6] = txtDescription.Text;
                            break;
                        }
                    }
                }

                Form1.dset.WriteXml(Application.StartupPath + @"\Data\Books.xml");
                HandledForm.loadData(Form1.dset);
                MessageBox.Show("Book has been modified!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
