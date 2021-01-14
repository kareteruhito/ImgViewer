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

using Models;

namespace WinForm
{
    public partial class Form1
    {
        PictureBox _pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.AliceBlue,
            AllowDrop = true,
            SizeMode = PictureBoxSizeMode.Zoom,
        };

        BookShelf _bookShelf = new BookShelf();

        void PictureBox_MouseDown(Object o, MouseEventArgs e)
        {
            _pictureBox.Focus();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Text = nameof(MouseButtons.Left); // ※
                    if (_bookShelf.Any() == false) return;

                    var book = _bookShelf.GetBook();
                    if (book.Any() == false) return;

                    if (_bookShelf.IsLast && book.IsLast) return;

                    if (book.IsLast)
                    {
                        if (_bookShelf.MoveNext())
                        {
                            book = _bookShelf.GetBook();
                            if (_pictureBox.Image != null)
                            {
                                _pictureBox.Image.Dispose();
                                _pictureBox.Image = null;
                            }
                            _pictureBox.Image = book.Page;
                        }
                        return;
                    }

                    if(book.MoveNext())
                    {
                        if (_pictureBox.Image != null)
                        {
                            _pictureBox.Image.Dispose();
                            _pictureBox.Image = null;
                        }
                        _pictureBox.Image = book.Page;
                    }
                    break;
                case MouseButtons.Right:
                    Text = nameof(MouseButtons.Right); // ※
                    if (_bookShelf.Any() == false) return;

                    book = _bookShelf.GetBook();
                    if (book.Any() == false) return;

                    if (_bookShelf.IsFirst && book.IsFirst) return;

                    if (book.IsFirst)
                    {
                        if (_bookShelf.MovePrevious())
                        {
                            book = _bookShelf.GetBook();
                            book.MoveLast();
                            
                            if (_pictureBox.Image != null)
                            {
                                _pictureBox.Image.Dispose();
                                _pictureBox.Image = null;
                            }
                            _pictureBox.Image = book.Page;
                        }
                        return;
                    }

                    if(book.MovePrevious())
                    {
                        if (_pictureBox.Image != null)
                        {
                            _pictureBox.Image.Dispose();
                            _pictureBox.Image = null;
                        }
                        _pictureBox.Image = book.Page;
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
            _bookShelf = new BookShelf(files[0]);
            if (_bookShelf.Any() == false) return;

            var book = _bookShelf.GetBook();
            if (book.Any() == false) return;

            if (_pictureBox.Image != null)
            {
                _pictureBox.Image.Dispose();
                _pictureBox.Image = null;
            }
            _pictureBox.Image = book.Page;
        }
        
        void SetCanvas(Bitmap canvas)
        {
            _pictureBox.Image = canvas;
        }
        void InitializePictureBox()
        {
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.DragEnter += PictureBox_DragEnter;
            _pictureBox.DragDrop += PictureBox_DragDrop;

            Controls.Add(_pictureBox);

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                _pictureBox.Image = new Bitmap(1, 1);
            }
            else
            {
                _pictureBox.Image = new Bitmap(1, 1);
            }

        }
    }
}