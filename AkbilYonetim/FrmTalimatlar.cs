using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AkbilYonetimIsKatmani;
using AkbilYonetimIsKatmani;
using AkbilYonetimVeriKatmani.Models;

namespace AkbilYonetim
{
    public partial class FrmTalimatlar : Form
    {
        AkbildbContext context = new AkbildbContext();
        public FrmTalimatlar()
        {
            InitializeComponent();
        }

        private void FrmTalimatlar_Load(object sender, EventArgs e)
        {
            //Comboxa akbilleri getir
            ComboBoxaKullanicininAkbilleriniGetir();
            cmbAkbiller.SelectedIndex = -1;
            grpBoxYukleme.Enabled = false;

            dataGridViewTalimatlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            TalimatlariDataGrideGetir();

            chboxTumunuGoster.Checked = false;
            BekleyenTalimatSayisiniGetir();
            timerBekleyenTalimat.Interval = 1000;
            timerBekleyenTalimat.Enabled = true;
        }

        private void ComboBoxaKullanicininAkbilleriniGetir()
        {
            try
            {
                cmbAkbiller.DataSource = context.Akbillers.Where(x => x.AkbilSahibiId == GenelIslemler.GirisYapanKullaniciId).ToList();
                cmbAkbiller.DisplayMember = "AkbilNo";
                cmbAkbiller.ValueMember = "AkbilNo";
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu !" + hata.Message);
            }
        }
        private void TalimatlariDataGrideGetir(bool tumunuGoster = false)
        {
            try
            {
                var talimatlar = context.KullanicininTalimatlaris.Where(x => x.KullaniciId == GenelIslemler.GirisYapanKullaniciId);

                if (!tumunuGoster)
                {
                    talimatlar = talimatlar.Where(x => !x.YuklendiMi);
                }

                if (cmbAkbiller.SelectedIndex >= 0)
                {
                    talimatlar = talimatlar.Where(x => x.Akbil.Substring(0, 16) == cmbAkbiller.SelectedValue.ToString());
                }

                dataGridViewTalimatlar.DataSource = talimatlar.ToList();

                dataGridViewTalimatlar.Columns["Id"].Visible = false;
                dataGridViewTalimatlar.Columns["KullaniciId"].Visible = false;
                dataGridViewTalimatlar.Columns["YuklendiMi"].HeaderText = "Talimat Yüklendi Mi?";

                foreach (DataGridViewColumn item in dataGridViewTalimatlar.Columns)
                {
                    item.Width = 125;
                }
                dataGridViewTalimatlar.Columns["Akbil"].Width = 200;

                //istediğiniz diğer kolonlara da ayarlama yapabilirsiniz.
            }
            catch (Exception hata)
            {
                MessageBox.Show("Talimatlar getirilirken hata oluştu! " + hata.Message);
            }
        }
        private void BekleyenTalimatSayisiniGetir()
        {
            try
            {
                //burada bekleyen talimatları bulur
                var bekleyen = context.KullanicininTalimatlaris.Where(x => x.KullaniciId == GenelIslemler.GirisYapanKullaniciId && !x.YuklendiMi);

                if (cmbAkbiller.SelectedIndex >= 0)
                {
                    //burada ise bekleyen talimatlar içinden sadece comboda seçili olanın sayısını alıyoruz
                    lblBekleyenTalimat.Text = bekleyen.Count(x => x.Akbil.Substring(0, 16) == cmbAkbiller.SelectedValue.ToString()).ToString();
                }
                else
                {
                    //bekleyen talimatı yukarıda almıştık, aldığımız sonucu count ile saydık
                    lblBekleyenTalimat.Text = bekleyen.Count().ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbAkbiller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAkbiller.SelectedIndex >= 0)
            {
                txtYuklenecekTutar.Clear();
                grpBoxYukleme.Enabled = true;
            }
            else
            {
                txtYuklenecekTutar.Clear();
                grpBoxYukleme.Enabled = false;
            }
            BekleyenTalimatSayisiniGetir();
            TalimatlariDataGrideGetir(chboxTumunuGoster.Checked);
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
            frmAnaSayfa.Show();
        }

        private void btnTalimat_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAkbiller.SelectedIndex < 0)
                {
                    MessageBox.Show("Akbil seçiniz !");
                    return;
                }
                if (string.IsNullOrEmpty(txtYuklenecekTutar.Text))
                {
                    MessageBox.Show("Yükleme tutarı girişi yapınız !");
                    return;
                }
                if (!decimal.TryParse(txtYuklenecekTutar.Text.Trim(), out decimal tutar))
                {
                    MessageBox.Show("Yükleme tutarı alanına uygun veri girişi yapınız !");
                    return;
                }

