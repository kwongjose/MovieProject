﻿namespace MovieLib
{
    partial class UpdateRow
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
            this.Tpath = new System.Windows.Forms.TextBox();
            this.Plot = new System.Windows.Forms.TextBox();
            this.Length = new System.Windows.Forms.TextBox();
            this.Rating = new System.Windows.Forms.TextBox();
            this.Genra = new System.Windows.Forms.TextBox();
            this.Year = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UpDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tpath
            // 
            this.Tpath.Location = new System.Drawing.Point(65, 36);
            this.Tpath.Multiline = true;
            this.Tpath.Name = "Tpath";
            this.Tpath.ReadOnly = true;
            this.Tpath.Size = new System.Drawing.Size(395, 44);
            this.Tpath.TabIndex = 0;
            // 
            // Plot
            // 
            this.Plot.Location = new System.Drawing.Point(140, 376);
            this.Plot.Multiline = true;
            this.Plot.Name = "Plot";
            this.Plot.Size = new System.Drawing.Size(378, 67);
            this.Plot.TabIndex = 1;
            // 
            // Length
            // 
            this.Length.Location = new System.Drawing.Point(140, 326);
            this.Length.Name = "Length";
            this.Length.Size = new System.Drawing.Size(100, 20);
            this.Length.TabIndex = 2;
            // 
            // Rating
            // 
            this.Rating.Location = new System.Drawing.Point(140, 269);
            this.Rating.Name = "Rating";
            this.Rating.Size = new System.Drawing.Size(100, 20);
            this.Rating.TabIndex = 3;
            // 
            // Genra
            // 
            this.Genra.Location = new System.Drawing.Point(140, 219);
            this.Genra.Name = "Genra";
            this.Genra.Size = new System.Drawing.Size(378, 20);
            this.Genra.TabIndex = 4;
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(140, 166);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(100, 20);
            this.Year.TabIndex = 5;
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(140, 113);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(378, 20);
            this.Title.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Plot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rating";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Genra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Year";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Title:";
            // 
            // UpDate
            // 
            this.UpDate.Location = new System.Drawing.Point(233, 468);
            this.UpDate.Name = "UpDate";
            this.UpDate.Size = new System.Drawing.Size(108, 23);
            this.UpDate.TabIndex = 13;
            this.UpDate.Text = "UpDate Movie";
            this.UpDate.UseVisualStyleBackColor = true;
            this.UpDate.Click += new System.EventHandler(this.UpDate_Click);
            // 
            // UpdateRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 515);
            this.Controls.Add(this.UpDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Genra);
            this.Controls.Add(this.Rating);
            this.Controls.Add(this.Length);
            this.Controls.Add(this.Plot);
            this.Controls.Add(this.Tpath);
            this.Name = "UpdateRow";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tpath;
        private System.Windows.Forms.TextBox Plot;
        private System.Windows.Forms.TextBox Length;
        private System.Windows.Forms.TextBox Rating;
        private System.Windows.Forms.TextBox Genra;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button UpDate;
    }
}