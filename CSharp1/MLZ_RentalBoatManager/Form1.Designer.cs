namespace MLZ_RentalBoatManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.boatsFormList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteEntryBtn = new System.Windows.Forms.Button();
            this.newEntryBtn = new System.Windows.Forms.Button();
            this.saveEntryBtn = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.maxSailSpeedInput = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.maxMotorSpeedInput = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.numberOfPersonInput = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rentPerDayInput = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.heightInput = new System.Windows.Forms.TextBox();
            this.widthInput = new System.Windows.Forms.TextBox();
            this.lengthInput = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.licensePlateInput = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.powerInput = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.colorDropdown = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.categoryDropdown = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.modelInput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.brandInput = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.boatsFormList);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 600;
            this.splitContainer1.Size = new System.Drawing.Size(1176, 682);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // boatsFormList
            // 
            this.boatsFormList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boatsFormList.FormattingEnabled = true;
            this.boatsFormList.ItemHeight = 16;
            this.boatsFormList.Location = new System.Drawing.Point(0, 0);
            this.boatsFormList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.boatsFormList.Name = "boatsFormList";
            this.boatsFormList.Size = new System.Drawing.Size(266, 682);
            this.boatsFormList.TabIndex = 0;
            this.boatsFormList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1MinSize = 300;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer2.Panel2MinSize = 300;
            this.splitContainer2.Size = new System.Drawing.Size(906, 682);
            this.splitContainer2.SplitterDistance = 398;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteEntryBtn);
            this.groupBox1.Controls.Add(this.newEntryBtn);
            this.groupBox1.Controls.Add(this.saveEntryBtn);
            this.groupBox1.Controls.Add(this.groupBox14);
            this.groupBox1.Controls.Add(this.groupBox13);
            this.groupBox1.Controls.Add(this.groupBox12);
            this.groupBox1.Controls.Add(this.groupBox11);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(398, 682);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // deleteEntryBtn
            // 
            this.deleteEntryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteEntryBtn.Location = new System.Drawing.Point(262, 584);
            this.deleteEntryBtn.Name = "deleteEntryBtn";
            this.deleteEntryBtn.Size = new System.Drawing.Size(130, 49);
            this.deleteEntryBtn.TabIndex = 11;
            this.deleteEntryBtn.Text = "Eintrag löschen";
            this.deleteEntryBtn.UseVisualStyleBackColor = true;
            // 
            // newEntryBtn
            // 
            this.newEntryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newEntryBtn.Location = new System.Drawing.Point(134, 584);
            this.newEntryBtn.Name = "newEntryBtn";
            this.newEntryBtn.Size = new System.Drawing.Size(128, 49);
            this.newEntryBtn.TabIndex = 10;
            this.newEntryBtn.Text = "Eintrag erstellen";
            this.newEntryBtn.UseVisualStyleBackColor = true;
            this.newEntryBtn.Click += new System.EventHandler(this.newEntryBtn_Click);
            // 
            // saveEntryBtn
            // 
            this.saveEntryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveEntryBtn.Location = new System.Drawing.Point(6, 584);
            this.saveEntryBtn.Name = "saveEntryBtn";
            this.saveEntryBtn.Size = new System.Drawing.Size(128, 49);
            this.saveEntryBtn.TabIndex = 9;
            this.saveEntryBtn.Text = "Eintrag speichern";
            this.saveEntryBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.maxSailSpeedInput);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox14.Location = new System.Drawing.Point(3, 527);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(392, 51);
            this.groupBox14.TabIndex = 8;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Maximale Geschwindigkeit mit Segel in km/h";
            // 
            // maxSailSpeedInput
            // 
            this.maxSailSpeedInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxSailSpeedInput.Location = new System.Drawing.Point(3, 18);
            this.maxSailSpeedInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxSailSpeedInput.Name = "maxSailSpeedInput";
            this.maxSailSpeedInput.Size = new System.Drawing.Size(386, 22);
            this.maxSailSpeedInput.TabIndex = 0;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.maxMotorSpeedInput);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox13.Location = new System.Drawing.Point(3, 476);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(392, 51);
            this.groupBox13.TabIndex = 7;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Maximale Geschwindigkeit mit Motor in km/h";
            // 
            // maxMotorSpeedInput
            // 
            this.maxMotorSpeedInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxMotorSpeedInput.Location = new System.Drawing.Point(3, 18);
            this.maxMotorSpeedInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxMotorSpeedInput.Name = "maxMotorSpeedInput";
            this.maxMotorSpeedInput.Size = new System.Drawing.Size(386, 22);
            this.maxMotorSpeedInput.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.numberOfPersonInput);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox12.Location = new System.Drawing.Point(3, 425);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(392, 51);
            this.groupBox12.TabIndex = 6;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Anzahl Personen";
            // 
            // numberOfPersonInput
            // 
            this.numberOfPersonInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberOfPersonInput.Location = new System.Drawing.Point(3, 18);
            this.numberOfPersonInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numberOfPersonInput.Name = "numberOfPersonInput";
            this.numberOfPersonInput.Size = new System.Drawing.Size(386, 22);
            this.numberOfPersonInput.TabIndex = 0;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rentPerDayInput);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox11.Location = new System.Drawing.Point(3, 374);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(392, 51);
            this.groupBox11.TabIndex = 5;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Miete/Tag in CHF";
            // 
            // rentPerDayInput
            // 
            this.rentPerDayInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rentPerDayInput.Location = new System.Drawing.Point(3, 18);
            this.rentPerDayInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rentPerDayInput.Name = "rentPerDayInput";
            this.rentPerDayInput.Size = new System.Drawing.Size(386, 22);
            this.rentPerDayInput.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.heightInput);
            this.groupBox8.Controls.Add(this.widthInput);
            this.groupBox8.Controls.Add(this.lengthInput);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(3, 323);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(392, 51);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Länge/Breite/Höhe in Meter";
            // 
            // heightInput
            // 
            this.heightInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heightInput.Location = new System.Drawing.Point(259, 18);
            this.heightInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(130, 22);
            this.heightInput.TabIndex = 0;
            // 
            // widthInput
            // 
            this.widthInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.widthInput.Location = new System.Drawing.Point(131, 18);
            this.widthInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.widthInput.Name = "widthInput";
            this.widthInput.Size = new System.Drawing.Size(128, 22);
            this.widthInput.TabIndex = 0;
            // 
            // lengthInput
            // 
            this.lengthInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lengthInput.Location = new System.Drawing.Point(3, 18);
            this.lengthInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(128, 22);
            this.lengthInput.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.licensePlateInput);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 272);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(392, 51);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Nummernschild";
            // 
            // licensePlateInput
            // 
            this.licensePlateInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensePlateInput.Location = new System.Drawing.Point(3, 18);
            this.licensePlateInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.licensePlateInput.Name = "licensePlateInput";
            this.licensePlateInput.Size = new System.Drawing.Size(386, 22);
            this.licensePlateInput.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.powerInput);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 221);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(392, 51);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Leistung in PS";
            // 
            // powerInput
            // 
            this.powerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerInput.Location = new System.Drawing.Point(3, 18);
            this.powerInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.powerInput.Name = "powerInput";
            this.powerInput.Size = new System.Drawing.Size(386, 22);
            this.powerInput.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.colorDropdown);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 170);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(392, 51);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Farbe";
            // 
            // colorDropdown
            // 
            this.colorDropdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorDropdown.FormattingEnabled = true;
            this.colorDropdown.Location = new System.Drawing.Point(3, 18);
            this.colorDropdown.Name = "colorDropdown";
            this.colorDropdown.Size = new System.Drawing.Size(386, 24);
            this.colorDropdown.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.categoryDropdown);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 119);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(392, 51);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kategorie";
            // 
            // categoryDropdown
            // 
            this.categoryDropdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryDropdown.FormattingEnabled = true;
            this.categoryDropdown.Location = new System.Drawing.Point(3, 18);
            this.categoryDropdown.Name = "categoryDropdown";
            this.categoryDropdown.Size = new System.Drawing.Size(386, 24);
            this.categoryDropdown.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.modelInput);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 68);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 51);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modell";
            // 
            // modelInput
            // 
            this.modelInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelInput.Location = new System.Drawing.Point(3, 18);
            this.modelInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.modelInput.Name = "modelInput";
            this.modelInput.Size = new System.Drawing.Size(386, 22);
            this.modelInput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.brandInput);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 51);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Marke";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // brandInput
            // 
            this.brandInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brandInput.Location = new System.Drawing.Point(3, 18);
            this.brandInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.brandInput.Name = "brandInput";
            this.brandInput.Size = new System.Drawing.Size(386, 22);
            this.brandInput.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(504, 682);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 682);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1194, 481);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox boatsFormList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox brandInput;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox modelInput;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox maxSailSpeedInput;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox maxMotorSpeedInput;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox numberOfPersonInput;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox rentPerDayInput;
        private System.Windows.Forms.TextBox heightInput;
        private System.Windows.Forms.TextBox widthInput;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox lengthInput;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox licensePlateInput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox powerInput;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox colorDropdown;
        private System.Windows.Forms.ComboBox categoryDropdown;
        private System.Windows.Forms.Button deleteEntryBtn;
        private System.Windows.Forms.Button newEntryBtn;
        private System.Windows.Forms.Button saveEntryBtn;
    }
}

