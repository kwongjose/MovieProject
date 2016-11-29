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
            LoadView(mov.Actors);
        }

       /*
        * load the actor view
        * 
        */
        private void LoadView(String a)
        {
            String[] alist = a.Split(',');
           
                ActorList.Items.AddRange(a.Split(','));
            
           
        } 
        /*
         * calls connection class and updates the movie row with new info
         * 
         */
        private void UpDate_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();

            for (int i = 0; i < ActorList.Items.Count; i++)
            {
                if (ActorList.GetItemChecked(i) )
                {
                    int aid = con.GetActorID((String)ActorList.Items[i] );
                    con.DeleteFromMovieActor(M_Id, aid);
                }
            }

            String Path = Tpath.Text;
            if (checkBox1.Checked)
            {
                FileToDataBase ftb = new FileToDataBase(ImdbId.Text, M_Id, Nres.Text);
            }
            else
            {
                if (con.UpDateRow(M_Id, Title.Text, Year.Text, Genra.Text, Rating.Text, Length.Text, Plot.Text, Nres.Text) )
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
        /*
         * add an actor to a movie
         * 
         */ 
        private void Add_Click(object sender, EventArgs e)
        {
           
            if(AddActorItem.Text.Length > 1)
            {
                string actorname = AddActorItem.Text;
                ConnectionClass con = new ConnectionClass();
                int aid = con.GetActorID(actorname.Trim() );
                if(aid != 0 )//actor in db
                {
                    
                    aid = con.GetActorID(actorname.Trim() );
                    con.Insert_MovieActor(M_Id, aid);
                    ActorList.Items.Add(actorname.Trim() );
                }
                else//actor not in db
                {
                    con.InsertNewActor(actorname.Trim() );
                    aid = con.GetActorID(actorname.Trim() );
                    con.Insert_MovieActor(M_Id, aid);
                    ActorList.Items.Add(actorname.Trim() );
                }
            }
        }//end
    }
}
