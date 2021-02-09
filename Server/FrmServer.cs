using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server s;
        public FrmServer()
        {
            InitializeComponent();
            btnPokreni.Enabled = true;
            btnZaustavi.Enabled = false;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            s = new Server();
            if (s.PokreniServer())
            {
                Thread nit = new Thread(s.Osluskuj);
                nit.IsBackground = true;
                nit.Start();
                MessageBox.Show("Server je pokrenut.");
                btnPokreni.Enabled = false;
                btnZaustavi.Enabled = true;
            }
            else MessageBox.Show("Server nije pokrenut.");

        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            if (s.ZaustaviServer())
            {
                MessageBox.Show("Server je zaustavljen.");
                btnPokreni.Enabled = true;
                btnZaustavi.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nije moguce zaustaviti server.");
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
