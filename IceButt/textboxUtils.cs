using System.Drawing;
using System.Windows.Forms;

namespace IceButt
{
    public class textboxUtils
    {
        public static void checkForNumber(TextBox txtBox,Form parentFrm, KeyPressEventArgs e, bool showMsg = true)//put this in keypress event
        {
            ToolTip tooltip = new ToolTip();
            // Balloon style
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
            tooltip.ToolTipTitle = "Invalid Input";
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the key
                if (showMsg)
                {
                    Point screenPos = txtBox.PointToScreen(new Point(txtBox.Width / 2, 0));
                    tooltip.Show("Only numbers are allowed.", parentFrm, parentFrm.PointToClient(screenPos).X, parentFrm.PointToClient(screenPos).Y - 40, 3000);
                }              
            }
        }
    }
}
