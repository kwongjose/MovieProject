using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib
{
    public partial class FileInfo : Form
    {
        public FileInfo(List<String> FileList)
        {
            InitializeComponent();
            StringBuilder Sb = new StringBuilder();
            foreach(String file in FileList)
            {
                Sb.Append(file + "\r\n");
            }
            textBox1.Text = Sb.ToString();
        }

        private void FileInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
