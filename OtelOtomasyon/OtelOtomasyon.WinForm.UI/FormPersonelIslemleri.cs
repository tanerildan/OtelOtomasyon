using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.Abstract;
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
    public partial class FormPersonelIslemleri : Form
    {
        private readonly IPersonelService _personelService;
        //private readonly IPersonelRepository _personelRepository;
        protected IUnitOfWork _uow;

        public FormPersonelIslemleri()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _uow = container.Get<IUnitOfWork>();
            _personelService = container.Get<IPersonelService>();
            InitializeComponent();
        }

        private void FormPersonelIslemleri_Load(object sender, EventArgs e)
        {
            DataGridDoldur();
            btnYeni.Enabled = true;
            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;

        }
        private void DataGridDoldur()
        {
            var model = _uow.GetRepo<Personel>().GetList().Select(x => new
            {
                x.Id,
                x.AdSoyad,
                x.DogumTarihi,
                x.TCNo,
                x.Telefon,
                x.Adres,
                x.Cinsiyet,
                x.Aktif,
                x.IseGirisTarihi,
                x.LoginId,
                x.Login.UserName,
            }).Where(x=> x.Aktif ==true).ToList();
            dgvPersonel.DataSource = model;
            dgvPersonel.Columns[6].Visible = false;
            dgvPersonel.Columns[0].Visible = false;
            dgvPersonel.Columns[7].Visible = false;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            Temizle();
            btnKaydet.Enabled = true;
            btnSil.Enabled = false;
            btnYeni.Enabled = true;
            btnGuncelle.Enabled = false;

        }
        private void Temizle()
        {
            txtAdres.Clear();
            txtAdSoyad.Clear();
            txtKimlikNo.Clear();
            txtTelefon.Clear();
            cbCinsiyet.Text = "";
            txtLoginId.Clear();
            cbAktif.Text = "";

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
              
            Personel prs = new Personel();
            prs.AdSoyad = txtAdSoyad.Text;
            prs.TCNo = txtKimlikNo.Text;
            prs.Telefon = txtTelefon.Text;
            prs.Adres = txtAdres.Text;
            if (cbCinsiyet.SelectedItem == "Bayan")
            {
                prs.Cinsiyet = false;
            }
            else if (cbCinsiyet.SelectedItem == "Erkek")
            {
                prs.Cinsiyet = true;
            }
            prs.Aktif = Convert.ToBoolean(cbAktif.SelectedValue);
            prs.IseGirisTarihi = dtpIseBaslangicTarihi.Value;
            prs.DogumTarihi = dtpDogum.Value;
            prs.LoginId = Convert.ToInt32(txtLoginId.Text);
            var result = _personelService.PersonelAdd(prs);
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

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            FormKullaniciAyarlari frm = new FormKullaniciAyarlari();
            frm.ShowDialog();
        }

        private void dgvPersonel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            //
            txtAdSoyad.Text = dgvPersonel.SelectedRows[0].Cells[1].Value.ToString();
            txtKimlikNo.Text = dgvPersonel.SelectedRows[0].Cells[3].Value.ToString();
            txtTelefon.Text = dgvPersonel.SelectedRows[0].Cells[4].Value.ToString();
            txtAdres.Text = dgvPersonel.SelectedRows[0].Cells[5].Value.ToString();
            cbAktif.SelectedItem = dgvPersonel.SelectedRows[0].Cells[7].Value.ToString();
           dtpDogum.Value = Convert.ToDateTime(dgvPersonel.SelectedRows[0].Cells[2].Value);
            dtpIseBaslangicTarihi.Value = Convert.ToDateTime(dgvPersonel.SelectedRows[0].Cells[8].Value);
            txtLoginId.Text = dgvPersonel.SelectedRows[0].Cells[9].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs.AdSoyad = txtAdSoyad.Text;
            prs.TCNo = txtKimlikNo.Text;
            prs.Telefon = txtTelefon.Text;
            prs.Adres = txtAdres.Text;
            if (cbCinsiyet.SelectedItem == "Bayan")
            {
                prs.Cinsiyet = false;
            }
            else if (cbCinsiyet.SelectedItem == "Erkek")
            {
                prs.Cinsiyet = true;
            }
            prs.Aktif = Convert.ToBoolean(cbAktif.SelectedValue);
            prs.IseGirisTarihi = dtpIseBaslangicTarihi.Value;
            prs.DogumTarihi = dtpDogum.Value;
            prs.LoginId = Convert.ToInt32(txtLoginId.Text);
            prs.Id = _uow.GetRepo<Personel>().GetById((int)dgvPersonel.CurrentRow.Cells[0].Value).Id;
            var result = _personelService.PersonelUpdate(prs);
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs= _uow.GetRepo<Personel>().GetById((int)dgvPersonel.CurrentRow.Cells[0].Value);
            prs.Aktif = false;
            _uow.GetRepo<Personel>().Update(prs);
            //var sonuc = _uow.GetRepo<Personel>().Where(x => x.Id == prs.Id).Select(x => x.Aktif);
            //sonuc = false;
            if (_uow.Commit()>0)
            {
                MessageBox.Show("Kayıt silindi");
                Temizle();
                DataGridDoldur();
            }
            else { MessageBox.Show("İşlem gerçekleştirilemedi"); }
           


        }
    }
}
