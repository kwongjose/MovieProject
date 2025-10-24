using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Linq;
using System.Diagnostics;

namespace MovieLib
{    /*
         * 
         */
    public partial class Form1 : Form
    {
        public List<String> BadFile = new List<string>();
        int Total_Files, Found_Files;
        int prog = 0;
        public Queue<Movie> Movies = new Queue<Movie>();
        /*
         * 
         */
        public Form1()
        {
            InitializeComponent();
            progressBar.Visible = false;
            panel1.Visible = false;
            //call database and load table
            ConnectionClass con = new ConnectionClass();
            con.NewDataBase();
            DataTable dt = con.SelAllMovies();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
            Sort_Genres.Items.AddRange(con.GetGenres().ToArray());
            Movies_Data.Columns["Length"].SortMode = DataGridViewColumnSortMode.Programmatic;
            Movies_Data.Columns["Resolution"].SortMode = DataGridViewColumnSortMode.Programmatic;
            Movies_Data.Columns["sort"].Visible = false;
            Movies_Data.Columns["sortRes"].Visible = false;

        }

        /*
         * sort either length or resultion as ints
         * 
         */
        private void Sorter(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dts = (DataGridView)sender;
            DataTable dt = (DataTable)dts.DataSource;
            DataTable Cdt = dt.Copy();
            DataTable so = new DataTable();
            if (e.ColumnIndex == 5)//sort length
            {
                // Movies_Data.DataSource = SortAlphaNumColumn(dt, "Length");
                IEnumerable<DataRow> dr = dt.Select().OrderBy(Row => Row["sort"]);
                Movies_Data.DataSource = dr.ToArray().CopyToDataTable();

            }
            if (e.ColumnIndex == 6)//sort res
            {
                // Movies_Data.DataSource = SortAlphaNumColumn(dt, "Resolution");
                IEnumerable<DataRow> dr = dt.Select().OrderBy(row => row["sortRes"]); Movies_Data.DataSource = dr.ToArray().CopyToDataTable();
            }
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
                String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg", "*.ts" };
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
                prog = 0;
                working.Visible = true;
                panel1.Visible = true;
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
            Found_Files = Movies.Count;
            Insert();

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


            MessageBox.Show("Files found: " + Found_Files + "/" + Total_Files, "Message");
            Found_Files = 0;

            working.Visible = false;
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.SelAllMovies();
            progressBar.Visible = false;
            panel1.Visible = false;
            // Movies_Data.Rows.Clear();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window

            EnableContol(this);
        }

        /*
         * inserts into DB from Que
         * 
         */
        private void Insert()
        {

            ConnectionClass con = new ConnectionClass();
            int size = Movies.Count;
            for (int i = 0; i < size; i++)
            {
                //  progressBar.Value = i;
                UpdateBar(i);
                Movie Curent_Movie = Movies.Dequeue();
                con.TestInsertNewRow(Curent_Movie.Title, Curent_Movie.Year, Curent_Movie.Genre, Curent_Movie.imdbRating, Curent_Movie.Runtime, Curent_Movie.Res, Curent_Movie.Plot, Curent_Movie.Path, Curent_Movie.Poster, Curent_Movie.Rated);

                String[] act = Curent_Movie.Actors.Split(',').ToArray();
                int Mid = con.GetRowID(Curent_Movie.Path);

                foreach (string name in act)
                {
                    con.InsertNewActor(name.Trim());
                }//end 
                foreach (string name in act)
                {
                    int aid = con.GetActorID(name.Trim());
                    con.Insert_MovieActor(Mid, aid);
                }//end

            }//end for
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

                FileToDataBase ftb = new FileToDataBase(Files, this);

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
            try
            {
                if (Found_Files != 0)
                {
                    progressBar.Maximum = Found_Files;
                }
                if (i < Total_Files)
                {
                    progressBar.Value = i;
                    label1.Text = i + "/" + Total_Files;
                }
                if (i == Total_Files - 1)
                {

                    working.Text = "Inserting";
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "problem in updatebar");
            }
        }


