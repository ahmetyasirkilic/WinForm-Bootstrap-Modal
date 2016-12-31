using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBootstrapModal
{
    public class RoundedForm : Form
    {
        #region DLL
        public const int WM_NCL_BUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private const int CORNER_ROUND = 10;
        public Color StrokeColor
        {
            get
            {
                return Color.FromArgb(188, 188, 188);
            }
        }
        public Color LineColor
        {
            get
            {
                return Color.FromArgb(245, 245, 245);
            }
        }

        public RoundedForm(string title, string body)
        {
            base.Size = new Size(500,138);
            AddControls(title, body);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            #region FormShape
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(
                new Rectangle(0, 0, CORNER_ROUND, CORNER_ROUND),
                180,
                90
                );
            gp.AddArc(
                new Rectangle(this.Width - CORNER_ROUND, 0, CORNER_ROUND, CORNER_ROUND),
                270, 
                90
                );

            gp.AddRectangle(
                new Rectangle(0, CORNER_ROUND / 2, this.Width, this.Height - CORNER_ROUND)
                );

            gp.AddArc( 
                new Rectangle(0, this.Height - CORNER_ROUND, CORNER_ROUND, CORNER_ROUND),
                -270,
                90
                );
            gp.AddArc( 
                new Rectangle(this.Width - CORNER_ROUND, this.Height - CORNER_ROUND, CORNER_ROUND, CORNER_ROUND),
                360,
                90
                );

            Region = new Region(gp);
            #endregion

            Graphics g = this.CreateGraphics();

            #region Lines
            SolidBrush lineBrush = new SolidBrush(LineColor);
            Pen pen = new Pen(lineBrush, 1f);
            g.DrawLine(
                pen, new Point(0, Height / 3), 
                new Point(Width, Height / 3)
                );
            g.DrawLine(
                pen, new Point(0, Height / 3 * 2),
                new Point(Width, Height / 3 * 2)
                ); 
            #endregion

            #region BorderStroke
            SolidBrush strokeBrush = new SolidBrush(StrokeColor);
            pen.Brush = strokeBrush;
            pen.Width = 4f;
           
            g.DrawArc(pen, new Rectangle(0, 0, CORNER_ROUND, CORNER_ROUND), 180, 90);
            g.DrawArc(pen, new Rectangle(this.Width - CORNER_ROUND, 0, CORNER_ROUND, CORNER_ROUND), 270, 90);

            g.DrawRectangle(pen, new Rectangle(0, 0, this.Width, this.Height));

            g.DrawArc(pen, new Rectangle(0, this.Height - CORNER_ROUND, CORNER_ROUND, CORNER_ROUND), -270, 90);
            g.DrawArc(pen, new Rectangle(this.Width - CORNER_ROUND, this.Height - CORNER_ROUND, CORNER_ROUND, CORNER_ROUND), 360, 90);
            #endregion

            g.Dispose();
        }

        private void AddControls(string title, string body)
        {
            ModalLabel titleLabel = new ModalLabel(ModalLabelType.Title, title);
            titleLabel.Location = new Point(10, Height / 12);
            ModalLabel bodyLabel = new ModalLabel(ModalLabelType.Body, body);
            bodyLabel.Location = new Point(10, (int)(Height / 2.5)); 
            ModalLabel closeLabel = new ModalLabel(ModalLabelType.Title, "x");
            closeLabel.Location = new Point(Width - 30, (Height / 3) / 6);
           
            closeLabel.Cursor = Cursors.Hand;
            closeLabel.Click += CloseLabel_Click;

            Controls.Add(closeLabel);
            Controls.Add(titleLabel);
            Controls.Add(bodyLabel);
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
