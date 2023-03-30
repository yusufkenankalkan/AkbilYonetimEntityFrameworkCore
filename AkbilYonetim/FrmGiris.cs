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
        public string Email { get; set; } // Kay�t ol formunda kay�t olan kullan�c�n�n emaili buraya gelsin

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
            //Beni Hat�rlay� Properties.Settings ile yapana kadar buras� b�yle kolayl�k sa�las�n.
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
                //1) Email ve �ifre textboxlar� dolu mu?

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSifre.Text))
                {
                    MessageBox.Show("Bilgileri eksiksiz giriniz !", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                //2) Girdi�i email ve �ifre veritaban�nda mevcut mu?
                var kullanici = context.Kullanicilars.FirstOrDefault(x => x.Email == txtEmail.Text && 
                x.Parola == GenelIslemler.MD5Encryption(txtSifre.Text.Trim()));

                if (kullanici == null) 
                {
                    MessageBox.Show("Email ya da �ifrenizi yanl�� girdiniz"); 
                    return;
                }
                else
                {
                    MessageBox.Show($"Ho�geldiniz... {kullanici.Ad} {kullanici.Soyad}");
                    GenelIslemler.GirisYapanKullaniciId = kullanici.Id;
                    GenelIslemler.GirisYapanKullaniciEmail = kullanici.Email;
                    GenelIslemler.GirisYapanKullaniciAdSoyad = $"{kullanici.Ad} {kullanici.Soyad}";

                    //Beni Hat�rla settings ile yaz�lacak

                    //temizlik
                    txtEmail.Clear(); txtSifre.Clear();
                    FrmAnaSayfa frmAnaSayfa = new FrmAnaSayfa();
                    this.Hide();
                    frmAnaSayfa.Show();
                }
            }
            catch (Exception hata)
            {
                //Dipnot : exceptionlar kullan�c�ya g�sterilmez, loglan�r. Biz �u an geli�tirme yapt���m�z i�in yazd�k
                MessageBox.Show("Beklenmedik bir sorun olu�tu !" + hata.Message);
            }
        }


        private void txtSifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) //bas�lan tu� enter ise giri� yapacak
            {
                GirisYap();
            }
        }
    }
}