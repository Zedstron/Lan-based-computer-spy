using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteClient.Core
{
    class Utility
    {
        public static byte[] Optimize(Bitmap img, int depth)
        {
            if (img != null)
            {
                try
                {
                    // Encoder parameter for image quality 
                    MemoryStream ms = new MemoryStream();
                    EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, depth);
                    // JPEG image codec 
                    ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = qualityParam;
                    img.Save(ms, jpegCodec, encoderParams);
                    return ms.GetBuffer();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, ImageFormat.Png);
                    return ms.GetBuffer();
                }
            }
            else
                return null;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            try
            {
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

                for (int i = 0; i < codecs.Length; i++)
                    if (codecs[i].MimeType == mimeType)
                        return codecs[i];

                return null;
            }
            catch (Exception e)
            {
                RemoteClient.LogError(e.ToString());
                return null;
            }
        }
    }
}
