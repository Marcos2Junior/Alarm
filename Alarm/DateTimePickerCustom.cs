using System.Drawing;
using System.Windows.Forms;

namespace Alarm
{
    public class DateTimePickerCustom : DateTimePicker
    {
        public DateTimePickerCustom()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }
    }
}
