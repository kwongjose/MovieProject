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
        int Total_Files;
        int prog = 0;
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
                String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg" };
                List<string> files = new List<string>();

                foreach (String filter in FilterFile)
                {
                    files.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, filter));
                }
                DisableContol(this);
                
                progressBar.Maximum = files.Count;
                Total_Files = files.Count;
                progressBar.Visible = true;
                progressBar.Value = 0;
                working.Visible = true;
                Thread thread = new Thread(() => ProccessFiles(files.ToArray()));
                thread.Start();
            }
        }

        /*
         * Method that makes a parralle call to filetodatabase 
         * @pram an string array of file paths
         * 
         */
        private void ProccessFiles(String[] files)
        {
            Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = 4 },
              M_File =>
              {
                  ToFileTODatabase(M_File);
                  prog++;
                  UpdateBar(prog);
              });

            // form.Close();

            UpdateTable(files.Length);
        }
        /*
         * Updates the datagridview and changes visability of working lable and progressbar
         * @parm an int representing the number of files to insert
         * 
         */
        private void UpdateTable(int x)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => UpdateTable(x)));
                return;
            }

            MessageBox.Show("Files found: " + x, "Message");

            working.Visible = false;
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.SelAllMovies();
            progressBar.Visible = false;
            Movies_Data.Columns.Clear();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window

            EnableContol(this);
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
         * Updates the Progressbar in the main window
         * @pram an int representing the value of the progress bar 
         * 
         */
        private void UpdateBar(int i)
        {

            if (InvokeRequired)
            {
                BeginInvoke(new Action<int>(UpdateBar), new object[] { i });
                return;
            }
            if (i < Total_Files)
            {
                progressBar.Value = i;
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

                DisableContol(this);

                ConnectionClass con = new ConnectionClass();
                List<String> FilesToInsert = new List<String>();

                foreach (String M_File in files)
                {

                    if (con.IsPresent(M_File))
                    {
                        FilesToInsert.Add(M_File);
                        newFiles++;
                    }

                }

                progressBar.Maximum = FilesToInsert.Count;
                Total_Files = FilesToInsert.Count;
                progressBar.Visible = true;
                progressBar.Value = 0;
                working.Visible = true;
                Thread thread = new Thread(() => ProccessFiles(FilesToInsert.ToArray()));
                thread.Start();

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

            DataTable Data_Table = (DataTable)Movies_Data.DataSource;
            DataRow[] DR =   Data_Table.Select("Rating like '%" + Rating + "%'");
            DataTable NewTable = new DataTable();
            if (DR.Length > 0)
            {
                NewTable = DR.CopyToDataTable();
                Movies_Data.DataSource = Data_Table;
                // Movies_Data.DataSource = dt;
            }
                Movies_Data.DataSource = NewTable;
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
                String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg" };//video file types

                List<String> files = new List<String>();

                foreach (String filter in FilterFile)
                {
                    files.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, filter));
                }

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
        /*
         * Disables all controles on the form. 
         * @pram a controle
         * 
         */
        private void DisableContol(Control c)
        {
            foreach (Control con in c.Controls)
            {
                DisableContol(con);
            }
            c.Enabled = false;
        }

        /*
         * Enables all controls on the form
         * @pram a control
         * 
         */
        private void EnableContol(Control c)
        {
            foreach(Control con in c.Controls)
            {
                EnableContol(con);
            }
            c.Enabled = true;
        }
    }
}
