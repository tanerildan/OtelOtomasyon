using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL.Entities;
using OtelOtomassyon.BLL.Validations;
using OtelOtomasyon.Repository.UOW.Abstract;

namespace OtelOtomassyon.BLL.Services.Concretes
{
    public class PersonelService : IPersonelService
    {
        private readonly IUnitOfWork _uow;
        public PersonelService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultModel<Personel> PersonelAdd(Personel model)
        {
            var Validator = new PersonelValidator().Validate(model);
            if (Validator.IsValid)
            {
                _uow.GetRepo<Personel>().Add(model);
                if (_uow.Commit()>0)
                {
                    return new ResultModel<Personel>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = " Personel kaydetme işlemi aşarıyla kaydedildi"
                    };
                }
                return new ResultModel<Personel>
                {
                    Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "Kayıt başarısız!!"
                };
            }
            return new ResultModel<Personel>
            {
                Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kayıt başarısız!!"
            };

        }

       

        public ResultModel<Personel> PersonelUpdate(Personel model)
        {
            var Validator = new PersonelValidator().Validate(model);
            if (Validator.IsValid)
            {
                _uow.GetRepo<Personel>().Update(model);
                if (_uow.Commit() > 0)
                {
                    return new ResultModel<Personel>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = " Değişiklikler başarıyla kaydedildi"
                    };
                }
                return new ResultModel<Personel>
                {
                    Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "İşlem başarısız!!"
                };
            }
            return new ResultModel<Personel>
            {
                Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "İşlem başarısız!!"
            };

        }
    }
}
