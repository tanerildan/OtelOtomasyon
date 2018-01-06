using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
   public class Satis:BaseEntity
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int OdaId { get; set; }
        public int PersonelId { get; set; }
        public DateTime SatisTarihi { get; set; }
        public Boolean Aktif { get; set; }

        public virtual Musteri  Musteri{ get; set; }
        public virtual Oda Odalar { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
