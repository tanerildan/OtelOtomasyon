using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
    public class Ozellik
    {
        public int Id { get; set; }
        public string OzellikAd { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Fiyat> Fiyatlar { get; set; }
    }
}
