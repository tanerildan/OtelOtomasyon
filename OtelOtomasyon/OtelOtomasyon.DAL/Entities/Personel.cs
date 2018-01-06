using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
   public  class Personel:BaseEntity
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string TCNo { get; set; }
        public Boolean Cinsiyet { get; set; }
        public string Adres { get; set; }
        public Boolean Aktif { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public string Telefon { get; set; }
        public int LoginId { get; set; }

        public virtual Login Login { get; set; }

        public virtual ICollection<Satis> Satislar { get; set; }
    }
}
