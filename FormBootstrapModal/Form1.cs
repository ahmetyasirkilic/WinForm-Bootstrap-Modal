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
    public partial class Form1 : RoundedForm
    {
        public Form1() : base("Modal title", "Hata oluştu. Lütfen daha sonra tekrar deneyiniz..")
        {
            InitializeComponent();
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
