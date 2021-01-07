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

namespace ImgViewer.WinForm
{
    public partial class Form1
    {
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
                    break;
                case MouseButtons.Right:
                    Text = nameof(MouseButtons.Right); // ※
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
        }
        void InitializePictureBox()
        {
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.DragEnter += PictureBox_DragEnter;
            _pictureBox.DragDrop += PictureBox_DragDrop;

            Controls.Add(_pictureBox);
        }
    }
}