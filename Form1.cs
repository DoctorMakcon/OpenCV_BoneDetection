using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace FirstTryInCV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                initialImage.Image = img;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap initialImageBitmap = new Bitmap(initialImage.Image);
            Image<Bgr, Byte> sourceImage = new Image<Bgr, byte>(initialImageBitmap);

            //median filter
            //Image<Bgr, Byte> smoothedImage = sourceImage.SmoothMedian(9);
            //smoothedImage.Save("afterMedian.jpg");

            //gaussian
            //sourceImage._SmoothGaussian(5);
            //bilatral
            sourceImage = sourceImage.SmoothBilatral(9, 120, 30);
            sourceImage.Save("afterBilatral.jpg");
            //sourceImage = sourceImage.SmoothBlur(4, 4);
            //sourceImage.Save("afterBlur.jpg");

            //canny edge detector
            Image<Gray, Byte> resultImage = ImageProccessor.CannyOperator(sourceImage, 120, 30);
            resultImage.Save("afterCanny.jpg");

            //find contours
            var imageWithContrours = ImageProccessor.FindContours(resultImage.Convert<Bgr, byte>());
            imageWithContrours.Save("afterContoursDetection.jpg");
            filteredImage.Image = imageWithContrours.Bitmap;

            ImageProccessor.AnalyzeControursOrietation(imageWithContrours);
        }
    }
}
