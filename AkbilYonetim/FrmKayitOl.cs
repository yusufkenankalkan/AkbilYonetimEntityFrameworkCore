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
namespace AkbilYonetim
{
    public partial class FrmKayitOl : Form
    {

        
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
                foreach (var item in Controls)
                {
                    if (item is TextBox txt && string.IsNullOrEmpty(txt.Text))
                    {
                        MessageBox.Show("Zorunlu alanları doldurunuz");
                        return;
                    }
                }

               

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
