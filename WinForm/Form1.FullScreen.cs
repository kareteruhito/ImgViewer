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
        void InitializeFullScreen()
        {
            KeyDown += (o, e) =>
            {
                switch(e.KeyCode)
                {
                    case Keys.F11:
                        if (FormBorderStyle == FormBorderStyle.None)
                        {
                            FormBorderStyle = FormBorderStyle.Sizable;
                            WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            FormBorderStyle = FormBorderStyle.None;
                            WindowState = FormWindowState.Maximized;
                        }
                        HideMenu();
                        break;
                }
            };
            
            KeyPreview = true;
        }
    }
}