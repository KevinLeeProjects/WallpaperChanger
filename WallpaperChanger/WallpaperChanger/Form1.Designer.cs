using System.Collections.Generic;
using System.Runtime.InteropServices;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace WallpaperChanger
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 

        private Button changeWallpaperButton;


        //Windows stuff so program has access to change wallpaper
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 0x0014;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDCHANGE = 0x02;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            this.changeWallpaperButton = new Button();
            this.changeWallpaperButton.Text = "Change Wallpaper";
            this.changeWallpaperButton.Location = new System.Drawing.Point(20, 180);
            this.changeWallpaperButton.Click += new EventHandler(this.changeWallpaperButton_Click);

            this.Controls.Add(this.changeWallpaperButton);
        }

        private void changeWallpaperButton_Click(object sender, EventArgs e)
        {

            string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "IMG_5598.png");

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        #endregion
    }
}
