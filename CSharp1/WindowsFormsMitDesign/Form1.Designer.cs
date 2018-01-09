namespace WindowsFormsMitDesign
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLoad = new System.Windows.Forms.Button();
            this.PbxShowImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbxShowImage)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLoad
            // 
            this.BtnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoad.Location = new System.Drawing.Point(12, 10);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(693, 61);
            this.BtnLoad.TabIndex = 0;
            this.BtnLoad.Text = "&Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // PbxShowImage
            // 
            this.PbxShowImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PbxShowImage.Location = new System.Drawing.Point(12, 77);
            this.PbxShowImage.Name = "PbxShowImage";
            this.PbxShowImage.Size = new System.Drawing.Size(693, 437);
            this.PbxShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbxShowImage.TabIndex = 1;
            this.PbxShowImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 526);
            this.Controls.Add(this.PbxShowImage);
            this.Controls.Add(this.BtnLoad);
            this.Name = "Form1";
            this.Text = "Picture Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.PbxShowImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.PictureBox PbxShowImage;
    }
}

