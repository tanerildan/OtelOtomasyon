using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
  public  class LoginService:ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
    }
}
