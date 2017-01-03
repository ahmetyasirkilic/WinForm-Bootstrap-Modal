using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBootstrapModal
{
    public partial class Form1 : ModalForm.ModalForm
    {
        public Form1() : base("Modal title", "One fine body...")
        {
            InitializeComponent();
            
        }
    }
}
