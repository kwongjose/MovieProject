namespace MovieLib
{
    partial class Movie_Info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movie_Info));
            this.Movie_Title = new System.Windows.Forms.Label();
            this.M_Plot = new System.Windows.Forms.TextBox();
            this.Watch_Movie = new System.Windows.Forms.Button();
            this.Title_Lable = new System.Windows.Forms.Label();
            this.Year_Lable = new System.Windows.Forms.Label();
            this.Rating_Lable = new System.Windows.Forms.Label();
            this.Genre_Lable = new System.Windows.Forms.Label();
            this.Res_Lable = new System.Windows.Forms.Label();
            this.Actors_Lable = new System.Windows.Forms.Label();
            this.Movie_Poster = new System.Windows.Forms.PictureBox();
            this.runtime_Lable = new System.Windows.Forms.Label();
            this.ActorsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Poster)).BeginInit();
            this.SuspendLayout();
            // 
            // Movie_Title
            // 
            this.Movie_Title.AutoSize = true;
            this.Movie_Title.Location = new System.Drawing.Point(291, 28);
            this.Movie_Title.Name = "Movie_Title";
            this.Movie_Title.Size = new System.Drawing.Size(0, 13);
            this.Movie_Title.TabIndex = 0;
            // 
            // M_Plot
            // 
            this.M_Plot.BackColor = System.Drawing.Color.White;
            this.M_Plot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.M_Plot.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.M_Plot.Location = new System.Drawing.Point(51, 412);
            this.M_Plot.Multiline = true;
            this.M_Plot.Name = "M_Plot";
            this.M_Plot.ReadOnly = true;
            this.M_Plot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.M_Plot.Size = new System.Drawing.Size(545, 134);
            this.M_Plot.TabIndex = 1;
            this.M_Plot.TabStop = false;
            // 
            // Watch_Movie
            // 
            this.Watch_Movie.BackColor = System.Drawing.Color.White;
            this.Watch_Movie.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Watch_Movie.Location = new System.Drawing.Point(258, 577);
            this.Watch_Movie.Name = "Watch_Movie";
            this.Watch_Movie.Size = new System.Drawing.Size(115, 26);
            this.Watch_Movie.TabIndex = 2;
            this.Watch_Movie.Text = "Watch Movie";
            this.Watch_Movie.UseVisualStyleBackColor = false;
            this.Watch_Movie.Click += new System.EventHandler(this.Watch_Movie_Click);
            // 
            // Title_Lable
            // 
            this.Title_Lable.AutoSize = true;
            this.Title_Lable.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Lable.Location = new System.Drawing.Point(46, 31);
            this.Title_Lable.Name = "Title_Lable";
            this.Title_Lable.Size = new System.Drawing.Size(57, 29);
            this.Title_Lable.TabIndex = 3;
            this.Title_Lable.Text = "Title";
            this.Title_Lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Year_Lable
            // 
            this.Year_Lable.AutoSize = true;
            this.Year_Lable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Year_Lable.Location = new System.Drawing.Point(95, 72);
            this.Year_Lable.Name = "Year_Lable";
            this.Year_Lable.Size = new System.Drawing.Size(43, 23);
            this.Year_Lable.TabIndex = 4;
            this.Year_Lable.Text = "Year";
            // 
            // Rating_Lable
            // 
            this.Rating_Lable.AutoSize = true;
            this.Rating_Lable.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rating_Lable.Location = new System.Drawing.Point(219, 72);
            this.Rating_Lable.Name = "Rating_Lable";
            this.Rating_Lable.Size = new System.Drawing.Size(59, 23);
            this.Rating_Lable.TabIndex = 5;
            this.Rating_Lable.Text = "Rating";
            // 
            // Genre_Lable
            // 
            this.Genre_Lable.AutoSize = true;
            this.Genre_Lable.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Genre_Lable.Location = new System.Drawing.Point(49, 129);
            this.Genre_Lable.Name = "Genre_Lable";
            this.Genre_Lable.Size = new System.Drawing.Size(48, 19);
            this.Genre_Lable.TabIndex = 6;
            this.Genre_Lable.Text = "Genre";
            // 
            // Res_Lable
            // 
            this.Res_Lable.AutoSize = true;
            this.Res_Lable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Res_Lable.Location = new System.Drawing.Point(220, 336);
            this.Res_Lable.Name = "Res_Lable";
            this.Res_Lable.Size = new System.Drawing.Size(74, 18);
            this.Res_Lable.TabIndex = 7;
            this.Res_Lable.Text = "Resolution";
            // 
            // Actors_Lable
            // 
            this.Actors_Lable.AutoSize = true;
            this.Actors_Lable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actors_Lable.Location = new System.Drawing.Point(50, 174);
            this.Actors_Lable.Name = "Actors_Lable";
            this.Actors_Lable.Size = new System.Drawing.Size(56, 18);
            this.Actors_Lable.TabIndex = 8;
            this.Actors_Lable.Text = "Starring";
            // 
            // Movie_Poster
            // 
            this.Movie_Poster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Movie_Poster.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Movie_Poster.ErrorImage")));
            this.Movie_Poster.InitialImage = null;
            this.Movie_Poster.Location = new System.Drawing.Point(386, 83);
            this.Movie_Poster.Name = "Movie_Poster";
            this.Movie_Poster.Size = new System.Drawing.Size(210, 282);
            this.Movie_Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Movie_Poster.TabIndex = 9;
            this.Movie_Poster.TabStop = false;
            // 
            // runtime_Lable
            // 
            this.runtime_Lable.AutoSize = true;
            this.runtime_Lable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runtime_Lable.Location = new System.Drawing.Point(51, 336);
            this.runtime_Lable.Name = "runtime_Lable";
            this.runtime_Lable.Size = new System.Drawing.Size(60, 18);
            this.runtime_Lable.TabIndex = 10;
            this.runtime_Lable.Text = "Runtime";
            // 
            // ActorsBox
            // 
            this.ActorsBox.AcceptsTab = true;
            this.ActorsBox.BackColor = System.Drawing.Color.White;
            this.ActorsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ActorsBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActorsBox.Location = new System.Drawing.Point(53, 195);
            this.ActorsBox.Multiline = true;
            this.ActorsBox.Name = "ActorsBox";
            this.ActorsBox.ReadOnly = true;
            this.ActorsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ActorsBox.Size = new System.Drawing.Size(295, 71);
            this.ActorsBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Runtime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(163, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Year";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Genre(s)";
            // 
            // Movie_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(639, 621);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActorsBox);
            this.Controls.Add(this.runtime_Lable);
            this.Controls.Add(this.Movie_Poster);
            this.Controls.Add(this.Actors_Lable);
            this.Controls.Add(this.Res_Lable);
            this.Controls.Add(this.Genre_Lable);
            this.Controls.Add(this.Rating_Lable);
            this.Controls.Add(this.Year_Lable);
            this.Controls.Add(this.Title_Lable);
            this.Controls.Add(this.Watch_Movie);
            this.Controls.Add(this.M_Plot);
            this.Controls.Add(this.Movie_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Movie_Info";
            this.Text = "Movie Info";
            ((System.ComponentModel.ISupportInitialize)(this.Movie_Poster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Movie_Title;
        private System.Windows.Forms.TextBox M_Plot;
        private System.Windows.Forms.Button Watch_Movie;
        private System.Windows.Forms.Label Title_Lable;
        private System.Windows.Forms.Label Year_Lable;
        private System.Windows.Forms.Label Rating_Lable;
        private System.Windows.Forms.Label Genre_Lable;
        private System.Windows.Forms.Label Res_Lable;
        private System.Windows.Forms.Label Actors_Lable;
        private System.Windows.Forms.PictureBox Movie_Poster;
        private System.Windows.Forms.Label runtime_Lable;
        private System.Windows.Forms.TextBox ActorsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}