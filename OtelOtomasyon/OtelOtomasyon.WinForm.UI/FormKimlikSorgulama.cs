using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyon.WinForm.UI
{
    public partial class FormKimlikSorgulama : Form
    {
        public FormKimlikSorgulama()
        {
            InitializeComponent();
        }

        private void FormKimlikSorgulama_Load(object sender, EventArgs e)
        {
            //KPSPublicSoapClient servis = new KPSPublicSoapClient();
            //bool varmi = false;
            //varmi = servis.TCKimlikNoDogrula(Convert.ToInt64(txtboxTC.Text), txtboxAd.Text.ToUpper(), txtboxSoyad.Text.ToUpper(), Convert.ToInt32(txtboxDyil.Text));
            //if (varmi)
            //{
            //    MessageBox.Show("tC Doğru ");
            //}
            //else
            //{
            //    MessageBox.Show("tC Yanlış  ");
            //}
        }
    }
}
