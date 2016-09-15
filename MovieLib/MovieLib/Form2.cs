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
            String[] paths = con.GetMoiveByID(Mid);
            Tpath.Text = paths[2];
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
           if( con.UpDateRow(M_Id, Title.Text, Year.Text, Genra.Text, Rating.Text, Length.Text, Plot.Text))
            {
                MessageBox.Show("Row Updated", "Message");
            }
           else
            {
                MessageBox.Show("There Was An Error", "Message");
            }
        }
    }
}
