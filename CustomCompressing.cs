using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCompresser
{
    public static class CustomCompressing
    {
        public static void Compress1(String filePath, long compressLevel) {
            using (Bitmap bmp = new Bitmap(filePath)) {
                bmp.Save(Path.ChangeExtension(filePath, "").Trim('.') + $"_{compressLevel}.jpg",
                ImageCodecInfo.GetImageEncoders()[1],
                new EncoderParameters() {
                    Param = new EncoderParameter[]
                    {
                        new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L - compressLevel)
                    }
                });
            }
        }
        public static void Compress2(String filePath, Int32 requiredWidth, Int32 requiredHeight) 
        {
            Bitmap reqBitmap = new Bitmap(new Bitmap(filePath),requiredWidth, requiredHeight);
            using (Graphics gr = Graphics.FromImage(reqBitmap)) 
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.DrawImage(bmp, new RectangleF(0, 0, reqSize.Width, reqSize.Height));
                gr.DrawImage();
            }
        }
    }
}
