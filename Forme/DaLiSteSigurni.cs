using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class DaLiSteSigurni : Form
    {
        public bool siguran { get; set; }

        public DaLiSteSigurni()
        {
            InitializeComponent();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            siguran = true;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siguran = false;
            Close();
        }
    }
}
