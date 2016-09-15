namespace MovieLib
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Options_List = new System.Windows.Forms.ToolStripMenuItem();
            this.Load_Files = new System.Windows.Forms.ToolStripMenuItem();
            this.Rescan_Folder = new System.Windows.Forms.ToolStripMenuItem();
            this.startOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastChanchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findBadNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sort_Genres = new System.Windows.Forms.ComboBox();
            this.Sort_Year = new System.Windows.Forms.ComboBox();
            this.Sort_Rating = new System.Windows.Forms.ComboBox();
            this.Movies_Data = new System.Windows.Forms.DataGridView();
            this.Title_Name = new System.Windows.Forms.DataGridViewButtonColumn();
            this.M_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year_Made = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genres_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resulution_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Edit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Movies_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Options_List});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1254, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Options_List
            // 
            this.Options_List.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load_Files,
            this.Rescan_Folder,
            this.startOverToolStripMenuItem,
            this.findBadNamesToolStripMenuItem});
            this.Options_List.Name = "Options_List";
            this.Options_List.Size = new System.Drawing.Size(61, 20);
            this.Options_List.Text = "Options";
            this.Options_List.Click += new System.EventHandler(this.Options_List_Click);
            // 
            // Load_Files
            // 
            this.Load_Files.Name = "Load_Files";
            this.Load_Files.Size = new System.Drawing.Size(160, 22);
            this.Load_Files.Text = "Load Files";
            this.Load_Files.Click += new System.EventHandler(this.Load_Files_Click);
            // 
            // Rescan_Folder
            // 
            this.Rescan_Folder.Name = "Rescan_Folder";
            this.Rescan_Folder.Size = new System.Drawing.Size(160, 22);
            this.Rescan_Folder.Text = "Rescan";
            this.Rescan_Folder.Click += new System.EventHandler(this.Rescan_Folder_Click);
            // 
            // startOverToolStripMenuItem
            // 
            this.startOverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastChanchToolStripMenuItem});
            this.startOverToolStripMenuItem.Name = "startOverToolStripMenuItem";
            this.startOverToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.startOverToolStripMenuItem.Text = "Start Over";
            // 
            // lastChanchToolStripMenuItem
            // 
            this.lastChanchToolStripMenuItem.Name = "lastChanchToolStripMenuItem";
            this.lastChanchToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.lastChanchToolStripMenuItem.Text = "Last Chanch";
            this.lastChanchToolStripMenuItem.Click += new System.EventHandler(this.lastChanchToolStripMenuItem_Click);
            // 
            // findBadNamesToolStripMenuItem
            // 
            this.findBadNamesToolStripMenuItem.Name = "findBadNamesToolStripMenuItem";
            this.findBadNamesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findBadNamesToolStripMenuItem.Text = "Find Bad Names";
            this.findBadNamesToolStripMenuItem.Click += new System.EventHandler(this.findBadNamesToolStripMenuItem_Click);
            // 
            // Sort_Genres
            // 
            this.Sort_Genres.FormattingEnabled = true;
            this.Sort_Genres.Items.AddRange(new object[] {
            "Action",
            "Animation",
            "Adventure",
            "Biography",
            "Comedy",
            "Crime",
            "Documentary",
            "Drama",
            "Family",
            "Fantasy",
            "Film-Noir",
            "History",
            "Horror",
            "Music",
            "Musical",
            "Mystery",
            "Romance",
            "Sci-Fi",
            "Sport",
            "Thriller",
            "War",
            "Western"});
            this.Sort_Genres.Location = new System.Drawing.Point(81, 63);
            this.Sort_Genres.Name = "Sort_Genres";
            this.Sort_Genres.Size = new System.Drawing.Size(121, 21);
            this.Sort_Genres.TabIndex = 3;
            this.Sort_Genres.Text = "Genres";
            this.Sort_Genres.SelectedIndexChanged += new System.EventHandler(this.Sort_Genres_SelectedIndexChanged);
            // 
            // Sort_Year
            // 
            this.Sort_Year.FormattingEnabled = true;
            this.Sort_Year.Items.AddRange(new object[] {
            "2020s",
            "2010s",
            "2000s",
            "1990s",
            "1980s",
            "1970s",
            "1960s",
            "1950s",
            "1940s",
            "1930s"});
            this.Sort_Year.Location = new System.Drawing.Point(300, 63);
            this.Sort_Year.Name = "Sort_Year";
            this.Sort_Year.Size = new System.Drawing.Size(121, 21);
            this.Sort_Year.TabIndex = 4;
            this.Sort_Year.Text = "Year";
            this.Sort_Year.SelectedIndexChanged += new System.EventHandler(this.Sort_Year_SelectedIndexChanged);
            // 
            // Sort_Rating
            // 
            this.Sort_Rating.FormattingEnabled = true;
            this.Sort_Rating.Items.AddRange(new object[] {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0"});
            this.Sort_Rating.Location = new System.Drawing.Point(525, 63);
            this.Sort_Rating.Name = "Sort_Rating";
            this.Sort_Rating.Size = new System.Drawing.Size(121, 21);
            this.Sort_Rating.TabIndex = 5;
            this.Sort_Rating.Text = "Rating";
            this.Sort_Rating.SelectedIndexChanged += new System.EventHandler(this.Sort_Rating_SelectedIndexChanged);
            // 
            // Movies_Data
            // 
            this.Movies_Data.AllowUserToDeleteRows = false;
            this.Movies_Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Movies_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title_Name,
            this.M_ID,
            this.Year_Made,
            this.Genres_Data,
            this.Rating_Data,
            this.Length_Data,
            this.Resulution_Data});
            this.Movies_Data.Location = new System.Drawing.Point(12, 109);
            this.Movies_Data.Name = "Movies_Data";
            this.Movies_Data.ReadOnly = true;
            this.Movies_Data.Size = new System.Drawing.Size(1230, 457);
            this.Movies_Data.TabIndex = 6;
            this.Movies_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Movies_Data_CellContentClick);
            // 
            // Title_Name
            // 
            this.Title_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title_Name.HeaderText = "Title";
            this.Title_Name.Name = "Title_Name";
            this.Title_Name.ReadOnly = true;
            this.Title_Name.Text = "";
            // 
            // M_ID
            // 
            this.M_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.M_ID.HeaderText = "ID";
            this.M_ID.Name = "M_ID";
            this.M_ID.ReadOnly = true;
            this.M_ID.Visible = false;
            // 
            // Year_Made
            // 
            this.Year_Made.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Year_Made.HeaderText = "Year";
            this.Year_Made.Name = "Year_Made";
            this.Year_Made.ReadOnly = true;
            // 
            // Genres_Data
            // 
            this.Genres_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Genres_Data.HeaderText = "Genres";
            this.Genres_Data.Name = "Genres_Data";
            this.Genres_Data.ReadOnly = true;
            // 
            // Rating_Data
            // 
            this.Rating_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rating_Data.HeaderText = "Rating";
            this.Rating_Data.Name = "Rating_Data";
            this.Rating_Data.ReadOnly = true;
            // 
            // Length_Data
            // 
            this.Length_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Length_Data.HeaderText = "Length";
            this.Length_Data.Name = "Length_Data";
            this.Length_Data.ReadOnly = true;
            // 
            // Resulution_Data
            // 
            this.Resulution_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Resulution_Data.HeaderText = "Resulution";
            this.Resulution_Data.Name = "Resulution_Data";
            this.Resulution_Data.ReadOnly = true;
            // 
            // Default
            // 
            this.Default.Location = new System.Drawing.Point(704, 60);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(75, 23);
            this.Default.TabIndex = 7;
            this.Default.Text = "Show All";
            this.Default.UseVisualStyleBackColor = true;
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(828, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(1100, 60);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 9;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(828, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 20);
            this.textBox2.TabIndex = 10;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(940, 25);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 11;
            this.Edit.Text = "Edit By ID";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 662);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Default);
            this.Controls.Add(this.Movies_Data);
            this.Controls.Add(this.Sort_Rating);
            this.Controls.Add(this.Sort_Year);
            this.Controls.Add(this.Sort_Genres);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Movies_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Options_List;
        private System.Windows.Forms.ToolStripMenuItem Load_Files;
        private System.Windows.Forms.ToolStripMenuItem Rescan_Folder;
        private System.Windows.Forms.ComboBox Sort_Genres;
        private System.Windows.Forms.ComboBox Sort_Year;
        private System.Windows.Forms.ComboBox Sort_Rating;
        private System.Windows.Forms.DataGridView Movies_Data;
        private System.Windows.Forms.Button Default;
        private System.Windows.Forms.ToolStripMenuItem startOverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastChanchToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DataGridViewButtonColumn Title_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year_Made;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genres_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resulution_Data;
        private System.Windows.Forms.ToolStripMenuItem findBadNamesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Edit;
    }
}

