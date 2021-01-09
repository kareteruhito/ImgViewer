using System;

namespace ImgViewer.Models
{
    public class BookMaker
    {
        public static Book Create(string path)
        {
            if (System.IO.File.Exists(path))
            {
                if(Strage.IsZipFile(path))
                {
                    return new ZipBook(path);
                }
                else if (Strage.IsPictureFile(path))
                {
                    return new Book(path);
                }
                else
                {
                    var dir = System.IO.Path.GetDirectoryName(path);
                    return new Book(path);
                }
            }
            else if (System.IO.Directory.Exists(path))
            {
                return new Book(path);
            }
            else
            {
                throw new System.IO.FileNotFoundException(path);
            }
        }
    }
}