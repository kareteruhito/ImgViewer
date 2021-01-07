using System;
using System.Collections;
using System.Linq;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImgViewer.Models
{
    public class Strage
    {
        public static List<string> GetEntriesFromDir(string dir)
        {
            return Directory.EnumerateFiles(dir)
                .Where(x => IsPictureFile(x))
                .OrderBy(x => x)
                .ToList<string>();
        }

        public static Bitmap LoadBitmapFromDir(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return new Bitmap(fs);
            }
        }

        public static bool IsPictureFile(string path)
        {
            const string pattern = @"\.(png|jp(e)?g|bmp|gif)$";

            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
        }
        public static bool IsZipFile(string path)
        {
            const string pattern = @"\.(zip)$";

            return Regex.IsMatch(path, pattern, RegexOptions.IgnoreCase);
        }

        public static List<string> GetEntriesFromZip(string zipFile)
        {
            using(var zip = ZipFile.OpenRead(zipFile))
            {
                return zip.Entries
                    .Where(x => IsPictureFile(x.FullName))
                    .Select(x => x.FullName)
                    .OrderBy(x => x)
                    .ToList<string>();
            }
        }

        public static Bitmap LoadBitmapFromZip(string zipFile, string fileName)
        {
            using(var zip = ZipFile.OpenRead(zipFile))
            {
                var entry = zip.GetEntry(fileName);
                using (var fs = entry.Open())
                {
                    return new Bitmap(fs);
                }
            }
        }
    }
}

