namespace MovieLib
{
    partial class NewRow
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
            this.Mplot = new System.Windows.Forms.TextBox();
            this.MRes = new System.Windows.Forms.TextBox();
            this.Mlength = new System.Windows.Forms.TextBox();
            this.MRating = new System.Windows.Forms.TextBox();
            this.MGernra = new System.Windows.Forms.TextBox();
            this.Myear = new System.Windows.Forms.TextBox();
            this.Mtitle = new System.Windows.Forms.TextBox();
            this.Path = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.Plot = new System.Windows.Forms.Label();
            this.Res = new System.Windows.Forms.Label();
            this.Length = new System.Windows.Forms.Label();
            this.Rating = new System.Windows.Forms.Label();
            this.Gernra = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Fpath = new System.Windows.Forms.Label();
            this.Imdb = new System.Windows.Forms.CheckBox();
            this.ImdbId = new System.Windows.Forms.TextBox();
            this.ActorList = new System.Windows.Forms.CheckedListBox();
            this.Actor_name = new System.Windows.Forms.TextBox();
            this.AddActor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mplot
            // 
            this.Mplot.Location = new System.Drawing.Point(88, 417);
            this.Mplot.Multiline = true;
            this.Mplot.Name = "Mplot";
            this.Mplot.Size = new System.Drawing.Size(417, 84);
            this.Mplot.TabIndex = 0;
            // 
            // MRes
            // 
            this.MRes.Location = new System.Drawing.Point(88, 364);
            this.MRes.Name = "MRes";
            this.MRes.Size = new System.Drawing.Size(165, 20);
            this.MRes.TabIndex = 1;
            // 
            // Mlength
            // 
            this.Mlength.Location = new System.Drawing.Point(88, 309);
            this.Mlength.Name = "Mlength";
            this.Mlength.Size = new System.Drawing.Size(100, 20);
            this.Mlength.TabIndex = 2;
            // 
            // MRating
            // 
            this.MRating.Location = new System.Drawing.Point(88, 253);
            this.MRating.Name = "MRating";
            this.MRating.Size = new System.Drawing.Size(100, 20);
            this.MRating.TabIndex = 3;
            // 
            // MGernra
            // 
            this.MGernra.Location = new System.Drawing.Point(88, 208);
            this.MGernra.Name = "MGernra";
            this.MGernra.Size = new System.Drawing.Size(417, 20);
            this.MGernra.TabIndex = 4;
            // 
            // Myear
            // 
            this.Myear.Location = new System.Drawing.Point(88, 153);
            this.Myear.Name = "Myear";
            this.Myear.Size = new System.Drawing.Size(100, 20);
            this.Myear.TabIndex = 5;
            // 
            // Mtitle
            // 
            this.Mtitle.Location = new System.Drawing.Point(88, 104);
            this.Mtitle.Name = "Mtitle";
            this.Mtitle.Size = new System.Drawing.Size(417, 20);
            this.Mtitle.TabIndex = 6;
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(88, 25);
            this.Path.Multiline = true;
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(417, 48);
            this.Path.TabIndex = 7;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(219, 581);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // Plot
            // 
            this.Plot.AutoSize = true;
            this.Plot.Location = new System.Drawing.Point(25, 456);
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(25, 13);
            this.Plot.TabIndex = 9;
            this.Plot.Text = "Plot";
            // 
            // Res
            // 
            this.Res.AutoSize = true;
            this.Res.Location = new System.Drawing.Point(28, 370);
            this.Res.Name = "Res";
            this.Res.Size = new System.Drawing.Size(57, 13);
            this.Res.TabIndex = 10;
            this.Res.Text = "Resolution";
            // 
            // Length
            // 
            this.Length.AutoSize = true;
            this.Length.Location = new System.Drawing.Point(28, 315);
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(40, 13);
            this.Length.TabIndex = 11;
            this.Length.Text = "Length";
            // 
            // Rating
            // 
            this.Rating.AutoSize = true;
            this.Rating.Location = new System.Drawing.Point(28, 259);
            this.Rating.Name = "Rating";
            this.Rating.Size = new System.Drawing.Size(38, 13);
            this.Rating.TabIndex = 12;
            this.Rating.Text = "Rating";
            // 
            // Gernra
            // 
            this.Gernra.AutoSize = true;
            this.Gernra.Location = new System.Drawing.Point(31, 214);
            this.Gernra.Name = "Gernra";
            this.Gernra.Size = new System.Drawing.Size(39, 13);
            this.Gernra.TabIndex = 13;
            this.Gernra.Text = "Gernra";
            // 
            // Year
            // 
            this.Year.AutoSize = true;
            this.Year.Location = new System.Drawing.Point(28, 159);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(29, 13);
            this.Year.TabIndex = 14;
            this.Year.Text = "Year";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(28, 110);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(27, 13);
            this.Title.TabIndex = 15;
            this.Title.Text = "Title";
            // 
            // Fpath
            // 
            this.Fpath.AutoSize = true;
            this.Fpath.Location = new System.Drawing.Point(28, 59);
            this.Fpath.Name = "Fpath";
            this.Fpath.Size = new System.Drawing.Size(48, 13);
            this.Fpath.TabIndex = 16;
            this.Fpath.Text = "File Path";
            // 
            // Imdb
            // 
            this.Imdb.AutoSize = true;
            this.Imdb.Location = new System.Drawing.Point(12, 559);
            this.Imdb.Name = "Imdb";
            this.Imdb.Size = new System.Drawing.Size(64, 17);
            this.Imdb.TabIndex = 17;
            this.Imdb.Text = "IMDb Id";
            this.Imdb.UseVisualStyleBackColor = true;
            this.Imdb.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ImdbId
            // 
            this.ImdbId.Location = new System.Drawing.Point(88, 557);
            this.ImdbId.Name = "ImdbId";
            this.ImdbId.Size = new System.Drawing.Size(100, 20);
            this.ImdbId.TabIndex = 18;
            // 
            // ActorList
            // 
            this.ActorList.FormattingEnabled = true;
            this.ActorList.Location = new System.Drawing.Point(652, 159);
            this.ActorList.Name = "ActorList";
            this.ActorList.Size = new System.Drawing.Size(219, 184);
            this.ActorList.TabIndex = 19;
            // 
            // Actor_name
            // 
            this.Actor_name.Location = new System.Drawing.Point(652, 107);
            this.Actor_name.Name = "Actor_name";
            this.Actor_name.Size = new System.Drawing.Size(100, 20);
            this.Actor_name.TabIndex = 20;
            // 
            // AddActor
            // 
            this.AddActor.Location = new System.Drawing.Point(795, 110);
            this.AddActor.Name = "AddActor";
            this.AddActor.Size = new System.Drawing.Size(75, 23);
            this.AddActor.TabIndex = 21;
            this.AddActor.Text = "Add";
            this.AddActor.UseVisualStyleBackColor = true;
            this.AddActor.Click += new System.EventHandler(this.AddActor_Click);
            // 
            // NewRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 616);
            this.Controls.Add(this.AddActor);
            this.Controls.Add(this.Actor_name);
            this.Controls.Add(this.ActorList);
            this.Controls.Add(this.ImdbId);
            this.Controls.Add(this.Imdb);
            this.Controls.Add(this.Fpath);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Gernra);
            this.Controls.Add(this.Rating);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.Res);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Mtitle);
            this.Controls.Add(this.Myear);
            this.Controls.Add(this.MGernra);
            this.Controls.Add(this.MRating);
            this.Controls.Add(this.Mlength);
            this.Controls.Add(this.MRes);
            this.Controls.Add(this.Mplot);
            this.Name = "NewRow";
            this.Text = "NewRow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Mplot;
        private System.Windows.Forms.TextBox MRes;
        private System.Windows.Forms.TextBox Mlength;
        private System.Windows.Forms.TextBox MRating;
        private System.Windows.Forms.TextBox MGernra;
        private System.Windows.Forms.TextBox Myear;
        private System.Windows.Forms.TextBox Mtitle;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label Plot;
        private System.Windows.Forms.Label Res;
        private System.Windows.Forms.Label Length;
        private System.Windows.Forms.Label Rating;
        private System.Windows.Forms.Label Gernra;
        private System.Windows.Forms.Label Year;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Fpath;
        private System.Windows.Forms.CheckBox Imdb;
        private System.Windows.Forms.TextBox ImdbId;
        private System.Windows.Forms.CheckedListBox ActorList;
        private System.Windows.Forms.TextBox Actor_name;
        private System.Windows.Forms.Button AddActor;
    }
}