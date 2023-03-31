using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AkbilYonetimIsKatmani;
using AkbilYonetimVeriKatmani;
using AkbilYonetimVeriKatmani.Models;

namespace AkbilYonetim
{
    public partial class FrmAkbiller : Form
    {
        AkbildbContext context = new AkbildbContext();

        public FrmAkbiller()
        {
            InitializeComponent();
        }


        private void FrmAkbiller_Load(object sender, EventArgs e)
        {
            cmbAkbilTipleri.Text = "Akbil tipi seçiniz...";
            cmbAkbilTipleri.SelectedIndex = -1;
            DataGridViewiDoldur();
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAkbilTipleri.SelectedIndex < 0)
                {
                    MessageBox.Show("Lütfen eklemek istediğiniz akbil türünü seçiniz ! ");
                    return;
                }
                if (maskTxtAkbilNo.Text.Length < 16)
                {
                    MessageBox.Show("Akbil No 16 haneli olmalıdır !");
                    return;
                }
                Akbiller yeniAkbil = new Akbiller()
                {
                    EklenmeTarihi = DateTime.Now,
                    AkbilNo = maskTxtAkbilNo.Text,
                    AkbilSahibiId = GenelIslemler.GirisYapanKullaniciId,
                    AkbilTipi = cmbAkbilTipleri.SelectedItem.ToString(),
                    Bakiye = 0,
                    VizelendigiTarih = null
                };
                context.Akbillers.Add(yeniAkbil);
                int sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    MessageBox.Show("Yeni akbil eklendi");
                    //temizlik
                    maskTxtAkbilNo.Clear();
                    cmbAkbilTipleri.Text = "Akbil seçiniz...";
                    cmbAkbilTipleri.SelectedIndex = -1;

                    DataGridViewiDoldur();
                }
                else
                {
                    MessageBox.Show("Yeni akbil EKLENEMEDİ");
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu !" + hata.Message);
            }
        }

        private void DataGridViewiDoldur()
        {
            try
            {
                dataGridViewAkbiller.DataSource = context.Akbillers.Where(x => x.AkbilSahibiId == GenelIslemler.GirisYapanKullaniciId).ToList();

                // Bazı kolonlar gizlensin
                dataGridViewAkbiller.Columns["AkbilSahibiId"].Visible = false;
                dataGridViewAkbiller.Columns["VizelendigiTarih"].HeaderText = "Vizelendiği Tarih";
                dataGridViewAkbiller.Columns["VizelendigiTarih"].Width = 200;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Akbilleri listeleyemedim !" + hata.Message);
            }
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
            frmAnaSayfa.Show();
        }

        private void cikisYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Güle Güle Çıkış Yapıldı");
            GenelIslemler.GirisYapanKullaniciAdSoyad = string.Empty;
            GenelIslemler.GirisYapanKullaniciId = 0;

            FrmGiris frmGiris = new FrmGiris();
            foreach (Form item in Application.OpenForms)
            {
                item.Hide();
            }
            frmGiris.Show();
        }
    }
}
