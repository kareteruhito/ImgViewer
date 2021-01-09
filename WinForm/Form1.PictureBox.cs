using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImgViewer.Models;

namespace ImgViewer.WinForm
{
    public partial class Form1
    {
        IBook _book = new BookShelf();

        PictureBox _pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.AliceBlue,
            AllowDrop = true,
        };

        void PictureBox_MouseDown(Object o, MouseEventArgs e)
        {
            _pictureBox.Focus();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Text = nameof(MouseButtons.Left); // ※
                    if (_book.MoveNext())
                    {
                        _pictureBox.Image.Dispose();
                        _pictureBox.Image = _book.GetPage();
                    }
                    break;
                case MouseButtons.Right:
                    Text = nameof(MouseButtons.Right); // ※
                    if (_book.MovePrevious())
                    {
                        _pictureBox.Image.Dispose();
                        _pictureBox.Image = _book.GetPage();
                    }
                    break;
                default:
                    Text = ""; // ※
                    break;
            }
        }
        void PictureBox_DragEnter(Object o, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        void PictureBox_DragDrop(Object o, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
            if (files.Any() == false) return;

            Text = "DD:" + files[0]; // ※
            _book = new BookShelf(files[0]);
            _pictureBox.Image.Dispose();
            _pictureBox.Image = _book.GetPage();            
        }
        void InitializePictureBox()
        {
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.DragEnter += PictureBox_DragEnter;
            _pictureBox.DragDrop += PictureBox_DragDrop;

            Controls.Add(_pictureBox);

            string[] args = Environment.GetCommandLineArgs();
            if (args.Count() > 1)
            {
                _book = new BookShelf(args[1]);
                _pictureBox.Image = _book.GetPage();
            }
            else
            {
                _pictureBox.Image = new Bitmap(1, 1);
            }

        }
    }
}