/*using Shared.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shared.Validation
{
    public partial class ValidationContract
    {
        private static ImageFormat GetImageFormat(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM"); // BMP    
            var gif = Encoding.ASCII.GetBytes("GIF"); // GIF    

            var png = new byte[]
            {
            137,
            80,
            78,
            71
            }; // PNG    

            var tiff = new byte[]
            {
            73,
            73,
            42
            }; // TIFF    

            var tiff2 = new byte[]
            {
            77,
            77,
            42
            }; // TIFF    

            var jpeg = new byte[]
            {
            255,
            216,
            255,
            224
            }; // jpeg    

            var jpeg2 = new byte[]
            {
            255,
            216,
            255,
            225
            }; // jpeg canon    

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        public ValidationContract IsValidImageFormat(byte[] image, IList<ImageFormat> acceptablesFormats, string property, string message)
        {
            var imageFormat = GetImageFormat(image);

            bool isAcceptableImageFormat = acceptablesFormats.Any(x => x.Equals(imageFormat));

            if(!isAcceptableImageFormat)
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsValidExtension(string fileName,string acceptableExtension, string property, string message)
        {
            string extension = Path.GetExtension(fileName).ToLower().Replace(".", "");

            if(extension != acceptableExtension.ToLower())
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsValidExtension(string fileName, IList<string> acceptableExtension, string property, string message)
        {
            string extension = Path.GetExtension(fileName).ToLower().Replace(".","");

            if (!acceptableExtension.Any(x => x.ToLower().Equals(extension)))
                AddNotification(property, message);

            return this;
        }

        public ValidationContract IsPDF(Stream arquivo, string property, string message)
        {

            var pdfString = "%PDF-";
            var pdfBytes = Encoding.ASCII.GetBytes(pdfString);
            var len = pdfBytes.Length;
            var buf = new byte[len];
            var remaining = len;
            var pos = 0;

            bool isPDF = true;
            using (var f = arquivo)
            {
                while (remaining > 0)
                {
                    var amtRead = f.Read(buf, pos, remaining);
                    if (amtRead == 0) isPDF = false;
                    remaining -= amtRead;
                    pos += amtRead;
                }
            }

            isPDF = pdfBytes.SequenceEqual(buf);

            if (!isPDF)
                AddNotification(property, message);

            return this;
        }


    }
}*/
