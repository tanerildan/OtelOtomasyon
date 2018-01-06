using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
  public  class Musteri:BaseEntity
    {
        public int Id { get; set; }
        public string  AdSoyad { get; set; }
        public string TCNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Telefon { get; set; }
        public Boolean MedeniDurum { get; set; }
        public Boolean Cinsiyet { get; set; }
        public string AracPlaka { get; set; }

        public virtual ICollection<Rezervasyon> Rezervasyonlar { get; set; }
        public virtual ICollection<Satis> Satislar { get; set; }
    }
}
