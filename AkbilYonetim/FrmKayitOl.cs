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
    public partial class FrmKayitOl : Form
    {

        AkbildbContext context = new AkbildbContext();
        public FrmKayitOl()
        {
            InitializeComponent();
        }

        private void FrmKayitOl_Load(object sender, EventArgs e)
        {
            #region Ayarlar
            txtSifre.PasswordChar = '*';
            dtpDogumTarihi.MaxDate = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Value = new DateTime(2016, 1, 1);
            dtpDogumTarihi.Format = DateTimePickerFormat.Short;

            #endregion
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                btnKayitOl.Enabled = false;
                btnGirisYap.Enabled = false;

                foreach (var item in Controls)
                {
                    if (item is TextBox txt && string.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Zorunlu alanları doldurunuz");
                        btnKayitOl.Enabled = true;
                        btnGirisYap.Enabled = true;
                        return;
                    }
                } //foreach bitti

                // Bu emailden sistemde var mı ? 
                if (context.Kullanicilars.FirstOrDefault(x => x.Email == txtEmail.Text.Trim()) != null)
                {
                    MessageBox.Show("Bu emaile ait sistemde kayıt bulunmaktadır !");
                    btnKayitOl.Enabled = true;
                    btnGirisYap.Enabled = true;
                    return;
                }

                Kullanicilar yeniKulanici = new Kullanicilar()
                {
                    EklenmeTarihi = DateTime.Now,
                    Ad = txtIsim.Text.Trim(),
                    Soyad = txtSoyisim.Text.Trim(),
                    DogumTarihi = dtpDogumTarihi.Value,
                    Email = txtEmail.Text.Trim(),
                    Parola = GenelIslemler.MD5Encryption(txtSifre.Text.Trim())
                };
                context.Kullanicilars.Add(yeniKulanici);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Kullanici Eklendi !");
                    //temizlik
                    foreach (var item in Controls)
                    {
                        if (item is TextBox)
                        {
                            ((TextBox)item).Clear();
                        }
                        if (item is DateTimePicker)
                        {
                            ((DateTimePicker)item).Value = ((DateTimePicker)item).MaxDate;
                        }
                    }
                    var cevap = MessageBox.Show("Giriş sayfasına dönmek ister misiniz ?", "SORGU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (cevap == DialogResult.Yes)
                    {
                        FrmGiris frmGiris = new FrmGiris();
                        frmGiris.Email = txtEmail.Text.Trim();
                        this.Hide();
                        frmGiris.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanici Ekleme Başarısız oldu !");
                }

                btnKayitOl.Enabled = true;
                btnGirisYap.Enabled = true;
            }
            catch (Exception ex)
            {
                // ex log.txt'ye yazılacak(loglama)
                MessageBox.Show("Beklenmedik bir hata oluştu ! Lütfen tekrar deneyiniz !");
            }
        }

        private void GirisFormunaGit()
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Email = txtEmail.Text.Trim();
            this.Hide();
            frmGiris.Show();
        }

        private void FrmKayitOl_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisFormunaGit();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisFormunaGit();
        }

        private void txtIsim_TextChanged(object sender, EventArgs e)
        {
            txtIsim.Text = txtIsim.Text.ToUpper();
            txtIsim.SelectionStart = txtIsim.Text.Length;
        }

        private void txtSoyisim_TextChanged(object sender, EventArgs e)
        {
            txtSoyisim.Text = txtSoyisim.Text.ToUpper();
            txtSoyisim.SelectionStart = txtSoyisim.Text.Length;
        }
    }
}
