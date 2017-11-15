using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace FirstTryInCV
{
    public static class ImageProccessor
    {
        public static Image<Bgr, byte> FindContours(Image<Bgr, byte> sourceImage)
        {
            Image<Bgr, byte> newImage = new Image<Bgr, byte>(sourceImage.Width, sourceImage.Height, new Bgr(0, 0, 0));
            Image<Gray, byte> convertedImage = sourceImage.Convert<Gray, byte>().ThresholdBinary(new Gray(120), new Gray(255));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(convertedImage, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            List<double> angles = new List<double>();
            for (var i = 0; i < contours.Size; i++)
            {
                CvInvoke.ApproxPolyDP(contours[i], contours[i], 2, true);
                CvInvoke.ApproxPolyDP(contours[i], contours[i], 2, true);

                var vectorOfPoint = contours[i];
                var vectorSize = vectorOfPoint.Size;
                if (vectorSize > 2)
                {
                    VectorOfVectorOfPoint arrWithVectors = new VectorOfVectorOfPoint(vectorOfPoint);
                    CvInvoke.DrawContours(newImage, arrWithVectors, -1, new MCvScalar(255, 255, 255));

                    var centerOfMass = GetCenterOfMass(vectorOfPoint.ToArray());
                    CvInvoke.PutText(newImage, (i + 1).ToString(), centerOfMass, FontFace.HersheyPlain, 1.0, new MCvScalar(255, 0, 0));

                    var boundingRectangle = CvInvoke.BoundingRectangle(vectorOfPoint);
                    angles.Add(Math.Atan(boundingRectangle.Height / boundingRectangle.Width) * 180 / Math.PI);
                    newImage.Draw(boundingRectangle, new Bgr(0, 255, 0), 1);
                    newImage.Save("temp" + (i + 1).ToString() + ".jpg");
                    FillContour(newImage, vectorOfPoint);
                }
            }

            return newImage;
        }

        public static Image<Gray, byte> CannyOperator(Image<Bgr, byte> sourceImage, double thresh = 50.0, double threshLink = 20.0)
        {
            Image<Gray, byte> cannyImage = new Image<Gray, byte>(sourceImage.Width, sourceImage.Height, new Gray(150.0));
            cannyImage = sourceImage.Canny(thresh, threshLink);

            return cannyImage;
        }

        public static Image<Bgr, float> Convolution(Image<Bgr, byte> sourceImage, float[,] coefficients)
        {
            ConvolutionKernelF kernel = new ConvolutionKernelF(coefficients);
            Image<Bgr, float> convolutedImage = sourceImage * kernel;

            return convolutedImage;
        }

        public static void FillContour(Image<Bgr, byte> sourceImage, VectorOfPoint vector)
        {
            Rectangle rect = new Rectangle();
            var result = CvInvoke.FloodFill(sourceImage, 
                null, 
                vector[0], 
                new MCvScalar(0, 255, 0), 
                out rect, 
                new MCvScalar(), 
                new MCvScalar(),
                Connectivity.EightConnected,
                FloodFillType.Default);

            sourceImage.Save("temp.jpg");
        }

        private static Point GetCenterOfMass(Point[] points)
        {
            var averageX = 0;
            var averageY = 0;

            foreach (var point in points)
            {
                averageX += point.X;
                averageY += point.Y;
            }

            return new Point(averageX / points.Length, averageY / points.Length);
        }

        public static void AnalyzeControursOrietation(Image<Bgr, byte> sourceImage)
        {
            Image<Gray, byte> convertedImage = sourceImage.Convert<Gray, byte>().ThresholdBinary(new Gray(120), new Gray(255));
            Image<Bgr, byte> newImage = new Image<Bgr, byte>(sourceImage.Width, sourceImage.Height, new Bgr(0, 0, 0));
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hier = new Mat();

            CvInvoke.FindContours(convertedImage, contours, hier, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (var i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];
                var length = CvInvoke.ArcLength(contour, false);
            }
        }
    }
}
