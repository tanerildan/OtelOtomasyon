using Ninject;
using OtelOtomasyon.WinForm.UI.Ninject;
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
    public partial class FormResepsiyon : Form
    {
        public FormResepsiyon()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            InitializeComponent();
        }

        private void FormResepsiyon_Load(object sender, EventArgs e)
        {
            #region Tarih ayarları
            dtpTarih.MinDate = DateTime.Today;
            dtpTarih.MaxDate = dtpTarih.MinDate.AddDays(7);
            dtpGiris.Value = DateTime.Today;
            dtpGiris.MinDate = DateTime.Today;
            dtpCikis.MinDate = dtpGiris.MinDate.AddDays(1);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            #endregion

            //OdaTurDoldur();
            //OdaOpsiyonDoldur();
            //KatDoldur();
            //CinsiyetDoldur();
            //MedeniHalDoldur();
            //BosOdaKontrol();

        }

        private void dtpGiris_ValueChanged(object sender, EventArgs e)
        {
            dtpGiris.MaxDate = DateTime.Today.AddDays(7);
            txtGiris.Text = dtpGiris.Value.ToShortDateString();
            dtpCikis.MinDate = dtpGiris.Value.AddDays(1);
        }

        private void dtpCikis_ValueChanged(object sender, EventArgs e)
        {
            txtCikis.Text = dtpCikis.Value.ToShortDateString();
        }
    }
}
