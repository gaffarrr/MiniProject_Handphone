﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_Handphone.Service.Interface.Services
{
    public interface IDbService
    {
        Task<int> ModifyData(string command, object param);
        Task<List<T>> GetList<T>(string command, object param);
        Task<T> Get<T>(string v, object p);
    }
}
