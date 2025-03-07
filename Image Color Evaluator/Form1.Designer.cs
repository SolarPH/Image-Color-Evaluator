namespace Image_Color_Evaluator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pic_Image = new PictureBox();
            btn_ImageFromFile = new Button();
            btn_ReadClipboard = new Button();
            ofd_Image = new OpenFileDialog();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            txt_Details = new TextBox();
            bgw_Reader = new System.ComponentModel.BackgroundWorker();
            lbl_ReadProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_Image).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pic_Image
            // 
            pic_Image.BackColor = Color.White;
            pic_Image.Location = new Point(12, 12);
            pic_Image.Name = "pic_Image";
            pic_Image.Size = new Size(200, 200);
            pic_Image.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Image.TabIndex = 0;
            pic_Image.TabStop = false;
            // 
            // btn_ImageFromFile
            // 
            btn_ImageFromFile.Location = new Point(12, 218);
            btn_ImageFromFile.Name = "btn_ImageFromFile";
            btn_ImageFromFile.Size = new Size(200, 23);
            btn_ImageFromFile.TabIndex = 1;
            btn_ImageFromFile.Text = "Image From File";
            btn_ImageFromFile.UseVisualStyleBackColor = true;
            btn_ImageFromFile.Click += btn_ImageFromFile_Click;
            // 
            // btn_ReadClipboard
            // 
            btn_ReadClipboard.Location = new Point(12, 247);
            btn_ReadClipboard.Name = "btn_ReadClipboard";
            btn_ReadClipboard.Size = new Size(200, 23);
            btn_ReadClipboard.TabIndex = 2;
            btn_ReadClipboard.Text = "Read from Clipboard";
            btn_ReadClipboard.UseVisualStyleBackColor = true;
            btn_ReadClipboard.Click += btn_ReadClipboard_Click;
            // 
            // ofd_Image
            // 
            ofd_Image.Filter = "Image|*.png;*.jpg;*.jpeg";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(txt_Details);
            groupBox1.Location = new Point(218, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(570, 426);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Image Scan Details";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(6, 206);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(558, 214);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pixel Data Check";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(546, 186);
            dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "HexCode";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Pixel Count";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Coverage";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // txt_Details
            // 
            txt_Details.Location = new Point(6, 22);
            txt_Details.Multiline = true;
            txt_Details.Name = "txt_Details";
            txt_Details.ReadOnly = true;
            txt_Details.Size = new Size(558, 178);
            txt_Details.TabIndex = 0;
            txt_Details.Text = "Waiting for Image...";
            // 
            // bgw_Reader
            // 
            bgw_Reader.DoWork += bgw_Reader_DoWork;
            // 
            // lbl_ReadProgress
            // 
            lbl_ReadProgress.AutoSize = true;
            lbl_ReadProgress.Location = new Point(12, 273);
            lbl_ReadProgress.Name = "lbl_ReadProgress";
            lbl_ReadProgress.Size = new Size(38, 15);
            lbl_ReadProgress.TabIndex = 4;
            lbl_ReadProgress.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_ReadProgress);
            Controls.Add(groupBox1);
            Controls.Add(btn_ReadClipboard);
            Controls.Add(btn_ImageFromFile);
            Controls.Add(pic_Image);
            Name = "Form1";
            Text = "Image Color Evaluator";
            ((System.ComponentModel.ISupportInitialize)pic_Image).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pic_Image;
        private Button btn_ImageFromFile;
        private Button btn_ReadClipboard;
        private OpenFileDialog ofd_Image;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private TextBox txt_Details;
        private System.ComponentModel.BackgroundWorker bgw_Reader;
        private Label lbl_ReadProgress;
    }
}
