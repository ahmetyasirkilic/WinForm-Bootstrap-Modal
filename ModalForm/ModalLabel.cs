using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBootstrapModal
{
    public class ModalLabel : Label
    {
        private float TITLE_FONT_SIZE = 15f;
        private float BODY_FONT_SIZE = 8f;
        public float TitleFont { get; set; }
        private FontStyle TITLE_FONT_STYLE = FontStyle.Bold;
        private FontStyle BODY_FONT_STYLE = FontStyle.Regular;

        private string FONT_FAMILY = "Helvetica Neue";

        public override Color ForeColor
        {
            get
            {
                return Color.FromArgb(51, 51, 51);
            }
        }
        public ModalLabel(ModalLabelType type, string text)
        {
            switch (type)
            {
                case ModalLabelType.Body:
                    base.Font = new Font(FONT_FAMILY, BODY_FONT_SIZE, BODY_FONT_STYLE);
                    break;
                case ModalLabelType.Title:
                    base.Font = new Font(FONT_FAMILY, TITLE_FONT_SIZE, TITLE_FONT_STYLE);
                    break;
            }

            base.Text = text;
            base.AutoSize = true;
            base.ForeColor = ForeColor;
        }
    }

    public enum ModalLabelType
    {
        Title,
        Body
    }
}