        /*
        * brings up info about the selected movie
        */
        private void Movies_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow r = senderGrid.Rows[e.RowIndex];
                    if (e.ColumnIndex == 0)
                    {
                        if (r.Cells[7].Value.ToString() != null)
                        {
                            int M_ID = int.Parse(r.Cells[7].Value.ToString());
                            var form = new Movie_Info(M_ID);
                            form.Show(this);
                        }
                    }
                    if (e.ColumnIndex == 7)//select ID
                    {
                        if (r.Cells[7].Value.ToString() != null)
                        {
                            textBox2.Text = r.Cells[7].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception w)
            {
                System.Diagnostics.Debug.WriteLine(w.Message);

            }
        }
        /*
         * Scans a folder for files and adds if they are not present in the database
         */
        private void Rescan_Folder_Click(object sender, EventArgs e)
        {
            //TODO::DEBUG HANGS ON INSERT IN INSERNEWROW CONCLASS
            int newFiles = 0;

            String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg", "*.ts" };

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
                prog = 0;
                working.Text = "Working Please Wait";
                working.Visible = true;
                panel1.Visible = true;
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

            // ConnectionClass con = new ConnectionClass();
            // DataTable dt = con.GetMovieByYear(SubYear);
            DataTable dt = (DataTable)(Movies_Data.DataSource);
            DataRow[] dr = dt.Select("Year LIKE '" + SubYear + "%' ");

            if (dr.Length > 0)
            {
                dt = dr.CopyToDataTable();
                System.Diagnostics.Debug.WriteLine(dr.Length);
            }
            else
            {
                DataRow drs = dt.NewRow();
                dt.Rows.Clear();
                dt.Rows.Add(drs);

            }
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
        * selects movie based on rating
        */
        private void Sort_Rating_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Rating = Sort_Rating.SelectedItem.ToString();
            double t = double.Parse(Rating);
            // ConnectionClass con = new ConnectionClass();
            //  DataTable dt = con.GetMovieByRating(Rating);
            DataTable dt = (DataTable)(Movies_Data.DataSource);
            DataRow[] dr = dt.Select("Rating > '" + t + "%' ");//This does not work

            if (dr.Length > 0)
            {
                dt = dr.CopyToDataTable();
            }
            else
            {
                DataRow drs = dt.NewRow();
                dt.Rows.Clear();
                dt.Rows.Add(drs);
            }
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }
        /*
       * Selects Movies based on Genres
       */
        private void Sort_Genres_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Sel_Genre = Sort_Genres.Text;
            // ConnectionClass con = new ConnectionClass();
            //DataTable dt = con.GetMovieByGernra(Sel_Genre);
            DataTable dt = (DataTable)(Movies_Data.DataSource);
            DataRow[] dr = dt.Select("Gernra LIKE '%" + Sel_Genre + "%' ");
         
            if (dr.Length > 0)
            {
                dt = dr.CopyToDataTable();
            }
            else
            {
                DataRow drs = dt.NewRow();
                dt.Rows.Clear();
                dt.Rows.Add(drs);

            }

            // Movies_Data.Columns.Clear();
            Movies_Data.DataSource = dt;
            Movies_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//fill window
        }

