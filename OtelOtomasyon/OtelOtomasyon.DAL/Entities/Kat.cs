using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Entities
{
   public class Kat
    {
        public int Id { get; set; }
        public int KatNo { get; set; }

        public virtual ICollection<Oda> Odalar { get; set; }
    }
}
