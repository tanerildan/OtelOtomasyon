using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
   public class Oda
    {
        public int Id { get; set; }
        public string OdaAd { get; set; }
        public int FiyatId { get; set; }
        public Boolean  Aktif { get; set; }
        public int KatId { get; set; }

        public virtual Fiyat Fiyat { get; set; }
        public virtual Kat Katlar { get; set; }

        public virtual ICollection<Rezervasyon> Rezervasyonlar { get; set; }
        public virtual ICollection<Satis> Satislar { get; set; }
    }
}
