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
            this.Movie_Title = new System.Windows.Forms.Label();
            this.M_Plot = new System.Windows.Forms.TextBox();
            this.Watch_Movie = new System.Windows.Forms.Button();
            this.M_Title = new System.Windows.Forms.Label();
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
            this.M_Plot.Location = new System.Drawing.Point(33, 91);
            this.M_Plot.Multiline = true;
            this.M_Plot.Name = "M_Plot";
            this.M_Plot.ReadOnly = true;
            this.M_Plot.Size = new System.Drawing.Size(566, 152);
            this.M_Plot.TabIndex = 1;
            this.M_Plot.TextChanged += new System.EventHandler(this.M_Plot_TextChanged);
            // 
            // Watch_Movie
            // 
            this.Watch_Movie.Location = new System.Drawing.Point(267, 272);
            this.Watch_Movie.Name = "Watch_Movie";
            this.Watch_Movie.Size = new System.Drawing.Size(115, 23);
            this.Watch_Movie.TabIndex = 2;
            this.Watch_Movie.Text = "Watch Movie";
            this.Watch_Movie.UseVisualStyleBackColor = true;
            this.Watch_Movie.Click += new System.EventHandler(this.Watch_Movie_Click);
            // 
            // M_Title
            // 
            this.M_Title.AutoSize = true;
            this.M_Title.Location = new System.Drawing.Point(94, 40);
            this.M_Title.Name = "M_Title";
            this.M_Title.Size = new System.Drawing.Size(35, 13);
            this.M_Title.TabIndex = 3;
            this.M_Title.Text = "label1";
            this.M_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Movie_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 332);
            this.Controls.Add(this.M_Title);
            this.Controls.Add(this.Watch_Movie);
            this.Controls.Add(this.M_Plot);
            this.Controls.Add(this.Movie_Title);
            this.Name = "Movie_Info";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Movie_Title;
        private System.Windows.Forms.TextBox M_Plot;
        private System.Windows.Forms.Button Watch_Movie;
        private System.Windows.Forms.Label M_Title;
    }
}