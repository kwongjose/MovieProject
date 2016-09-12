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
{    /*
         * 
         */
    public partial class Form1 : Form
    {    /*
         * 
         */
        public Form1()
        {
            InitializeComponent();
        }
        /*
        * 
        */
        private void Load_Files_Click(object sender, EventArgs e)
        {

        }
        /*
        * 
        */
        private void Sort_Genres_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Sel_Genre = Sort_Genres.Text;
            System.Diagnostics.Debug.WriteLine(Sort_Genres.Text);
        }
        /*
        * 
        */
        private void Movies_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("TEST");
            var form = new Movie_Info();
            form.Show(this);
        }
        /*
         * 
         */
        private void Rescan_Folder_Click(object sender, EventArgs e)
        {

        }
        /*
        * 
        */
        private void Sort_Year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        * 
        */
        private void Sort_Rating_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       /*
       * 
       */
        private void Options_List_Click(object sender, EventArgs e)
        {

        }
       /*
       * 
       */
        private void Default_Click(object sender, EventArgs e)
        {

        }
    }
}
