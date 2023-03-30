using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using AkbilYonetimIsKatmani;
using AkbilYonetimVeriKatmani;
using AkbilYonetimVeriKatmani.Models;

namespace AkbilYonetim
{
    public partial class FrmGiris : Form
    {
        public string Email { get; set; } // Kayýt ol formunda kayýt olan kullanýcýnýn emaili buraya gelsin

        AkbildbContext context = new AkbildbContext();
        public FrmGiris()
        {
            InitializeComponent();
        }
        private void FrmGiris_Load(object sender, EventArgs e)
        {

            txtEmail.TabIndex = 1;
            txtSifre.TabIndex = 2;
            checkBoxHatirla.TabIndex = 3;
            btnGirisYap.TabIndex = 4;
            btnKayitOl.TabIndex = 5;

            txtSifre.PasswordChar = '*';

            if (Email != null)
            {
                txtEmail.Text = Email;
            }
            //Beni Hatýrlayý Properties.Settings ile yapana kadar burasý böyle kolaylýk saðlasýn.
            txtEmail.Text = "yusuf@gmail.com";
            txtSifre.Text = "1234";

        }
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmKayitOl frm = new FrmKayitOl();
            frm.Show();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void GirisYap()
        {
            try
            {
                //1) Email ve þifre textboxlarý dolu mu?

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksiksiz giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                //2) Girdiði email ve þifre veritabanýnda mevcut mu?
                var kullanici = context.Kullanicilars.FirstOrDefault(x => x.Email == txtEmail.Text && 
                x.Parola == GenelIslemler.MD5Encryption(txtSifre.Text.Trim()));

                if (kullanici == null) 
                {
                    MessageBox.Show("Email ya da Þifrenizi yanlýþ girdiniz"); 
                    return;
                }
                else
                {
                    MessageBox.Show($"Hoþgeldiniz... {kullanici.Ad} {kullanici.Soyad}");
                    GenelIslemler.GirisYapanKullaniciId = kullanici.Id;
                    GenelIslemler.GirisYapanKullaniciEmail = kullanici.Email;
                    GenelIslemler.GirisYapanKullaniciAdSoyad = $"{kullanici.Ad} {kullanici.Soyad}";

                    //Beni Hatýrla settings ile yazýlacak

                    //temizlik
                    txtEmail.Clear(); txtSifre.Clear();
                    FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                    this.Hide();
                    frmAnaSayfa.Show();
                }
            }
            catch (Exception hata)
            {
                //Dipnot : exceptionlar kullanýcýya gösterilmez, loglanýr. Biz þu an geliþtirme yaptýðýmýz için yazdýk
                MessageBox.Show("Beklenmedik bir sorun oluþtu !" + hata.Message);
            }
        }


        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) //basýlan tuþ enter ise giriþ yapacak
            {
                GirisYap();
            }
        }
    }
}