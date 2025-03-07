namespace Image_Color_Evaluator
{
    internal partial class Form1 : Form
    {
        internal Form1()
        {
            InitializeComponent();
        }

        private Bitmap referenceBitmap;
        private List<Color> pixelArray = new List<Color>();

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


        }
    }
}
