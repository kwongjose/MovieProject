using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);//List of all Files in folder
                foreach(String M_File in files)
                {
                    FileToDataBase ftb = new FileToDataBase(M_File);
                }
                MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                //Gets MetaData from API foreach movie
                //break file path into path title year 
              
            }
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
            int M_ID = 0;//DUMMY VALUE!!!
            var form = new Movie_Info(M_ID);
            form.Show(this);
        }
        /*
         * 
         */
        private void Rescan_Folder_Click(object sender, EventArgs e)
        {
            //TODO:::Scans dir of movies for new movies
        }
        /*
        * 
        */
        private void Sort_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO::: FInds only movies in sel decade
        }
        /*
        * 
        */
        private void Sort_Rating_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///TODO::: Finds only movies of sel Rating rante ie 9 to 9.9
        }
       /*
       * 
       */
        private void Options_List_Click(object sender, EventArgs e)
        {
            //should do nothing 
        }
       /*
       * 
       */
        private void Default_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            con.NewDataBase();
        }
        /*
         * 
         * 
         */ 
        private void lastChanchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO::: Drops all recoreds and start over
        }
    }

    
}
