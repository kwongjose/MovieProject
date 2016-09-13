using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * class shows the title of the movie and plot taken from DB
 * button opens up default program to play movie
 * 
 */ 
namespace MovieLib
{
    public partial class Movie_Info : Form
    {
        public String File_Path, Movie_Name;
        public Movie_Info(int ID)
        {
            InitializeComponent();
        }

        private void Watch_Movie_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@File_Path);//open selected movie
        }
    }
}
