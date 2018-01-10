using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Abstracts
{
   public interface IPersonelService
    {
        ResultModel<Personel> PersonelAdd(Personel model);
        ResultModel<Personel> PersonelUpdate(Personel model);
       
    }
}
