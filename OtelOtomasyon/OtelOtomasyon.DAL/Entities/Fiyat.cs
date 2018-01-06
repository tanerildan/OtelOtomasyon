using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
    public class Fiyat:BaseEntity
    {
        public int Id { get; set; }
        public int OzellikId { get; set; }
        public int OdaTurId { get; set; }
        public int FiyatTutar { get; set; }

        public virtual Ozellik Ozellik { get; set; }
        public virtual OdaTur OdaTurler { get; set; }

        public virtual ICollection<Oda> Odalar { get; set; }
    }
}
