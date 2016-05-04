using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kleps.Frontend {
    public partial class SplashScreen : Form {
        public SplashScreen() {
            InitializeComponent();
            this.BackColor = Color.Black;

            var ScreenWidth = SystemInformation.VirtualScreen.Width;
            var ScreenHeigh = SystemInformation.VirtualScreen.Height;

            LoaderBox.Size = new Size(ScreenWidth - ScreenWidth / 2, ScreenHeigh - ScreenHeigh / 2);
            LoaderBox.Location = new Point((ScreenWidth - LoaderBox.Width)/2, (ScreenHeigh - LoaderBox.Height) / 2);
            LoaderBox.Padding = new Padding(0);
            LoaderBox.Margin = new Padding(0);
            LoaderBox.Image = Kleps.Properties.Resources.Loader;
        }
    }
}
