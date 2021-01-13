using System.IO;

namespace Models
{
    public class BookMaker
    {
        public static Book Create(string path)
        {
            Book book;

            if (Directory.Exists(path))
            {
                book = new Book(path);
            }
            else if (Storage.IsZipFile(path))
            {
                book = new ZipBook(path);
            }
            else
            {
                var dir = Path.GetDirectoryName(path);
                book = new Book(dir);

                if (Storage.IsPictureFile(path))
                {
                    book.MoveAt(path);
                }
            }

            return book;
        }
    }
}