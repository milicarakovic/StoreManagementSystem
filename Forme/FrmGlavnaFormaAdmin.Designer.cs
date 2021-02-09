namespace Forme
{
    partial class FrmGlavnaFormaAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGlavnaFormaAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreirajNovogKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreirajProzivodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obrisiProizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izmeniProizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.proizvodiToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreirajNovogKorisnikaToolStripMenuItem});
            resources.ApplyResources(this.korisniciToolStripMenuItem, "korisniciToolStripMenuItem");
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            // 
            // kreirajNovogKorisnikaToolStripMenuItem
            // 
            this.kreirajNovogKorisnikaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.kreirajNovogKorisnikaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.kreirajNovogKorisnikaToolStripMenuItem.Name = "kreirajNovogKorisnikaToolStripMenuItem";
            resources.ApplyResources(this.kreirajNovogKorisnikaToolStripMenuItem, "kreirajNovogKorisnikaToolStripMenuItem");
            this.kreirajNovogKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.kreirajNovogKorisnikaToolStripMenuItem_Click);
            // 
            // proizvodiToolStripMenuItem
            // 
            this.proizvodiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kreirajProzivodToolStripMenuItem,
            this.obrisiProizvodToolStripMenuItem,
            this.izmeniProizvodToolStripMenuItem});
            resources.ApplyResources(this.proizvodiToolStripMenuItem, "proizvodiToolStripMenuItem");
            this.proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            // 
            // kreirajProzivodToolStripMenuItem
            // 
            this.kreirajProzivodToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.kreirajProzivodToolStripMenuItem.Name = "kreirajProzivodToolStripMenuItem";
            resources.ApplyResources(this.kreirajProzivodToolStripMenuItem, "kreirajProzivodToolStripMenuItem");
            this.kreirajProzivodToolStripMenuItem.Click += new System.EventHandler(this.kreirajProzivodToolStripMenuItem_Click);
            // 
            // obrisiProizvodToolStripMenuItem
            // 
            this.obrisiProizvodToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.obrisiProizvodToolStripMenuItem.Name = "obrisiProizvodToolStripMenuItem";
            resources.ApplyResources(this.obrisiProizvodToolStripMenuItem, "obrisiProizvodToolStripMenuItem");
            this.obrisiProizvodToolStripMenuItem.Click += new System.EventHandler(this.obrisiProizvodToolStripMenuItem_Click);
            // 
            // izmeniProizvodToolStripMenuItem
            // 
            this.izmeniProizvodToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.izmeniProizvodToolStripMenuItem.Name = "izmeniProizvodToolStripMenuItem";
            resources.ApplyResources(this.izmeniProizvodToolStripMenuItem, "izmeniProizvodToolStripMenuItem");
            this.izmeniProizvodToolStripMenuItem.Click += new System.EventHandler(this.izmeniProizvodToolStripMenuItem_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmGlavnaFormaAdmin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmGlavnaFormaAdmin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kreirajNovogKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreirajProzivodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obrisiProizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izmeniProizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}