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
            pic_ReferenceImage = new PictureBox();
            btn_File = new Button();
            btn_ClipboardImage = new Button();
            ofd_Image = new OpenFileDialog();
            lbl_Processing = new Label();
            bgw_PixelScanner = new System.ComponentModel.BackgroundWorker();
            btn_Start = new Button();
            grp_ColorSorting = new GroupBox();
            pic_ColorMap = new PictureBox();
            dgv_ColorList = new DataGridView();
            Column5 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            chk_IgnoreTransparent = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pic_ReferenceImage).BeginInit();
            grp_ColorSorting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_ColorMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_ColorList).BeginInit();
            SuspendLayout();
            // 
            // pic_ReferenceImage
            // 
            pic_ReferenceImage.BackColor = Color.Black;
            pic_ReferenceImage.Location = new Point(12, 12);
            pic_ReferenceImage.Name = "pic_ReferenceImage";
            pic_ReferenceImage.Size = new Size(200, 200);
            pic_ReferenceImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ReferenceImage.TabIndex = 0;
            pic_ReferenceImage.TabStop = false;
            // 
            // btn_File
            // 
            btn_File.Location = new Point(12, 218);
            btn_File.Name = "btn_File";
            btn_File.Size = new Size(200, 23);
            btn_File.TabIndex = 1;
            btn_File.Text = "Select from File";
            btn_File.UseVisualStyleBackColor = true;
            btn_File.Click += btn_File_Click;
            // 
            // btn_ClipboardImage
            // 
            btn_ClipboardImage.Location = new Point(12, 247);
            btn_ClipboardImage.Name = "btn_ClipboardImage";
            btn_ClipboardImage.Size = new Size(200, 23);
            btn_ClipboardImage.TabIndex = 2;
            btn_ClipboardImage.Text = "Image from Clipboard";
            btn_ClipboardImage.UseVisualStyleBackColor = true;
            btn_ClipboardImage.Click += btn_ClipboardImage_Click;
            // 
            // ofd_Image
            // 
            ofd_Image.Filter = "Image File|*.jpg;*.jpeg;*.png";
            // 
            // lbl_Processing
            // 
            lbl_Processing.AutoSize = true;
            lbl_Processing.Location = new Point(12, 327);
            lbl_Processing.Name = "lbl_Processing";
            lbl_Processing.Size = new Size(38, 15);
            lbl_Processing.TabIndex = 3;
            lbl_Processing.Text = "label1";
            // 
            // bgw_PixelScanner
            // 
            bgw_PixelScanner.DoWork += bgw_PixelScanner_DoWork;
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(12, 276);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(200, 23);
            btn_Start.TabIndex = 4;
            btn_Start.Text = "Start Scanning";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // grp_ColorSorting
            // 
            grp_ColorSorting.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grp_ColorSorting.Controls.Add(pic_ColorMap);
            grp_ColorSorting.Controls.Add(dgv_ColorList);
            grp_ColorSorting.Location = new Point(218, 12);
            grp_ColorSorting.Name = "grp_ColorSorting";
            grp_ColorSorting.Size = new Size(554, 537);
            grp_ColorSorting.TabIndex = 5;
            grp_ColorSorting.TabStop = false;
            grp_ColorSorting.Text = "Color Sorting";
            // 
            // pic_ColorMap
            // 
            pic_ColorMap.Location = new Point(6, 22);
            pic_ColorMap.Name = "pic_ColorMap";
            pic_ColorMap.Size = new Size(25, 509);
            pic_ColorMap.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_ColorMap.TabIndex = 1;
            pic_ColorMap.TabStop = false;
            // 
            // dgv_ColorList
            // 
            dgv_ColorList.AllowUserToAddRows = false;
            dgv_ColorList.AllowUserToDeleteRows = false;
            dgv_ColorList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_ColorList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ColorList.Columns.AddRange(new DataGridViewColumn[] { Column5, Column1, Column2, Column3, Column4 });
            dgv_ColorList.Location = new Point(37, 22);
            dgv_ColorList.MultiSelect = false;
            dgv_ColorList.Name = "dgv_ColorList";
            dgv_ColorList.ReadOnly = true;
            dgv_ColorList.RowHeadersVisible = false;
            dgv_ColorList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_ColorList.Size = new Size(511, 509);
            dgv_ColorList.TabIndex = 0;
            dgv_ColorList.TabStop = false;
            dgv_ColorList.CellContentClick += dgv_ColorList_CellContentClick;
            dgv_ColorList.Sorted += dgv_ColorList_Sorted;
            // 
            // Column5
            // 
            Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Column5.HeaderText = "Color";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 61;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Color Code (HEX)";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Color Code (R, G, B)";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Pixel Count";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Coverage";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // chk_IgnoreTransparent
            // 
            chk_IgnoreTransparent.AutoSize = true;
            chk_IgnoreTransparent.Location = new Point(12, 305);
            chk_IgnoreTransparent.Name = "chk_IgnoreTransparent";
            chk_IgnoreTransparent.Size = new Size(124, 19);
            chk_IgnoreTransparent.TabIndex = 6;
            chk_IgnoreTransparent.Text = "Ignore Transparent";
            chk_IgnoreTransparent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(chk_IgnoreTransparent);
            Controls.Add(grp_ColorSorting);
            Controls.Add(btn_Start);
            Controls.Add(lbl_Processing);
            Controls.Add(btn_ClipboardImage);
            Controls.Add(btn_File);
            Controls.Add(pic_ReferenceImage);
            Name = "Form1";
            Text = "Image Color Evaluator";
            ((System.ComponentModel.ISupportInitialize)pic_ReferenceImage).EndInit();
            grp_ColorSorting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic_ColorMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_ColorList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pic_ReferenceImage;
        private Button btn_File;
        private Button btn_ClipboardImage;
        private OpenFileDialog ofd_Image;
        private Label lbl_Processing;
        private System.ComponentModel.BackgroundWorker bgw_PixelScanner;
        private Button btn_Start;
        private GroupBox grp_ColorSorting;
        private DataGridView dgv_ColorList;
        private CheckBox chk_IgnoreTransparent;
        private PictureBox pic_ColorMap;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}
