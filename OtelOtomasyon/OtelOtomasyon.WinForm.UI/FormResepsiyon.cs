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
            //OdaTurDoldur();
            //OdaOpsiyonDoldur();
            //KatDoldur();
            //CinsiyetDoldur();
            //MedeniHalDoldur();
            //BosOdaKontrol();

        }
    }
}
