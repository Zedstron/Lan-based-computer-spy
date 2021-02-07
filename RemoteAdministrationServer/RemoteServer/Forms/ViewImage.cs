using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteServer
{
    public partial class ViewImage : Form
    {
        public ViewImage(Image img)
        {
            InitializeComponent();
            BackgroundImage = img;
        }

        private void ViewImage_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ViewImage";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.ViewImage_Load);
            this.ResumeLayout(false);

        }
    }
}
