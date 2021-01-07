using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        MenuStrip _menuBar = new MenuStrip();

        void InitializeMenuBar()
        {
            ToolStripMenuItem item, subItem;

            item = new ToolStripMenuItem();
            item.Name = "File";
            item.Text = "ファイル";

            subItem = new ToolStripMenuItem();
            subItem.Name = "Open";
            subItem.Text = "開く";
            subItem.Click += (o, e) =>
            {
                const string filterString = "画像ファイル(*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png|ZIPファイル(*.zip)|*.zip|全てのファイル(*.*)|*.*";
                const string titleString = "開くファイルを選択してください。";
                var dialog = new OpenFileDialog
                {
                    Filter = filterString,
                    Title = titleString,
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Text = "Open:" + dialog.FileName; // ※
                }
            };
            item.DropDownItems.Add(subItem);
            
            subItem = new ToolStripMenuItem();
            subItem.Name = "Close";
            subItem.Text = "閉じる";
            subItem.Click += (o, e) => this.Close();
            item.DropDownItems.Add(subItem);


            _menuBar.Items.Add(item);

            Controls.Add(_menuBar);
        }
    }
}