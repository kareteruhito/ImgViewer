using System;
using System.Drawing;
using System.IO;

namespace ImgViewer.Models
{
    public class Strage
    {
        public static Bitmap LoadBitmapFromLocal(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return new Bitmap(fs);
            }
        }
    }
}

