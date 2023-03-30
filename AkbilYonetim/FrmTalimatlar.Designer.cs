namespace AkbilYonetim
{
    partial class FrmTalimatlar
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
            this.components = new System.ComponentModel.Container();
            this.cikisYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anaSayfaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cmbAkbiller = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYuklenecekTutar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBekleyenTalimat = new System.Windows.Forms.Label();
            this.chboxTumunuGoster = new System.Windows.Forms.CheckBox();
            this.btnTalimat = new System.Windows.Forms.Button();
            this.dataGridViewTalimatlar = new System.Windows.Forms.DataGridView();
            this.cmsTalimatKontrol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.talimatiYukleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.talimatiIptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerBekleyenTalimat = new System.Windows.Forms.Timer(this.components);
            this.grpBoxYukleme = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTalimatlar)).BeginInit();
            this.cmsTalimatKontrol.SuspendLayout();
            this.grpBoxYukleme.SuspendLayout();
            this.SuspendLayout();
            // 
            // cikisYapToolStripMenuItem
            // 
            this.cikisYapToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cikisYapToolStripMenuItem.Name = "cikisYapToolStripMenuItem";
            this.cikisYapToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.cikisYapToolStripMenuItem.Text = "ÇIKIŞ YAP";
            this.cikisYapToolStripMenuItem.Click += new System.EventHandler(this.cikisYapToolStripMenuItem_Click);
            // 
            // anaSayfaToolStripMenuItem
            // 
            this.anaSayfaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.anaSayfaToolStripMenuItem.Name = "anaSayfaToolStripMenuItem";
            this.anaSayfaToolStripMenuItem.Size = new System.Drawing.Size(90, 21);
            this.anaSayfaToolStripMenuItem.Text = "ANA SAYFA";
            this.anaSayfaToolStripMenuItem.Click += new System.EventHandler(this.anaSayfaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaSayfaToolStripMenuItem,
            this.cikisYapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(786, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cmbAkbiller
            // 
            this.cmbAkbiller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAkbiller.FormattingEnabled = true;
            this.cmbAkbiller.Location = new System.Drawing.Point(27, 62);
            this.cmbAkbiller.Name = "cmbAkbiller";
            this.cmbAkbiller.Size = new System.Drawing.Size(312, 25);
            this.cmbAkbiller.TabIndex = 2;
            this.cmbAkbiller.SelectedIndexChanged += new System.EventHandler(this.cmbAkbiller_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yüklenecek Tutar :";
            // 
            // txtYuklenecekTutar
            // 
            this.txtYuklenecekTutar.Location = new System.Drawing.Point(129, 27);
            this.txtYuklenecekTutar.Name = "txtYuklenecekTutar";
            this.txtYuklenecekTutar.Size = new System.Drawing.Size(183, 25);
            this.txtYuklenecekTutar.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(400, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bekleyen Talimat :";
            // 
            // lblBekleyenTalimat
            // 
            this.lblBekleyenTalimat.AutoSize = true;
            this.lblBekleyenTalimat.BackColor = System.Drawing.Color.Transparent;
            this.lblBekleyenTalimat.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBekleyenTalimat.ForeColor = System.Drawing.Color.Navy;
            this.lblBekleyenTalimat.Location = new System.Drawing.Point(596, 144);
            this.lblBekleyenTalimat.Name = "lblBekleyenTalimat";
            this.lblBekleyenTalimat.Size = new System.Drawing.Size(25, 30);
            this.lblBekleyenTalimat.TabIndex = 6;
            this.lblBekleyenTalimat.Text = "0";
            // 
            // chboxTumunuGoster
            // 
            this.chboxTumunuGoster.AutoSize = true;
            this.chboxTumunuGoster.BackColor = System.Drawing.Color.White;
            this.chboxTumunuGoster.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chboxTumunuGoster.Location = new System.Drawing.Point(27, 260);
            this.chboxTumunuGoster.Name = "chboxTumunuGoster";
            this.chboxTumunuGoster.Size = new System.Drawing.Size(122, 21);
            this.chboxTumunuGoster.TabIndex = 7;
            this.chboxTumunuGoster.Text = "Tümünü Göster";
            this.chboxTumunuGoster.UseVisualStyleBackColor = false;
            this.chboxTumunuGoster.CheckedChanged += new System.EventHandler(this.chboxTumunuGoster_CheckedChanged);
            // 
            // btnTalimat
            // 
            this.btnTalimat.BackColor = System.Drawing.Color.White;
            this.btnTalimat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTalimat.Location = new System.Drawing.Point(129, 76);
            this.btnTalimat.Name = "btnTalimat";
            this.btnTalimat.Size = new System.Drawing.Size(184, 49);
            this.btnTalimat.TabIndex = 8;
            this.btnTalimat.Text = "TALİMAT EKLE";
            this.btnTalimat.UseVisualStyleBackColor = false;
            this.btnTalimat.Click += new System.EventHandler(this.btnTalimat_Click);
            // 
            // dataGridViewTalimatlar
            // 
            this.dataGridViewTalimatlar.AllowUserToAddRows = false;
            this.dataGridViewTalimatlar.AllowUserToDeleteRows = false;
            this.dataGridViewTalimatlar.AllowUserToOrderColumns = true;
            this.dataGridViewTalimatlar.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTalimatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTalimatlar.ContextMenuStrip = this.cmsTalimatKontrol;
            this.dataGridViewTalimatlar.Location = new System.Drawing.Point(27, 287);
            this.dataGridViewTalimatlar.Name = "dataGridViewTalimatlar";
            this.dataGridViewTalimatlar.ReadOnly = true;
            this.dataGridViewTalimatlar.RowTemplate.Height = 25;
            this.dataGridViewTalimatlar.Size = new System.Drawing.Size(747, 153);
            this.dataGridViewTalimatlar.TabIndex = 9;
            // 
            // cmsTalimatKontrol
            // 
            this.cmsTalimatKontrol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.talimatiYukleToolStripMenuItem,
            this.talimatiIptalEtToolStripMenuItem});
            this.cmsTalimatKontrol.Name = "cmStrip1";
            this.cmsTalimatKontrol.Size = new System.Drawing.Size(181, 70);
            // 
            // talimatiYukleToolStripMenuItem
            // 
            this.talimatiYukleToolStripMenuItem.Name = "talimatiYukleToolStripMenuItem";
            this.talimatiYukleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.talimatiYukleToolStripMenuItem.Text = "Talimatı Yükle";
            this.talimatiYukleToolStripMenuItem.Click += new System.EventHandler(this.talimatiYukleToolStripMenuItem_Click);
            // 
            // talimatiIptalEtToolStripMenuItem
            // 
            this.talimatiIptalEtToolStripMenuItem.Name = "talimatiIptalEtToolStripMenuItem";
            this.talimatiIptalEtToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.talimatiIptalEtToolStripMenuItem.Text = "Talimatı İptal Et";
            this.talimatiIptalEtToolStripMenuItem.Click += new System.EventHandler(this.talimatiIptalEtToolStripMenuItem_Click);
            // 
            // timerBekleyenTalimat
            // 
            this.timerBekleyenTalimat.Tick += new System.EventHandler(this.timerBekleyenTalimat_Tick);
            // 
            // grpBoxYukleme
            // 
            this.grpBoxYukleme.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxYukleme.Controls.Add(this.label1);
            this.grpBoxYukleme.Controls.Add(this.txtYuklenecekTutar);
            this.grpBoxYukleme.Controls.Add(this.btnTalimat);
            this.grpBoxYukleme.Location = new System.Drawing.Point(27, 105);
            this.grpBoxYukleme.Name = "grpBoxYukleme";
            this.grpBoxYukleme.Size = new System.Drawing.Size(318, 145);
            this.grpBoxYukleme.TabIndex = 11;
            this.grpBoxYukleme.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Akbil Seçiniz";
            // 
            // FrmTalimatlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AkbilYonetim.Properties.Resources.TalimatBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(786, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpBoxYukleme);
            this.Controls.Add(this.chboxTumunuGoster);
            this.Controls.Add(this.dataGridViewTalimatlar);
            this.Controls.Add(this.lblBekleyenTalimat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAkbiller);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "FrmTalimatlar";
            this.Text = "FrmTalimatlar";
            this.Load += new System.EventHandler(this.FrmTalimatlar_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTalimatlar)).EndInit();
            this.cmsTalimatKontrol.ResumeLayout(false);
            this.grpBoxYukleme.ResumeLayout(false);
            this.grpBoxYukleme.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem cikisYapToolStripMenuItem;
        private ToolStripMenuItem anaSayfaToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ComboBox cmbAkbiller;
        private Label label1;
        private TextBox txtYuklenecekTutar;
        private Label label2;
        private Label lblBekleyenTalimat;
        private CheckBox chboxTumunuGoster;
        private Button btnTalimat;
        private DataGridView dataGridViewTalimatlar;
        private System.Windows.Forms.Timer timerBekleyenTalimat;
        private ContextMenuStrip cmsTalimatKontrol;
        private GroupBox grpBoxYukleme;
        private Label label3;
        private ToolStripMenuItem talimatiYukleToolStripMenuItem;
        private ToolStripMenuItem talimatiIptalEtToolStripMenuItem;
    }
}