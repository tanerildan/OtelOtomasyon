﻿using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Abstracts
{
   public interface ILoginService
    {
        ResultModel<Login> UserAdd(Login model);
        ResultModel<Login> UserUpdate(Login model);
    }
}
