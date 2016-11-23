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
    public partial class UpdateRow : Form
    {
        private int M_Id;
        private Form1 form;
        public UpdateRow(int Mid, Form1 forms)
        {
            InitializeComponent();
            M_Id = Mid;
            form = forms;
            ConnectionClass con = new ConnectionClass();
            Movie mov = con.GetMovieData(Mid);
            Title.Text = mov.Title;
            Year.Text = mov.Year;
            Genra.Text = mov.Genre;
            Rating.Text = mov.imdbRating;
            Length.Text = mov.Runtime;
            Nres.Text = mov.Res;
            Plot.Text = mov.Plot;
            Tpath.Text = mov.Path;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        /*
         * calls connection class and updates the movie row with new info
         * 
         */
        private void UpDate_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            String Path = Tpath.Text;
            if (checkBox1.Checked)
            {
                FileToDataBase ftb = new FileToDataBase(ImdbId.Text, M_Id, Nres.Text);
            }
            else
            {
                if (con.UpDateRow(M_Id, Title.Text, Year.Text, Genra.Text, Rating.Text, Length.Text, Plot.Text, Nres.Text))
                {
                    MessageBox.Show("Row Updated", "Message");
                }
                else
                {
                    MessageBox.Show("There Was An Error", "Message");
                }
            }
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
