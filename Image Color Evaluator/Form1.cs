using System.Diagnostics;
using System.Text;

namespace Image_Color_Evaluator
{
    internal partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();
            lbl_ReadProgress.Visible = false;
        }

        private Bitmap referenceBitmap;
        private List<ColorAnalytics> pixelArray = new List<ColorAnalytics>();

        private void btn_ReadClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Clipboard.ContainsImage())
                {
                    MessageBox.Show("No valid image in the clipboard.\r\n\r\nThe application can accept image from clipboard set by applications like Snipping Tool\r\n\r\nTo scan images from files, please click \"Image from File\" instead!", "No image in clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                referenceBitmap = (Bitmap)Clipboard.GetImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong when trying to get image from clipboard.\r\nPlease try again.\r\n\r\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            readAllPixels();
        }

        private void btn_ImageFromFile_Click(object sender, EventArgs e)
        {
            if (ofd_Image.ShowDialog() == DialogResult.OK)
            {
                referenceBitmap = (Bitmap)Image.FromFile(ofd_Image.FileName);
            }

            readAllPixels();
        }

        private void readAllPixels()
        {
            pic_Image.Image = referenceBitmap;

            pixelArray.Clear();

            toggleInteractable(false);
            bgw_Reader.RunWorkerAsync();
        }

        private void toggleInteractable(bool toggle)
        {
            btn_ImageFromFile.Enabled = toggle;
            btn_ReadClipboard.Enabled = toggle;
        }

        private void endScan()
        {
            toggleInteractable(true);
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < pixelArray.Count; i++)
            {
                strBuild.AppendLine($"[{pixelArray[i].Color.GetHashCode()}] {pixelArray[i].Counter} pixels");
            }
            txt_Details.Text = strBuild.ToString();
        }

        private void bgw_Reader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate (){
                lbl_ReadProgress.Visible = true;
                lbl_ReadProgress.Text = "Ready...";
            });

            int pixelAmount = referenceBitmap.Width * referenceBitmap.Height;
            int currentPixel = 0;

            for (int y = 0; y < referenceBitmap.Height; y++)
            {
                for (int x = 0; x < referenceBitmap.Width; x++)
                {
                    bool isPixelFound = false;
                    for (int z = 0; z < pixelArray.Count; z++)
                    {
                        if (pixelArray[z].Color.Equals(referenceBitmap.GetPixel(x, y)))
                        {
                            pixelArray[z].IncrementCounter();
                            isPixelFound = true;
                            break;
                        }
                    }

                    if (!isPixelFound)
                    {
                        pixelArray.Add(new ColorAnalytics(referenceBitmap.GetPixel(x, y)));
                    }

                    currentPixel++;

                    Invoke((MethodInvoker)delegate ()
                    {
                        double percentage = Math.Round((Convert.ToDouble(currentPixel) / Convert.ToDouble(pixelAmount)) * 100.00, 2);
                        lbl_ReadProgress.Text = $"Reading Pixels... ({percentage}%)";
                    });

                    Thread.Sleep(10);
                }
            }

            int pixelArrayCounter = 0;
            List<ColorAnalytics> tempList = new List<ColorAnalytics>();

            for (int i = 0; i < pixelArray.Count; i++)
            {
                bool isLarger = false;
                for (int j = 0; j < tempList.Count; j++)
                {
                    if (pixelArray[i].Counter > tempList[j].Counter)
                    {
                        tempList.Insert(0, pixelArray[i]);
                    }
                }
                if (!isLarger)
                {
                    tempList.Add(pixelArray[i]);
                }
                pixelArray.Remove(pixelArray[i]);

                pixelArrayCounter++;

                Invoke((MethodInvoker)delegate ()
                {
                    double percentage = Math.Round((Convert.ToDouble(i) / Convert.ToDouble(pixelArray.Count)) * 100.00, 2);
                    lbl_ReadProgress.Text = $"Sorting Results... ({percentage}%)";
                });

                Thread.Sleep(10);
            }

            pixelArray = tempList;

            Invoke((MethodInvoker)delegate ()
            {
                lbl_ReadProgress.Visible = false;
                lbl_ReadProgress.Text = "Ready...";
                endScan();
            });
        }
    }
}
