using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
    public class OdaTur
    {
        public int Id { get; set; }
        public string TurAd { get; set; }
        public string Aciklama { get; set; }
        public virtual ICollection<Fiyat> Fiyatlar { get; set; }
    }
}
