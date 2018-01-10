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
  public  class LoginService:ILoginService
    {
        private readonly IUnitOfWork _uow;
        public LoginService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultModel<Login> UserAdd(Login model)
        {
            var Validator = new LoginValidator().Validate(model);
            if (Validator.IsValid)
            {
                _uow.GetRepo<Login>().Add(model);
                if (_uow.Commit()>0)
                {
                    return new ResultModel<Login>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = "Başarıyla kaydedildi"
                    };
                }

                return new ResultModel<Login>
                {
                    Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "Kayıt başarısız!!"
                };

            }
            return new ResultModel<Login>
            {
                Errors = Validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kayıt başarısız!!"
            };
        }

        public ResultModel<Login> UserUpdate(Login model)
        {
            var validator = new LoginValidator().Validate(model);
            if (validator.IsValid)
            {
                _uow.GetRepo<Login>().Update(model);
                if (_uow.Commit()>0)
                {
                    return new ResultModel<Login>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = "Başarıyla değiştirildi"
                    };
                }
                return new ResultModel<Login>
                {
                    Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                    IsValid = false,
                    Message = "Kayıt başarısız!!"
                };
            }
            return new ResultModel<Login>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kayıt başarısız!!"
            };

        }
    }
}
