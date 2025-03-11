using System.Runtime.InteropServices;
using System.Security.Policy;

namespace Image_Color_Evaluator
{
    internal partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();

            // Hides the label under the buttons before showing the form
            lbl_Processing.Visible = false;
        }

        // Will hold the image reference
        private Bitmap referenceImage = null;

        private void btn_File_Click(object sender, EventArgs e)
        {
            if (ofd_Image.ShowDialog() == DialogResult.OK)
            {
                // Can only select images accepted by the filter
                referenceImage = (Bitmap)Image.FromFile(ofd_Image.FileName);
                updateDisplayImage();
            }
        }

        private void btn_ClipboardImage_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                // Gets the image from the clipboard, if the clipboard contains an image
                // Images on clipboard can be from applications like Snipping Tool
                referenceImage = (Bitmap)Clipboard.GetImage();
                updateDisplayImage();
            }
            else
            {
                MessageBox.Show("Clipboard does not contain a valid image!");
                return;
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            // Ensures that there is an image selected from file, or from clipboard
            if (referenceImage != null)
            {
                startImageScan();
            }
            else
            {
                MessageBox.Show("No image selected!");
            }
        }

        private void updateDisplayImage()
        {
            // Updates the pictureBox
            pic_ReferenceImage.Image = referenceImage;
        }

        private void toggleInteractables(bool toggle)
        {
            // Toggles all buttons that triggers functions through button onClick events
            btn_ClipboardImage.Enabled = toggle;
            btn_File.Enabled = toggle;
            btn_Start.Enabled = toggle;
            chk_IgnoreTransparent.Enabled = toggle;
        }

        private void startImageScan()
        {
            // Triggers necessary functions before starting the Background Worker

            // Disables all the buttons
            toggleInteractables(false);

            // Clears the color table
            dgv_ColorList.Rows.Clear();

            // Clears the list containing all color pairs
            colorPairs.Clear();

            // Runs the Background Worker
            bgw_PixelScanner.RunWorkerAsync();
        }

        private void updateProgress(int currentPixel, int totalPixels)
        {
            // Updates the text below the buttons to show progress
            // If the label is not currently visible, this function will ensure it is visible

            if (lbl_Processing.Visible == false)
            {
                lbl_Processing.Visible = true;
            }

            lbl_Processing.Text = $"Scanning in progress: {((Convert.ToDouble(currentPixel) / Convert.ToDouble(totalPixels)) * 100.0).ToString("0.00")}%" +
                $"\r\n\r\nCurrent Pixel: {currentPixel}" +
                $"\r\nTotal Pixels: {totalPixels}" +
                $"\r\nDifferent Colors Found: {colorPairs.Count}" +
                $"\r\n\r\nImage Width: {referenceImage.Width}" +
                $"\r\nImage Height: {referenceImage.Height}";
        }

        private void endScan()
        {
            // Hides the progress Text
            lbl_Processing.Visible = false;

            // Populating the DataGridView
            for (int i = 0; i < colorPairs.Count(); i++)
            {
                // Adds the colorPair item with a blank text at the first column
                if (chk_IgnoreTransparent.Checked)
                {
                    // since transparency is ignored, the color hex code and RGB values does not display Alpha
                    dgv_ColorList.Rows.Add("", colorPairs[i].HEXcolor, $"[R{colorPairs[i].ObjectColor.R}, G{colorPairs[i].ObjectColor.G}, B{colorPairs[i].ObjectColor.B}]", colorPairs[i].ObjectCounter, $"{colorPairs[i].ColorCoverage.ToString("0.00")}%");
                }
                else
                {
                    dgv_ColorList.Rows.Add("", colorPairs[i].HEXcolorARGB, $"[A{colorPairs[i].ObjectColor.A}, R{colorPairs[i].ObjectColor.R}, G{colorPairs[i].ObjectColor.G}, B{colorPairs[i].ObjectColor.B}]", colorPairs[i].ObjectCounter, $"{colorPairs[i].ColorCoverage.ToString("0.00")}%");
                }

                // Renders the color of the colorPair item in the first cell per row
                dgv_ColorList.Rows[i].Cells[0].Style.BackColor = colorPairs[i].ObjectColor;
            }

            // Generating Image Map - 50px Width, Npx Height (N means how many colors is in ColorPair after sorting)
            updateColorMap();

            // Enables all buttons
            toggleInteractables(true);

            // Display final color count
            grp_ColorSorting.Text = $"Color Sorting [{colorPairs.Count} colors]";

            // Unselect anything from the table so that nothing is highlighted
            clearGridSelection();
        }

        private void clearGridSelection()
        {
            // ensures nothing is selected on the datagridview
            dgv_ColorList.ClearSelection();
            dgv_ColorList.CurrentCell = null;
        }

        private void updateColorMap()
        {
            Bitmap colorMap = new Bitmap(50, colorPairs.Count);
            using (Graphics g = Graphics.FromImage(colorMap))
            {
                for (int p = 0; p < dgv_ColorList.RowCount; p++)
                {
                    g.FillRectangle(new SolidBrush(dgv_ColorList.Rows[p].Cells[0].Style.BackColor), new Rectangle(0, p, 50, 1));
                }
            }
            pic_ColorMap.Image = colorMap;
        }

        // Will contain all colorPairs that holds data for the color, its own counter, and the total canvas size in pixels
        private List<ColorPair> colorPairs = new List<ColorPair>();

        private void bgw_PixelScanner_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // starts the processing here

            // calculate the total pixels by W and H
            int bitW = referenceImage.Width, bitH = referenceImage.Height;
            int totalPixels = bitW * bitH;

            // initialize counter reference
            int currentPixel = 0;

            // Contains the last refresh time for the statistics
            DateTime lastScan = DateTime.Now;

            // create main loop for pixel scanning
            for (int y = 0; y < referenceImage.Height; y++)
            {
                for (int x = 0; x < referenceImage.Width; x++)
                {
                    // Get current pixel
                    Color currentColor = referenceImage.GetPixel(x, y);

                    // triggers if the currentColor is fully transparent
                    if (currentColor.A == 0)
                    {
                        continue; // continues to the next pixel
                    }

                    // initialize an isFound to check if its already been found
                    bool isFound = false;

                    // Loop through the list, if matches one color, increment value, else just increment outside loop
                    for (int z = 0; z < colorPairs.Count; z++)
                    {
                        if (colorPairs[z].ObjectColor.Equals(currentColor))
                        {
                            colorPairs[z].Increment();
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        colorPairs.Add(new ColorPair(currentColor, totalPixels));
                    }

                    // Increment currentPixel at the end before updating visual progress
                    currentPixel++;

                    // Should be called every second instead so that the progress text will update every second, and relocated again inside row scan
                    if (lastScan.AddSeconds(1).CompareTo(DateTime.Now) < 1)
                    {
                        // Moved outside per-row scan for less stops
                        Invoke((MethodInvoker)delegate ()
                        {
                            updateProgress(currentPixel, totalPixels);
                        });

                        lastScan = DateTime.Now;

                        // Let the thread sleep a little
                        Thread.Sleep(1);
                    }
                }
            }

            // sort all elements inside the list
            colorPairs.Sort();

            // call an invoke to end the scanning
            Invoke(new MethodInvoker(endScan));
        }

        private void dgv_ColorList_Sorted(object sender, EventArgs e)
        {
            updateColorMap();
            clearGridSelection();
        }

        private void dgv_ColorList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearGridSelection();
        }
    }
}
