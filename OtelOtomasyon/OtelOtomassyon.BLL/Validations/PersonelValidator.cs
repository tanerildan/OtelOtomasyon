using FluentValidation;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Validations
{
   public class PersonelValidator:AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad ve Soyad boş geçilemez!");
            RuleFor(x => x.TCNo).NotEmpty().WithMessage("TC Kimlik Numarası boş geçilemez! ");
            RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon boş geçilemez");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Adres boş geçilemez!");
            RuleFor(x => x.Cinsiyet).NotEmpty().WithMessage("Cinsiyet boş geçilemez");
            RuleFor(x => x.IseGirisTarihi).NotEmpty().WithMessage("Tarih seçilmeden geçilemez");
            
        }
    }
}