        /*
        * Shows all rows in the database
        */
        private void Default_Click(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            DataTable dt = con.SelAllMovies();
            Movies_Data.DataSource = dt;
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

        /*
         * gets the text from textbox1 
         * looks for title in movie database
         * 
         */
        private void Search_Click(object sender, EventArgs e)
        {
            String Title = textBox1.Text;
            ConnectionClass con = new ConnectionClass();
            DataTable mt = con.GetMovieByTitle(Title);

            mt.Merge(con.GetActorMovies(Title));
            DataTable rd = mt.DefaultView.ToTable(true); //might need to improve this, not sure why it works
            Movies_Data.DataSource = rd;
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
                String[] FilterFile = { "*.avi", "*.MP4", "*.mkv", "*.m4v", "*.mpg", "*.ts" };//video file types

                List<String> files = new List<String>();

                foreach (String filter in FilterFile)
                {
                    files.AddRange(Directory.GetFiles(folderBrowserDialog1.SelectedPath, filter));
                }

                ConnectionClass con = new ConnectionClass();

                foreach (String M_File in files)
                {

                    if (con.IsPresent(M_File))//check if file path is in database
                    {//returns false if file is present
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
                var form = new UpdateRow(M_int, this);
                form.Show();
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
            form.Show();
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
                    Movie mov = con.GetMovieData(M_int);
                    File.Delete(mov.Path);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                con.DeleteByID(M_int);
                MessageBox.Show("Row Deleted", "Message");
            }//end try
            catch (UnauthorizedAccessException t)
            {
                
                MessageBox.Show("File Is Read-Only", "Message");
               
            }
            catch(FormatException q)
            {
                MessageBox.Show("Check Input", "Message");
            }
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
            if (c.GetType() == typeof(MenuStrip) | c.GetType() == typeof(ComboBox) | c.GetType() == typeof(Button) | c.GetType() == typeof(TextBox) | c.GetType() == typeof(DataGridView) )
            {
                c.Enabled = false;
            }

        }

        /*
         * Enables all controls on the form
         * @pram a control
         * 
         */
        private void EnableContol(Control c)
        {
            foreach (Control con in c.Controls)
            {
                EnableContol(con);
            }
            c.Enabled = true;
        }
        /*
         * add custom gerna
         * 
         */
        private void addCustomGernaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_G.Visible = true;
            Gerna.Text = "";
        }
        /*
         * add gerna
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Add_G.Visible = false;
            if (!Sort_Genres.Items.Contains(Gerna.Text))
            {
                ConnectionClass con = new ConnectionClass();
                con.InsertNewGerna(Gerna.Text);
                Sort_Genres.Items.Add(Gerna.Text);

            }


        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Add_G.Visible = false;
            if (Sort_Genres.Items.Contains(Gerna.Text))
            {
                Sort_Genres.Items.Remove(Gerna.Text);
                ConnectionClass con = new ConnectionClass();
                con.DeleteGenre(Gerna.Text);

            }
        }

        /*
* Shows duplicates titles
*/
        private void findDuplicatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ConnectionClass con = new ConnectionClass();
            List<String> dup = con.FindDubs();
            if(dup.Count > 0)
            {
                Form form = new FileInfo(dup);
                form.Show();
            }
            else
            {
                MessageBox.Show("No Duplicates", "Message");
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
         * 
         * sort a given datatable by a supplied column nname
         * 
         */
        private DataTable SortAlphaNumColumn(DataTable dt, String Colname)
        {
            string tempColName = Colname + "int";

            //  dt.Columns.Add(new DataColumn(tempColName, typeof(int)));


            if (Colname.Equals("Length"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    int i;
                    String temp = row[Colname].ToString();

                    if (int.TryParse(temp.Substring(0, temp.Length - 3), out i))
                    {
                        row["sort"] = i;
                    }

                }//end if length

            }//end length

            else
            {

                foreach (DataRow row in dt.Rows)
                {
                    int i;
                    int t;
                    String temp = row[Colname].ToString();
                    string[] resT = temp.Split('X');
                    if (int.TryParse(resT[0], out i) && int.TryParse(resT[1], out t))
                    {
                        row["sort"] = i * t;
                    }
                }
            }


            //This is super fast
            IEnumerable<DataRow> dr = dt.Select().OrderBy(row => row["sort"]);
            dt = dr.ToArray().CopyToDataTable();
            /*
            DataView dv = dt.DefaultView;
            dv.Sort = tempColName;
            dt = dv.ToTable();
            */
            //  dt.Columns.Remove(tempColName);

            // dt = dr.CopyToDataTable();
            return dt;
        }



    }
}