                Talimatlar yeniTalimat = new Talimatlar()
                {
                    EklenmeTarihi = DateTime.Now,
                    AkbilId = cmbAkbiller.SelectedValue.ToString(),
                    YuklendiMi = false,
                    YuklenecekTutar = Convert.ToDecimal(txtYuklenecekTutar.Text),
                    YuklenmeTarihi = null
                };

                context.Talimatlars.Add(yeniTalimat);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Yeni talimat eklendi");
                    //temizlik
                    txtYuklenecekTutar.Clear();
                    //cmbAkbiller.SelectedIndex = -1;
                    //cmbAkbiller.Text = "Akbil Seçiniz";

                    grpBoxYukleme.Enabled = false;
                    BekleyenTalimatSayisiniGetir();
                    TalimatlariDataGrideGetir();
                }
                else
                {
                    MessageBox.Show("Yeni talimat EKLENEMEDİ !");
                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir hata oluştu !" + hata.Message);

            }
        }

        private void chboxTumunuGoster_CheckedChanged(object sender, EventArgs e)
        {
            TalimatlariDataGrideGetir(chboxTumunuGoster.Checked);
        }

        private void cikisYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı");
            //GenelIslemler.GirisYapanKullaniciAdSoyad = string.Empty;
            //GenelIslemler.GirisYapanKullaniciId = 0;
            FrmGiris frmGiris = new FrmGiris();

            foreach (Form item in Application.OpenForms)
            {
                item.Hide();
            }
            frmGiris.Show();
        }

        private void timerBekleyenTalimat_Tick(object sender, EventArgs e)
        {
            if (lblBekleyenTalimat.Text != "0")
            {
                if (DateTime.Now.Second % 2 == 0)
                {
                    lblBekleyenTalimat.Font = new Font("Segoe UI", 30);
                    lblBekleyenTalimat.ForeColor = Color.Navy;
                }
                else
                {
                    lblBekleyenTalimat.Font = new Font("Segoe UI", 15);
                    lblBekleyenTalimat.ForeColor = Color.Navy;
                }
            }
        }

        private void talimatiIptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int sayac = 0;
                foreach (DataGridViewRow item in dataGridViewTalimatlar.SelectedRows)
                {
                    //Yüklenmiş bir talimat iptal edilemez silinemez.
                    if ((bool)item.Cells["YuklendiMi"].Value)
                    {
                        MessageBox.Show($"DİKKAT! {item.Cells["Akbil"].Value} {item.Cells["YuklenecekTutar"].Value} liralık yüklemesi yapılmıştır. YÜKLENEN TALİMAT İPTAL EDİLEMEZ/SİLİNEMEZ!\nİşlemlerinize devam etmek için tamama basınız.");
                        continue;
                    }
                    var secilenTalimat = context.Talimatlars.FirstOrDefault(x => x.Id == (int)item.Cells["Id"].Value);
                    if (secilenTalimat != null)
                    {
                        context.Talimatlars.Remove(secilenTalimat);
                        sayac += context.SaveChanges();
                    }
                }
                MessageBox.Show($"Seçtiğiniz {sayac} adet talimat iptal edilmiştir.");
                TalimatlariDataGrideGetir(chboxTumunuGoster.Checked);
                BekleyenTalimatSayisiniGetir();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!" + hata.Message);
            }
        }

        private void talimatiYukleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int sayac = 0;
                foreach (DataGridViewRow item in dataGridViewTalimatlar.SelectedRows)
                {
                    if ((bool)item.Cells["YuklendiMi"].Value)
                    {
                        continue;
                    }
                    var secilenTalimat = context.Talimatlars.FirstOrDefault(x => x.Id == (int)item.Cells["Id"].Value);
                    if (secilenTalimat != null)
                    {
                        secilenTalimat.YuklendiMi = true;
                        secilenTalimat.YuklenmeTarihi = DateTime.Now;
                        secilenTalimat.Akbil.Bakiye += Convert.ToDecimal(item.Cells["YuklenecekTutar"].Value);
                        context.Talimatlars.Update(secilenTalimat);
                        context.Akbillers.Update(secilenTalimat.Akbil);
                        context.SaveChanges();
                        sayac++;
                    }

                } // foreach bitti.
                MessageBox.Show($"{sayac} adet talimat akbile yüklendi!");
                TalimatlariDataGrideGetir(chboxTumunuGoster.Checked);
                BekleyenTalimatSayisiniGetir();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu! " + hata.Message);
            }

        }
    }
}

