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
using AkbilYonetimVeriKatmani;
using AkbilYonetimIsKatmani;
using AkbilYonetimVeriKatmani.Models;

namespace AkbilYonetim
{
    public partial class FrmAyarlar : Form
    {
        AkbildbContext context = new AkbildbContext();
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {

            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MaxDate = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Value = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;

            KullanicininBilgileriniGetir();
        }

        private void KullanicininBilgileriniGetir()
        {
            try
            {
                var kullanici = context.Kullanicilars.FirstOrDefault(x => x.Id == GenelIslemler.GirisYapanKullaniciId);
                if (kullanici != null)
                {
                    txtIsim.Text = kullanici.Ad;
                    txtSoyisim.Text = kullanici.Soyad;
                    txtEmail.Text = kullanici.Email;
                    txtEmail.Enabled = false;
                    dtpDogumTarihi.Value = kullanici.DogumTarihi.Value;
                }
                else
                {
                    MessageBox.Show("Kullanıcı bilgileri getirilemedi !");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Beklenmedik bir sorun oluştu !" + hata.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var kullanici = context.Kullanicilars.FirstOrDefault(x =>
                x.Id == GenelIslemler.GirisYapanKullaniciId);
                if (kullanici != null)
                {
                    kullanici.Ad = txtIsim.Text.Trim();
                    kullanici.Soyad = txtSoyisim.Text.Trim();
                    kullanici.DogumTarihi = dtpDogumTarihi.Value;

                    if (!string.IsNullOrEmpty(txtSifre.Text.Trim()) &&
                        kullanici.Parola != GenelIslemler.MD5Encryption(txtSifre.Text.Trim()))
                    {
                        kullanici.Parola = GenelIslemler.MD5Encryption(txtSifre.Text.Trim());
                        MessageBox.Show("Yeni şifre girdiniz !");
                    }

                    context.Kullanicilars.Update(kullanici);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Bilgileriniz güncellendi !");
                        FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                        this.Hide();
                        frmAnaSayfa.Show();
                    }

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme BAŞARISIZDIR! " + hata.Message);
            }
        }
    }
}
