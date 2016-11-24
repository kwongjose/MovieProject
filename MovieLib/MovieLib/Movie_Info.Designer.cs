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
            this.M_Plot.Location = new System.Drawing.Point(26, 426);
            this.M_Plot.Multiline = true;
            this.M_Plot.Name = "M_Plot";
            this.M_Plot.ReadOnly = true;
            this.M_Plot.Size = new System.Drawing.Size(566, 152);
            this.M_Plot.TabIndex = 1;
            // 
            // Watch_Movie
            // 
            this.Watch_Movie.Location = new System.Drawing.Point(232, 595);
            this.Watch_Movie.Name = "Watch_Movie";
            this.Watch_Movie.Size = new System.Drawing.Size(115, 23);
            this.Watch_Movie.TabIndex = 2;
            this.Watch_Movie.Text = "Watch Movie";
            this.Watch_Movie.UseVisualStyleBackColor = true;
            this.Watch_Movie.Click += new System.EventHandler(this.Watch_Movie_Click);
            // 
            // Title_Lable
            // 
            this.Title_Lable.AutoSize = true;
            this.Title_Lable.Location = new System.Drawing.Point(48, 28);
            this.Title_Lable.Name = "Title_Lable";
            this.Title_Lable.Size = new System.Drawing.Size(35, 13);
            this.Title_Lable.TabIndex = 3;
            this.Title_Lable.Text = "label1";
            this.Title_Lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Year_Lable
            // 
            this.Year_Lable.AutoSize = true;
            this.Year_Lable.Location = new System.Drawing.Point(48, 83);
            this.Year_Lable.Name = "Year_Lable";
            this.Year_Lable.Size = new System.Drawing.Size(35, 13);
            this.Year_Lable.TabIndex = 4;
            this.Year_Lable.Text = "label1";
            // 
            // Rating_Lable
            // 
            this.Rating_Lable.AutoSize = true;
            this.Rating_Lable.Location = new System.Drawing.Point(48, 208);
            this.Rating_Lable.Name = "Rating_Lable";
            this.Rating_Lable.Size = new System.Drawing.Size(35, 13);
            this.Rating_Lable.TabIndex = 5;
            this.Rating_Lable.Text = "label1";
            // 
            // Genre_Lable
            // 
            this.Genre_Lable.AutoSize = true;
            this.Genre_Lable.Location = new System.Drawing.Point(48, 140);
            this.Genre_Lable.Name = "Genre_Lable";
            this.Genre_Lable.Size = new System.Drawing.Size(35, 13);
            this.Genre_Lable.TabIndex = 6;
            this.Genre_Lable.Text = "label2";
            // 
            // Res_Lable
            // 
            this.Res_Lable.AutoSize = true;
            this.Res_Lable.Location = new System.Drawing.Point(48, 327);
            this.Res_Lable.Name = "Res_Lable";
            this.Res_Lable.Size = new System.Drawing.Size(35, 13);
            this.Res_Lable.TabIndex = 7;
            this.Res_Lable.Text = "label3";
            // 
            // Actors_Lable
            // 
            this.Actors_Lable.AutoSize = true;
            this.Actors_Lable.Location = new System.Drawing.Point(48, 271);
            this.Actors_Lable.Name = "Actors_Lable";
            this.Actors_Lable.Size = new System.Drawing.Size(0, 13);
            this.Actors_Lable.TabIndex = 8;
            // 
            // Movie_Poster
            // 
            this.Movie_Poster.ErrorImage = ((System.Drawing.Image)(resources.GetObject("Movie_Poster.ErrorImage")));
            this.Movie_Poster.InitialImage = null;
            this.Movie_Poster.Location = new System.Drawing.Point(423, 76);
            this.Movie_Poster.Name = "Movie_Poster";
            this.Movie_Poster.Size = new System.Drawing.Size(169, 208);
            this.Movie_Poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Movie_Poster.TabIndex = 9;
            this.Movie_Poster.TabStop = false;
            // 
            // runtime_Lable
            // 
            this.runtime_Lable.AutoSize = true;
            this.runtime_Lable.Location = new System.Drawing.Point(51, 370);
            this.runtime_Lable.Name = "runtime_Lable";
            this.runtime_Lable.Size = new System.Drawing.Size(35, 13);
            this.runtime_Lable.TabIndex = 10;
            this.runtime_Lable.Text = "label1";
            // 
            // Movie_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 630);
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
            this.Name = "Movie_Info";
            this.Text = "Form2";
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
    }
}