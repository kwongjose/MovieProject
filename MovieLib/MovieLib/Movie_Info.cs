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

      

        public Movie_Info(int ID)
        {
            InitializeComponent();
            ConnectionClass con = new ConnectionClass();
            // String[] Movie_info = con.GetMoiveByID(ID);
            List<string> actors = con.GetActorsFromMovie(ID);
            Movie mov = con.GetMovieData(ID);
            Movie_Name = mov.Title;
            Movie_Plot = mov.Plot;
            File_Path = mov.Path;
            //Title_Lable.Font = new Font(Title_Lable.Font.FontFamily, 16);
            Title_Lable.Text = Movie_Name;
            //M_Plot.Font = new Font(M_Plot.Font.FontFamily, 12);
            M_Plot.Text = Movie_Plot;
            Genre_Lable.Text = mov.Genre;
            Year_Lable.Text = mov.Year;
            Rating_Lable.Text = mov.imdbRating;
            /*
            Actors_Lable.Text = "";
            actors.ForEach(i => Actors_Lable.Text += i + ",");//I Like this line
            Actors_Lable.Text.TrimEnd(',');
            */
            ActorsBox.Text = "";
            String actorString = "";
            actors.ForEach(i => actorString += i + ", ");//I Like this line
            actorString = actorString.Substring(0, (actorString.Length - 2));
            ActorsBox.Text = actorString;

            Res_Lable.Text = mov.Res;
            runtime_Lable.Text = mov.Runtime;

            if (mov.Poster != null)
            {
                //NEED CODE FOR WHEN NO NETWORK
               
                    Movie_Poster.LoadAsync(mov.Poster);
                         
              
                Movie_Poster.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Watch_Movie_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@File_Path);//open selected movie
        }

        
    }
}
