using System.Drawing;

namespace ImgViewer.Models
{
    class Graphic
    {
        public static Bitmap JoinBitmap(Bitmap l, Bitmap r)
        {
            int w = l.Width + r.Width;
            int h = (l.Height > r.Height) ? l.Height : r.Height;

            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(
                    l,
                    new Rectangle(0, 0, l.Width, l.Height),
                    new Rectangle(0, 0, l.Width, l.Height),
                    GraphicsUnit.Pixel
                );
                g.DrawImage(
                    r,
                    new Rectangle(l.Width, 0, r.Width, r.Height),
                    new Rectangle(0, 0, r.Width, r.Height),
                    GraphicsUnit.Pixel
                );
            }

            return bmp;
        }
        public static Bitmap GetSquareBitmap(Bitmap s, int y = 0)
        {

            var bmp = new Bitmap(s.Width, s.Width);
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(
                    s,
                    new Rectangle(0, 0, s.Width, s.Width),
                    new Rectangle(0, y, s.Width, s.Width),
                    GraphicsUnit.Pixel
                );
            }

            return bmp;
        }
        public static int NextSquareBitmap(Bitmap s, int y)
        {
            int yy = y + s.Width;

            if ((yy+s.Width) <= s.Height) return yy;

            return s.Height - s.Width;
        }
        public static bool IsTailSquareBitmap(Bitmap s, int y)
        {
            if (s.Width >= s.Height) return true;
            
            return s.Height == s.Width + y;
        }
    }
}