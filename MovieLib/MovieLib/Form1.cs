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
using System.Threading;

namespace MovieLib
{    /*
         * 
         */
    public partial class Form1 : Form
    {
        public List<String> BadFile = new List<string>();
        BackgroundWorker worker;
        int prog = 0;
        int fn;
        // ProgressBar bar;
        /*
         * 
         */
        public Form1()
        {
            InitializeComponent();
            progressBar.Visible = false;
            //call database and load table
            ConnectionClass con = new ConnectionClass();
            con.NewDataBase();
            DataTable dt = con.SelAllMovies();
            Movies_Data.Columns.Clear();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window


        }

        private void Sorter(object sender, DataGridViewSortCompareEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("test");
        }

        /*
        * User Selects a folder to scan.
        * Returns ALL files in folder so only movie/video files should be in the folder
        */
        private void Load_Files_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String[] FilterFile = { "*.avi",  "*.MP4",   "*.mkv", "*.m4v", "*.mpg"};
                List<string> files = new List<string>();
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);//List of all Files in folder
                foreach(String filter in FilterFile)
                {
                    files.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, filter));
                }
                DataTable dt = ToDatabase(files.ToArray());

                Movies_Data.Columns.Clear();
                Movies_Data.DataSource = dt;
                Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window

            }
        }
        /*
         * Takes a Array of file names and processes them into the database
         * 
         */
        private DataTable ToDatabase(String[] files)
        {
            var form = new Waiting();
            form.Show();

            //Change to Async-Await 
            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 4 },
                M_File =>
                {
                    ToFileTODatabase(M_File);
                });


            form.Close();

            MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.SelAllMovies();
            progressBar.Visible = false;
            return dt;
        }

        /*
         * method used to call in parralel
         * @parm object. used as string
         * 
         */
        private void ToFileTODatabase(String Files)
        {
            try
            {
                FileToDataBase ftb = new FileToDataBase(Files);

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

        }

        /*
        * Selects Movies based on Genres
        */
        private void Sort_Genres_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Sel_Genre = Sort_Genres.Text;
            System.Diagnostics.Debug.WriteLine(Sort_Genres.Text);
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.GetMovieByGernra(Sel_Genre);

            // Movies_Data.Columns.Clear();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
        * brings up info about the selected movie
        */
        private void Movies_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = senderGrid.Rows[e.RowIndex];
                if (e.ColumnIndex == 0)
                {

                    int M_ID = int.Parse(r.Cells[6].Value.ToString());

                    var form = new Movie_Info(M_ID);
                    form.Show(this);
                }
            }
        }
        /*
         * Scans a folder for files and adds if they are not present in the database
         */
        private void Rescan_Folder_Click(object sender, EventArgs e)
        {
            //TODO::DEBUG HANGS ON INSERT IN INSERNEWROW CONCLASS
            int newFiles = 0;

            String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg" };

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                List<String> files = new List<String>();
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);//List of all Files in folder
                foreach (String filter in FilterFile)
                {
                    files.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, filter));
                }
                var form = new Waiting();
                form.Show();
                ConnectionClass con = new ConnectionClass();
                List<String> FilesToInsert = new List<String>();

                foreach (String M_File in files)
                {

                    if (con.IsPresent(M_File))
                    {
                        FilesToInsert.Add(M_File);
                        newFiles++;
                    }
                    //FileToDataBase ftb = new FileToDataBase(M_File);

                }
                foreach (String path in FilesToInsert)
                {
                    FileToDataBase ftb = new FileToDataBase(path);
                }
                form.Close();
                MessageBox.Show("Files found: " + newFiles.ToString(), "Message");
                ConnectionClass cons = new ConnectionClass();

                DataTable dt = cons.SelAllMovies();
                Movies_Data.DataSource = dt;
                Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window


            }
        }
        /*
        * Selects movie based on Decade
        */
        private void Sort_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO::: FInds only movies in sel decade
            String Year = Sort_Year.SelectedItem.ToString();
            String SubYear = Year.Substring(0, 3);

            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.GetMovieByYear(SubYear);
            System.Diagnostics.Debug.WriteLine(SubYear);
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
        * selects movie based on rating
        */
        private void Sort_Rating_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Rating = Sort_Rating.SelectedItem.ToString();
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.GetMovieByRating(Rating);


            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
        * 
        */
        private void Options_List_Click(object sender, EventArgs e)
        {
            //should do nothing 
        }
        /*
        * Shows all rows in the database
        */
        private void Default_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.SelAllMovies();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
         * delete all rows from movies table
         * 
         */
        private void lastChanchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            con.DeleteAll();
            DataTable dt = con.SelAllMovies();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /*
         * gets the text from textbox1 
         * looks for title in movie database
         * 
         */
        private void Search_Click(object sender, EventArgs e)
        {
            String Title = textBox1.Text;
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.GetMovieByTitle(Title);
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
         * finds files that are not in the DataBase
         * Call LoadFiles or Rescan
         * Call this to see if files were not inserted
         * 
         */
        private void findBadNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BadFiles = 0;
            List<String> BadList = new List<string>();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);//List of all Files in folder
                ConnectionClass con = new ConnectionClass();

                foreach (String M_File in files)
                {

                    if (con.IsPresent(M_File))//check if file path is in database
                    {
                        BadList.Add(M_File);
                        BadFiles++;
                    }
                }
                if (BadList.Count > 0)
                {
                    var form = new FileInfo(BadList);
                    form.Show(this);
                }

                MessageBox.Show("Files found: " + BadFiles.ToString(), "Message");


            }
        }
        /*
         * sends a typed ID of movie
         * Opens New form where user edits Movie info
         * 
         */
        private void Edit_Click(object sender, EventArgs e)
        {

            try
            {
                int M_int = int.Parse(textBox2.Text);
                var form = new UpdateRow(M_int);
                form.Show(this);
            }
            catch (Exception t)
            {
                MessageBox.Show("Check Input", "Message");
            }
        }
        /*
         * manually add a new row
         * 
         */
        private void NRow_Click(object sender, EventArgs e)
        {
            var form = new NewRow();
            form.Show(this);
        }
        /*
         * delete a row 
         * 
         */
        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int M_int = int.Parse(textBox2.Text);
                ConnectionClass con = new ConnectionClass();

                DialogResult dialogResult = MessageBox.Show("Do You Also Want to Delete The File", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String[] Data = con.GetMovieData(M_int);
                    File.Delete(Data[7]);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                con.DeleteByID(M_int);
                MessageBox.Show("Row Deleted", "Message");
            }//end try
            catch (Exception t)
            {
                MessageBox.Show("Check Input", "Message");
            }
        }
        /*
         * Shows a list of duplicate TITLES in the Database
         * 
         */
        private void findDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
        }
    }
}
