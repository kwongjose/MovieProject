using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib
{
    public partial class NewRow : Form
    {
        public NewRow()
        {
           
            InitializeComponent();
        }
        /*
         * inserts a new row into the database
         * 
         */ 
        private void submitBtn_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            con.InsertNewRow(Mtitle.Text, Myear.Text, MGernra.Text, MRating.Text, Mlength.Text, MRes.Text, Mplot.Text, Path.Text);
            MessageBox.Show("Row Inserted!", "Message");
        }
    }
}
