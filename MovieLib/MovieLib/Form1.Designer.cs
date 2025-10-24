using System;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Options_List = new System.Windows.Forms.ToolStripMenuItem();
            this.Load_Files = new System.Windows.Forms.ToolStripMenuItem();
            this.Rescan_Folder = new System.Windows.Forms.ToolStripMenuItem();
            this.startOverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastChanchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findBadNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomGernaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sort_Genres = new System.Windows.Forms.ComboBox();
            this.Sort_Year = new System.Windows.Forms.ComboBox();
            this.Sort_Rating = new System.Windows.Forms.ComboBox();
            this.Movies_Data = new System.Windows.Forms.DataGridView();
            this.Default = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Edit = new System.Windows.Forms.Button();
            this.NRow = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.working = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Add_G = new System.Windows.Forms.Panel();
            this.Remove = new System.Windows.Forms.Button();
            this.Gerna = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Movies_Data)).BeginInit();
            this.panel1.SuspendLayout();
            this.Add_G.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Options_List});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1254, 26);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Options_List
            // 
            this.Options_List.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load_Files,
            this.Rescan_Folder,
            this.startOverToolStripMenuItem,
            this.findBadNamesToolStripMenuItem,
            this.findDuplicatesToolStripMenuItem,
            this.addCustomGernaToolStripMenuItem});
            this.Options_List.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Options_List.Name = "Options_List";
            this.Options_List.Size = new System.Drawing.Size(68, 22);
            this.Options_List.Text = "Options";
            // 
            // Load_Files
            // 
            this.Load_Files.Name = "Load_Files";
            this.Load_Files.Size = new System.Drawing.Size(248, 22);
            this.Load_Files.Text = "Load Files";
            this.Load_Files.Click += new System.EventHandler(this.Load_Files_Click);
            // 
            // Rescan_Folder
            // 
            this.Rescan_Folder.Name = "Rescan_Folder";
            this.Rescan_Folder.Size = new System.Drawing.Size(248, 22);
            this.Rescan_Folder.Text = "Rescan";
            this.Rescan_Folder.Click += new System.EventHandler(this.Rescan_Folder_Click);
            // 
            // startOverToolStripMenuItem
            // 
            this.startOverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastChanchToolStripMenuItem});
            this.startOverToolStripMenuItem.Name = "startOverToolStripMenuItem";
            this.startOverToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.startOverToolStripMenuItem.Text = "Start Over";
            // 
            // lastChanchToolStripMenuItem
            // 
            this.lastChanchToolStripMenuItem.Name = "lastChanchToolStripMenuItem";
            this.lastChanchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.lastChanchToolStripMenuItem.Text = "Last Chanch";
            this.lastChanchToolStripMenuItem.Click += new System.EventHandler(this.lastChanchToolStripMenuItem_Click);
            // 
            // findBadNamesToolStripMenuItem
            // 
            this.findBadNamesToolStripMenuItem.Name = "findBadNamesToolStripMenuItem";
            this.findBadNamesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.findBadNamesToolStripMenuItem.Text = "Find Bad Names";
            this.findBadNamesToolStripMenuItem.Click += new System.EventHandler(this.findBadNamesToolStripMenuItem_Click);
            // 
            // findDuplicatesToolStripMenuItem
            // 
            this.findDuplicatesToolStripMenuItem.Name = "findDuplicatesToolStripMenuItem";
            this.findDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.findDuplicatesToolStripMenuItem.Text = "Find Duplicates";
            this.findDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.findDuplicatesToolStripMenuItem_Click_1);
            // 
            // addCustomGernaToolStripMenuItem
            // 
            this.addCustomGernaToolStripMenuItem.Name = "addCustomGernaToolStripMenuItem";
            this.addCustomGernaToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.addCustomGernaToolStripMenuItem.Text = "Add/Remove Custom Gerna";
            this.addCustomGernaToolStripMenuItem.Click += new System.EventHandler(this.addCustomGernaToolStripMenuItem_Click);
            // 
            // Sort_Genres
            // 
            this.Sort_Genres.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sort_Genres.FormattingEnabled = true;
            this.Sort_Genres.Items.AddRange(new object[] {
            "Action ",
            "Animation",
            "Adventure",
            "Biography",
            "Comedy",
            "Crime",
            "Documentary",
            "Drama",
            "Family",
            "Fantasy",
            "Film_Noir",
            "History",
            "Horror",
            "Music",
            "Marvel",
            "DC",
            "Musical",
            "Mystery",
            "Romance",
            "Sci-Fi",
            "Sport",
            "Thriller",
            "War",
            "Western"});
            this.Sort_Genres.Location = new System.Drawing.Point(146, 69);
            this.Sort_Genres.Name = "Sort_Genres";
            this.Sort_Genres.Size = new System.Drawing.Size(121, 26);
            this.Sort_Genres.TabIndex = 3;
            this.Sort_Genres.Text = "Genres";
            this.Sort_Genres.SelectedIndexChanged += new System.EventHandler(this.Sort_Genres_SelectedIndexChanged);
            // 
            // Sort_Year
            // 
            this.Sort_Year.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.Sort_Year.Location = new System.Drawing.Point(324, 69);
            this.Sort_Year.Name = "Sort_Year";
            this.Sort_Year.Size = new System.Drawing.Size(121, 26);
            this.Sort_Year.TabIndex = 4;
            this.Sort_Year.Text = "Year";
            this.Sort_Year.SelectedIndexChanged += new System.EventHandler(this.Sort_Year_SelectedIndexChanged);
            // 
            // Sort_Rating
            // 
            this.Sort_Rating.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.Sort_Rating.Location = new System.Drawing.Point(491, 69);
            this.Sort_Rating.Name = "Sort_Rating";
            this.Sort_Rating.Size = new System.Drawing.Size(121, 26);
            this.Sort_Rating.TabIndex = 5;
            this.Sort_Rating.Text = "Rating";
            this.Sort_Rating.SelectedIndexChanged += new System.EventHandler(this.Sort_Rating_SelectedIndexChanged);
            // 
            // Movies_Data
            // 
            this.Movies_Data.AllowUserToDeleteRows = false;
            this.Movies_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Movies_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Movies_Data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Movies_Data.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Movies_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Movies_Data.ColumnHeadersHeight = 26;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Movies_Data.DefaultCellStyle = dataGridViewCellStyle2;
            this.Movies_Data.Location = new System.Drawing.Point(12, 119);
            this.Movies_Data.Name = "Movies_Data";
            this.Movies_Data.ReadOnly = true;
            this.Movies_Data.RowHeadersVisible = false;
            this.Movies_Data.Size = new System.Drawing.Size(1230, 487);
            this.Movies_Data.TabIndex = 6;
            this.Movies_Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Movies_Data_CellContentClick);
            this.Movies_Data.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Sorter);
            // 
            // Default
            // 
            this.Default.BackColor = System.Drawing.Color.White;
            this.Default.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Default.Location = new System.Drawing.Point(654, 69);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(76, 26);
            this.Default.TabIndex = 7;
            this.Default.Text = "Show All";
            this.Default.UseVisualStyleBackColor = false;
            this.Default.Click += new System.EventHandler(this.Default_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(829, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.Search_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.White;
            this.Search.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(1072, 68);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(76, 26);
            this.Search.TabIndex = 9;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Visible = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(829, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(73, 26);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Edit
            // 
            this.Edit.BackColor = System.Drawing.Color.White;
            this.Edit.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(908, 20);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(76, 26);
            this.Edit.TabIndex = 11;
            this.Edit.Text = "Edit By ID";
            this.Edit.UseVisualStyleBackColor = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // NRow
            // 
            this.NRow.BackColor = System.Drawing.Color.White;
            this.NRow.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NRow.Location = new System.Drawing.Point(1115, 20);
            this.NRow.Name = "NRow";
            this.NRow.Size = new System.Drawing.Size(76, 26);
            this.NRow.TabIndex = 12;
            this.NRow.Text = "New Row";
            this.NRow.UseVisualStyleBackColor = false;
            this.NRow.Click += new System.EventHandler(this.NRow_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.BackColor = System.Drawing.Color.White;
            this.DelBtn.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelBtn.Location = new System.Drawing.Point(990, 20);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(76, 26);
            this.DelBtn.TabIndex = 13;
            this.DelBtn.TabStop = false;
            this.DelBtn.Text = "Delete Row";
            this.DelBtn.UseVisualStyleBackColor = false;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(56, 67);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(357, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 14;
            // 
            // working
            // 
            this.working.AutoSize = true;
            this.working.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.working.Location = new System.Drawing.Point(138, 28);
            this.working.Name = "working";
            this.working.Size = new System.Drawing.Size(188, 26);
            this.working.TabIndex = 15;
            this.working.Text = "Working Please Wait";
            this.working.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.working);
            this.panel1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(376, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 130);
            this.panel1.TabIndex = 16;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 16;
            // 
            // Add_G
            // 
            this.Add_G.BackColor = System.Drawing.Color.White;
            this.Add_G.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Add_G.Controls.Add(this.Remove);
            this.Add_G.Controls.Add(this.Gerna);
            this.Add_G.Controls.Add(this.Add);
            this.Add_G.Location = new System.Drawing.Point(376, 250);
            this.Add_G.Name = "Add_G";
            this.Add_G.Size = new System.Drawing.Size(463, 167);
            this.Add_G.TabIndex = 17;
            this.Add_G.Visible = false;
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.Color.White;
            this.Remove.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove.Location = new System.Drawing.Point(314, 101);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(76, 26);
            this.Remove.TabIndex = 2;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Gerna
            // 
            this.Gerna.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gerna.Location = new System.Drawing.Point(103, 75);
            this.Gerna.Name = "Gerna";
            this.Gerna.Size = new System.Drawing.Size(175, 26);
            this.Gerna.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(314, 52);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(76, 26);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(774, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1254, 649);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Add_G);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.NRow);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "My Movie Library";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Movies_Data)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Add_G.ResumeLayout(false);
            this.Add_G.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CustomSort(object sender, DataGridViewSortCompareEventArgs e)
        {
            throw new NotImplementedException();
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
        private System.Windows.Forms.ToolStripMenuItem findBadNamesToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button NRow;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label working;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem findDuplicatesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private Panel Add_G;
        private TextBox Gerna;
        private Button Add;
        private ToolStripMenuItem addCustomGernaToolStripMenuItem;
        private Button Remove;
        private Label label2;
    }
}

