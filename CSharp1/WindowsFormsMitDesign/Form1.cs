﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMitDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PbxShowImage.Image = new Bitmap(dialog.OpenFile());
            }
            dialog.Dispose();
        }
    }
}
