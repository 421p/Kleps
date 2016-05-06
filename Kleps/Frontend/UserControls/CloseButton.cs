using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kleps.Frontend.UserControls {
    public partial class CloseButton : UserControl {
        public CloseButton() {
            InitializeComponent();
        }

        private void EnterMouse(object sender, EventArgs e) {
            this.BackgroundImage = Kleps.Properties.Resources.close_hover;
        }

        private void DownMouse(object sender, MouseEventArgs e) {
            this.BackgroundImage = Kleps.Properties.Resources.close_down;
        }

        private void RevertMouse(object sender, EventArgs e) {
            this.BackgroundImage = Kleps.Properties.Resources.close;
        }
    }
}
