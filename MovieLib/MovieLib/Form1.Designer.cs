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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.Movies_Data = new System.Windows.Forms.DataGridView();
            this.Title_Name = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Year_Made = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genres_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resulution_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Rescan_Folder});
            this.Options_List.Name = "Options_List";
            this.Options_List.Size = new System.Drawing.Size(61, 20);
            this.Options_List.Text = "Options";
            // 
            // Load_Files
            // 
            this.Load_Files.Name = "Load_Files";
            this.Load_Files.Size = new System.Drawing.Size(152, 22);
            this.Load_Files.Text = "Load Files";
            this.Load_Files.Click += new System.EventHandler(this.sdsToolStripMenuItem_Click);
            // 
            // Rescan_Folder
            // 
            this.Rescan_Folder.Name = "Rescan_Folder";
            this.Rescan_Folder.Size = new System.Drawing.Size(152, 22);
            this.Rescan_Folder.Text = "Rescan";
            this.Rescan_Folder.Click += new System.EventHandler(this.Rescan_Folder_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(300, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(525, 63);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 5;
            // 
            // Movies_Data
            // 
            this.Movies_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Movies_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title_Name,
            this.Year_Made,
            this.Genres_Data,
            this.Rating_Data,
            this.Length_Data,
            this.Resulution_Data});
            this.Movies_Data.Location = new System.Drawing.Point(12, 111);
            this.Movies_Data.Name = "Movies_Data";
            this.Movies_Data.Size = new System.Drawing.Size(1230, 455);
            this.Movies_Data.TabIndex = 6;
            this.Movies_Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Title_Name
            // 
            this.Title_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Title_Name.HeaderText = "Title";
            this.Title_Name.Name = "Title_Name";
            this.Title_Name.Text = "";
            this.Title_Name.Width = 687;
            // 
            // Year_Made
            // 
            this.Year_Made.HeaderText = "Year";
            this.Year_Made.Name = "Year_Made";
            // 
            // Genres_Data
            // 
            this.Genres_Data.HeaderText = "Genres";
            this.Genres_Data.Name = "Genres_Data";
            // 
            // Rating_Data
            // 
            this.Rating_Data.HeaderText = "Rating";
            this.Rating_Data.Name = "Rating_Data";
            // 
            // Length_Data
            // 
            this.Length_Data.HeaderText = "Length";
            this.Length_Data.Name = "Length_Data";
            // 
            // Resulution_Data
            // 
            this.Resulution_Data.HeaderText = "Resulution";
            this.Resulution_Data.Name = "Resulution_Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 662);
            this.Controls.Add(this.Movies_Data);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.DataGridView Movies_Data;
        private System.Windows.Forms.DataGridViewButtonColumn Title_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year_Made;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genres_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resulution_Data;
    }
}

