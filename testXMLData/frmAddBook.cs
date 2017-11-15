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
    public partial class frmAddBook : Form
    {
        private Form1 HandledForm;
        public frmAddBook(Form1 frm1)
        {
            InitializeComponent();
            HandledForm = frm1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = Form1.dset.Tables[0].NewRow();
                row[0] = txtBkId.Text;
                row[1] = txtAuthor.Text;
                row[2] = txtTitle.Text;
                row[3] = txtGenre.Text;
                row[4] = Convert.ToDecimal(txtPrice.Text);
                row[5] = dtpPublishDate.Value;
                row[6] = txtDescription.Text;
                Form1.dset.Tables[0].Rows.Add(row);

                Form1.dset.WriteXml(Application.StartupPath + @"\Data\Books.xml");
                HandledForm.loadData(Form1.dset);

                MessageBox.Show(txtTitle.Text + " has been added", "Book Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
