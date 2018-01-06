using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public class MusteriService:IMusteriService
    {
        private readonly IMusteriRepository _musteriRepository;
        public MusteriService(IMusteriRepository musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }
    }
}
