using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IceButt
{
    public class notifyGizmo
    {
        public static void ballonNotif(string body, string title, ToolTipIcon icon, Control ctrlToBeShownOn, Form parentFrm, int duration = 3000)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            // Balloon style
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = icon;
            tooltip.ToolTipTitle = title;
            Point screenPos = ctrlToBeShownOn.PointToScreen(new Point(ctrlToBeShownOn.Width / 2, 0));
            tooltip.Show(body, parentFrm, parentFrm.PointToClient(screenPos).X, parentFrm.PointToClient(screenPos).Y - 40, duration);
        }
    }
}
