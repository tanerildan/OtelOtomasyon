using FluentValidation;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.UOW.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Validations
{
    public class LoginValidator : AbstractValidator<Login>
    {
        protected IUnitOfWork _uow;
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password boş geçilemez");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("RoleId boş geçilemez");
            //    RuleFor(x => x.UserName).Must(UserNameNotExist).WithMessage("Aynı isimde UserName mevcut bulunmaktadır. Farklı bir isim deneyiniz!");
            //}
            //public bool UserNameNotExist(string name)
            //{
            //    var data = _uow.GetRepo<Login>().Where(x => x.UserName == name).FirstOrDefault();
            //    if (data== null)
            //    {
            //        return false;
            //    }

            //    return true;
            //}
        }
    }
}
