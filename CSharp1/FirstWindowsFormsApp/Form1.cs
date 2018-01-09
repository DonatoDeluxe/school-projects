using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWindowsFormsApp
{
    public partial class Form1 : Form
    {
        Button BtnLoad;
        PictureBox PbxShowImage;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Hello World";
            this.BackColor = Color.Gray;

            #region Button
            BtnLoad = new Button();
            BtnLoad.Text = "&Load";
            BtnLoad.Left = 30;
            BtnLoad.Top = 10;
            this.Controls.Add(BtnLoad);
            BtnLoad.Click += new EventHandler(BtnLoad_Click);
            #endregion

            #region PictureBox
            PbxShowImage = new PictureBox();
            PbxShowImage.BorderStyle = BorderStyle.Fixed3D;
            PbxShowImage.Width = Width / 2;
            PbxShowImage.Height = Height / 2;
            PbxShowImage.Left = (Width - PbxShowImage.Width) / 2;
            PbxShowImage.Top = (Height - PbxShowImage.Height) / 2;
            this.Controls.Add(PbxShowImage);
            #endregion
        }

        void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                PbxShowImage.Image = new Bitmap(dialog.OpenFile());
            }
            dialog.Dispose();
        }
    }
}
