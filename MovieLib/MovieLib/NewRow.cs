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
            if (Imdb.Checked)
            {
                FileToDataBase ftb = new FileToDataBase(ImdbId.Text, Path.Text);
            }
            else
            {
                ConnectionClass con = new ConnectionClass();
                con.InsertNewRow(Mtitle.Text, Myear.Text, MGernra.Text, MRating.Text, Mlength.Text, MRes.Text, Mplot.Text, Path.Text);
                int Mid = con.GetRowID(Path.Text);
                int aid = 0;
                for(int i = 0; i < ActorList.Items.Count; i++)
                {
                    con.InsertNewActor((string)ActorList.Items[i]);
                    aid = con.GetActorID((string)ActorList.Items[i]);
                    con.Insert_MovieActor(Mid, aid);
                }

            }
            MessageBox.Show("Row Inserted!", "Message");
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        /*
         * add item to list
         * 
         */ 
        private void AddActor_Click(object sender, EventArgs e)
        {
            if(Actor_name.Text.Length > 2)
            {
                ActorList.Items.Add(Actor_name.Text);
            }
        }
    }
}
