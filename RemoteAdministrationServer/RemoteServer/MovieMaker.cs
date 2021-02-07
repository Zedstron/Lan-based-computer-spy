using AviFile;
using System;
using System.Collections.Generic;
using System.Drawing;

public class MovieMaker
{
    int width;
    int height;
    int framRate;

    public MovieMaker(int width = 640, int height = 480, int framRate = 200)
    {
        this.width = width;
        this.height = height;
        this.framRate = framRate;
    }

    private Bitmap ReduceBitmap(Bitmap original, int reducedWidth, int reducedHeight)
    {
        var reduced = new Bitmap(reducedWidth, reducedHeight);
        using (var dc = Graphics.FromImage(reduced))
        {
            dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            dc.DrawImage(original, new Rectangle(0, 0, reducedWidth, reducedHeight), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
        }

        return reduced;
    }


    public void CreateMovie(List<Bitmap> imageEntities)
    {
        AviManager aviManager = new AviManager(Environment.CurrentDirectory + "\\Vedios\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".avi", false);
        VideoStream aviStream = aviManager.AddVideoStream(true, 2, new Bitmap(width, height));

        Bitmap bitmap;
        foreach (var imageEntity in imageEntities)
        {
            bitmap = ReduceBitmap(imageEntity, width, height);
            aviStream.AddFrame(bitmap);
            bitmap.Dispose();
        }

        aviManager.Close();
    }
}