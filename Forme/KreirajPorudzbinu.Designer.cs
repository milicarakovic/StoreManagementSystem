namespace Forme
{
    partial class KreirajPorudzbinu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnDodajProizvod = new System.Windows.Forms.Button();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.lblDatumPorudzbine = new System.Windows.Forms.Label();
            this.txtRok = new System.Windows.Forms.TextBox();
            this.txtUkupanIznos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRokPrispeca = new System.Windows.Forms.Label();
            this.lblProizvodjac = new System.Windows.Forms.Label();
            this.btnObrisiStavku = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnObrisiStavku);
            this.groupBox1.Controls.Add(this.btnSacuvaj);
            this.groupBox1.Controls.Add(this.btnDodajProizvod);
            this.groupBox1.Controls.Add(this.dgvProizvodi);
            this.groupBox1.Controls.Add(this.lblDatumPorudzbine);
            this.groupBox1.Controls.Add(this.txtRok);
            this.groupBox1.Controls.Add(this.txtUkupanIznos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblRokPrispeca);
            this.groupBox1.Controls.Add(this.lblProizvodjac);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(718, 357);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kreiraj porudžbinu";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnSacuvaj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btnSacuvaj.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F);
            this.btnSacuvaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSacuvaj.Location = new System.Drawing.Point(432, 295);
            this.btnSacuvaj.Margin = new System.Windows.Forms.Padding(4);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(163, 30);
            this.btnSacuvaj.TabIndex = 24;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnDodajProizvod
            // 
            this.btnDodajProizvod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnDodajProizvod.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btnDodajProizvod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDodajProizvod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F);
            this.btnDodajProizvod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnDodajProizvod.Location = new System.Drawing.Point(24, 262);
            this.btnDodajProizvod.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajProizvod.Name = "btnDodajProizvod";
            this.btnDodajProizvod.Size = new System.Drawing.Size(176, 30);
            this.btnDodajProizvod.TabIndex = 23;
            this.btnDodajProizvod.Text = "Dodaj proizvod";
            this.btnDodajProizvod.UseVisualStyleBackColor = true;
            this.btnDodajProizvod.Click += new System.EventHandler(this.btnDodajProizvod_Click);
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProizvodi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProizvodi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvProizvodi.Location = new System.Drawing.Point(24, 74);
            this.dgvProizvodi.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.ReadOnly = true;
            this.dgvProizvodi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvProizvodi.Size = new System.Drawing.Size(672, 180);
            this.dgvProizvodi.TabIndex = 5;
            // 
            // lblDatumPorudzbine
            // 
            this.lblDatumPorudzbine.AutoSize = true;
            this.lblDatumPorudzbine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic);
            this.lblDatumPorudzbine.Location = new System.Drawing.Point(194, 39);
            this.lblDatumPorudzbine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatumPorudzbine.Name = "lblDatumPorudzbine";
            this.lblDatumPorudzbine.Size = new System.Drawing.Size(49, 18);
            this.lblDatumPorudzbine.TabIndex = 22;
            this.lblDatumPorudzbine.Text = "datum";
            // 
            // txtRok
            // 
            this.txtRok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtRok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRok.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtRok.Location = new System.Drawing.Point(532, 30);
            this.txtRok.Margin = new System.Windows.Forms.Padding(4);
            this.txtRok.Name = "txtRok";
            this.txtRok.Size = new System.Drawing.Size(164, 26);
            this.txtRok.TabIndex = 21;
            // 
            // txtUkupanIznos
            // 
            this.txtUkupanIznos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtUkupanIznos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUkupanIznos.Enabled = false;
            this.txtUkupanIznos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUkupanIznos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtUkupanIznos.Location = new System.Drawing.Point(432, 261);
            this.txtUkupanIznos.Margin = new System.Windows.Forms.Padding(4);
            this.txtUkupanIznos.Name = "txtUkupanIznos";
            this.txtUkupanIznos.Size = new System.Drawing.Size(164, 26);
            this.txtUkupanIznos.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(301, 265);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ukupan iznos:";
            // 
            // lblRokPrispeca
            // 
            this.lblRokPrispeca.AutoSize = true;
            this.lblRokPrispeca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblRokPrispeca.Location = new System.Drawing.Point(328, 34);
            this.lblRokPrispeca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRokPrispeca.Name = "lblRokPrispeca";
            this.lblRokPrispeca.Size = new System.Drawing.Size(164, 18);
            this.lblRokPrispeca.TabIndex = 18;
            this.lblRokPrispeca.Text = "Rok prispeća u danima:";
            // 
            // lblProizvodjac
            // 
            this.lblProizvodjac.AutoSize = true;
            this.lblProizvodjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblProizvodjac.Location = new System.Drawing.Point(20, 39);
            this.lblProizvodjac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProizvodjac.Name = "lblProizvodjac";
            this.lblProizvodjac.Size = new System.Drawing.Size(133, 18);
            this.lblProizvodjac.TabIndex = 17;
            this.lblProizvodjac.Text = "Datum porudžbine:";
            // 
            // btnObrisiStavku
            // 
            this.btnObrisiStavku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnObrisiStavku.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiStavku.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnObrisiStavku.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F);
            this.btnObrisiStavku.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnObrisiStavku.Location = new System.Drawing.Point(24, 300);
            this.btnObrisiStavku.Margin = new System.Windows.Forms.Padding(4);
            this.btnObrisiStavku.Name = "btnObrisiStavku";
            this.btnObrisiStavku.Size = new System.Drawing.Size(176, 30);
            this.btnObrisiStavku.TabIndex = 25;
            this.btnObrisiStavku.Text = "Obrisi stavku";
            this.btnObrisiStavku.UseVisualStyleBackColor = true;
            this.btnObrisiStavku.Click += new System.EventHandler(this.btnObrisiStavku_Click);
            // 
            // KreirajPorudzbinu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KreirajPorudzbinu";
            this.Size = new System.Drawing.Size(718, 357);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblProizvodjac;
        private System.Windows.Forms.Label lblDatumPorudzbine;
        private System.Windows.Forms.TextBox txtRok;
        private System.Windows.Forms.TextBox txtUkupanIznos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRokPrispeca;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnDodajProizvod;
        private System.Windows.Forms.Button btnObrisiStavku;
    }
}
