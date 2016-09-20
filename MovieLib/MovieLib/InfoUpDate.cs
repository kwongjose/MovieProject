﻿using System;
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
        public UpdateRow(int Mid)
        {
            InitializeComponent();
            M_Id = Mid;
            ConnectionClass con = new ConnectionClass();
            String[] paths = con.GetMovieData(Mid);
            Title.Text = paths[0];
            Year.Text = paths[1];
            Genra.Text = paths[2];
            Rating.Text = paths[3];
            Length.Text = paths[4];
            Nres.Text = paths[5];
            Plot.Text = paths[6];
            Tpath.Text = paths[7];
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
                //TODO:: Make API Call with IMDB ID
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