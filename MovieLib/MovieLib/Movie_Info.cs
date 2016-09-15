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
        public String File_Path, Movie_Name, Movie_Plot;

        private void M_Plot_TextChanged(object sender, EventArgs e)
        {

        }

        public Movie_Info(int ID)
        {
            InitializeComponent();
            ConnectionClass con = new ConnectionClass();
            String[] Movie_info = con.GetMoiveByID(ID);
            Movie_Name = Movie_info[0];
            Movie_Plot = Movie_info[1];
            File_Path = Movie_info[2];
            M_Title.Font = new Font(M_Title.Font.FontFamily, 16);
            M_Title.Text = Movie_Name;
            M_Plot.Font = new Font(M_Plot.Font.FontFamily, 12);
            M_Plot.Text = Movie_Plot;
        }

        private void Watch_Movie_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@File_Path);//open selected movie
        }
    }
}
