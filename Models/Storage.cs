using System;
using System.Collections;
using System.Linq;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Models
{
    public class Storage
    {

        static Dictionary<string, Bitmap> _cache = new Dictionary<string, Bitmap>();
        public static Bitmap LoadBitmap(string fileName, string zipFile = "")
        {
            var key = fileName;
            if (zipFile != "")
            {
                key = System.IO.Path.Join(zipFile, fileName);
            }

            if (_cache.ContainsKey(key) == false)
            {
                if (zipFile == "")
                {
                    _cache[key] = LoadBitmapFromDir(fileName);
                }
                else
                {
                    _cache[key] = LoadBitmapFromZip(zipFile, fileName);
                }
            }
            
            return _cache[key];
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

        public static List<string> GetEntriesFromDir(string dir)
        {

            var files = Directory.EnumerateFiles(dir)
                .Where(x => IsPictureFile(x))
                .OrderBy(x => Path.GetFileNameWithoutExtension(x))
                .ToList<string>();
            
            Task.Run(()=>{
                foreach(var fileName in files)
                {
                    if (_cache.ContainsKey(fileName) == false)
                    {
                        _cache[fileName] = LoadBitmapFromDir(fileName);
                    }
                }
            });
            
            return files;
        }

        public static List<string> GetEntriesFromZip(string zipFile)
        {
            List<string> files;

            using(var zip = ZipFile.OpenRead(zipFile))
            {
                files = zip.Entries
                    .Where(x => IsPictureFile(x.FullName))
                    .Select(x => x.FullName)
                    .OrderBy(x => Path.GetFileNameWithoutExtension(x))
                    .ToList<string>();
            }

            Task.Run(()=>{
                foreach(var fileName in files)
                {
                    var key = System.IO.Path.Join(zipFile, fileName);
                    if (_cache.ContainsKey(key) == false)
                    {
                        _cache[key] = LoadBitmapFromZip(zipFile, fileName);
                    }
                }
            });

            return files;
        }

        public static List<string> GetBookEntries(string dir)
        {
            List<string> result = new List<string>();

            if (GetEntriesFromDir(dir).Any())
            {
                result.Add(dir);
            }
            
            var r = Directory.EnumerateFileSystemEntries(dir)
                .Where(x => (Directory.Exists(x) && GetEntriesFromDir(x).Any()))
                .OrderBy(x => Path.GetFileNameWithoutExtension(x))
                .ToList<string>();
            result.AddRange(r);

            r = Directory.EnumerateFileSystemEntries(dir)
                .Where(x => (IsZipFile(x) && GetEntriesFromZip(x).Any()))
                .OrderBy(x => Path.GetFileNameWithoutExtension(x))
                .ToList<string>();
            result.AddRange(r);

            /*
            var r = Directory.EnumerateFileSystemEntries(dir)
                .Where(x => (IsZipFile(x) && GetEntriesFromZip(x).Any()) || (Directory.Exists(x) && GetEntriesFromDir(x).Any()))
                .OrderBy(x => Path.GetFileNameWithoutExtension(x))
                .ToList<string>();
            result.AddRange(r);
            */
            
            return result;
        }
    }
}

