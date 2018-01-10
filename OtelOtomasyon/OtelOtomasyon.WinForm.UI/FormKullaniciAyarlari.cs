using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.UOW.Abstract;
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
    public partial class FormKullaniciAyarlari : Form
    {
        private readonly ILoginService _logService;
        protected IUnitOfWork _uow;
        public FormKullaniciAyarlari()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _uow = container.Get<IUnitOfWork>();
            _logService = container.Get<ILoginService>();
            //_logService = container.Get<ILoginService>();
            InitializeComponent();
        }

       

        private void FormKullaniciAyarlari_Load(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
            ComboDoldur();
           DataGridDoldur();
           txtUserName.Focus();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            Login lgn = new Login();
            lgn.UserName = txtUserName.Text;
            lgn.Password = txtPassword.Text;
            lgn.RoleId = Convert.ToInt32(cbRoleId.SelectedValue);

            var result = _logService.UserAdd(lgn);

            if (result.IsValid)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
            Temizle();
            DataGridDoldur();


        }
        private void Temizle()
        {
            txtPassword.Clear();
            txtUserName.Clear();
        }
        private void ComboDoldur()
        {
            var model = _uow.GetRepo<Role>().GetList();
            cbRoleId.DisplayMember = "RoleName";
            cbRoleId.ValueMember = "Id";
            cbRoleId.DataSource = model;
        }
       
      private void  DataGridDoldur()
        {
            var model = _uow.GetRepo<Login>().GetList().Select(x => new
            {
                x.UserName,
                x.Password,
                x.RoleId,
                x.Role.RoleName,
                x.Id
            }).ToList();
            dgvLogin.DataSource = model;
        }

        private void dgvLogin_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            txtPassword.Text = dgvLogin.SelectedRows[0].Cells[1].Value.ToString();
            txtUserName.Text = dgvLogin.SelectedRows[0].Cells[0].Value.ToString();
            cbRoleId.SelectedValue = dgvLogin.SelectedRows[0].Cells[2].Value;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Login lgn = new Login();
            lgn.Id = _uow.GetRepo<Login>().GetById((int)dgvLogin.CurrentRow.Cells[4].Value).Id;
            lgn.UserName = txtUserName.Text;
            lgn.Password = txtPassword.Text;
            lgn.RoleId = Convert.ToInt32(cbRoleId.SelectedValue);
            var result = _logService.UserUpdate(lgn);
            if (result.IsValid)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
            Temizle();
            DataGridDoldur();
            txtUserName.Focus();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            _uow.GetRepo<Login>().Delete((int)dgvLogin.SelectedRows[0].Cells[2].Value);
            if (_uow.Commit()>0)
            {
                MessageBox.Show("Kayıt silindi");
            }
            Temizle();
            DataGridDoldur();
            txtUserName.Focus();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormPersonelIslemleri frm = new FormPersonelIslemleri();
            frm.ShowDialog();
        }
    }
}
