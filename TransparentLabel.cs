using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Updater_V2 {
    public class NewLabel : Label {
        protected override void OnPaint(PaintEventArgs e) {
            Rectangle rc = this.ClientRectangle;
            StringFormat fmt = new StringFormat(StringFormat.GenericTypographic);
            using (var br = new SolidBrush(this.ForeColor)) {
                e.Graphics.DrawString(this.Text, this.Font, br, rc, fmt);
            }
        }
    }
}
